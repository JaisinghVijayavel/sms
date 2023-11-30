DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_set_password` $$
CREATE PROCEDURE `pr_set_password`(
  in in_user_gid int,
  in in_old_pwd varchar(255),
  in in_new_pwd varchar(255),
  in in_max_pwd_sno int,
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare done int default 0;
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_user_gid int default 0;
  declare v_curr_pwd_sno int default 0;
  declare v_new_pwd_sno int default 0;
  declare v_password_gid int default 0;
  declare v_old_pwd varchar(255) default '';
  declare n int default 0;
  declare c int default 0;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  -- get user_gid
  select
    user_gid,
    pwd_sno,
    pwd
  into
    v_user_gid,
    v_curr_pwd_sno,
    v_old_pwd
  from soft_mst_tuser
  where user_gid = in_user_gid
  and delete_flag = 'N';

  set v_user_gid = ifnull(v_user_gid,0);
  set v_curr_pwd_sno = ifnull(v_curr_pwd_sno,0);
  set v_old_pwd = ifnull(v_old_pwd,'');

  if v_user_gid = 0 then
    set err_msg := concat(err_msg,'Invalid user !,');
    set err_flag := true;
  end if;

  if v_old_pwd <> in_old_pwd then
    set err_msg := concat(err_msg,'Invalid old password !,');
    set err_flag := true;
  end if;

  -- check user new password matches with last passwords
  select password_gid into v_password_gid from soft_mst_tpassword
  where user_gid = v_user_gid
  and pwd = in_new_pwd
  and delete_flag = 'N'
  limit 0,1;

  set v_password_gid = ifnull(v_password_gid,0);

  if v_password_gid > 0 then
    set err_msg := concat(err_msg,'password not changed ! New password matched with previous passwords !');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  if v_curr_pwd_sno >= in_max_pwd_sno then
    set v_curr_pwd_sno = 1;
  else
    set v_curr_pwd_sno = v_curr_pwd_sno + 1;
  end if;

  START TRANSACTION;

  if v_password_gid = 0 then
    insert into soft_mst_tpassword
    (
      user_gid,
      entry_date,
      pwd,
      pwd_sno
    )
    values
    (
      v_user_gid,
      sysdate(),
      in_new_pwd,
      v_curr_pwd_sno
    );
  else
    update soft_mst_tpassword set
      entry_date = sysdate(),
      pwd = in_new_pwd
    where user_gid = v_user_gid
    and pwd_sno = v_curr_pwd_sno
    and delete_flag = 'N';
  end if;

  update soft_mst_tuser set
    pwd = in_new_pwd,
    pwd_sno = v_curr_pwd_sno,
    pwd_exp_date = date_add(curdate(),interval 1 month)
  where user_gid = v_user_gid
  and delete_flag = 'N';

  COMMIT;

  set out_msg = 'Password changed successfully !';
  set out_result = 1;
END $$

DELIMITER ;