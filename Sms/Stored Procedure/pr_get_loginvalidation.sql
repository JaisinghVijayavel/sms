DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_get_loginvalidation` $$
CREATE PROCEDURE `pr_get_loginvalidation`(
  in in_user_code varchar(16),
  in in_pwd varchar(255),
  in in_ip_addr varchar(255),
  in in_max_pwd_attempt int
)
me:BEGIN
  declare done int default 0;
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_user_gid int default 0;
  declare v_usergroup_gid int default 0;
  declare v_user_code varchar(16) default '';
  declare v_user_name varchar(255) default '';
  declare v_pwd varchar(255) default '';
  declare v_user_status char(1) default '';
  declare v_attempt_count int default 0;
  declare v_login_date date;
  declare v_pwd_exp_date date;
  declare n int default 0;
  declare c int default 0;
  declare v_out_msg text default '';
  declare v_out_result int default 0;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set v_out_msg = 'SQLEXCEPTION';
    set v_out_result = 0;

    select v_user_gid as user_gid,
        v_user_name as user_name,
        v_pwd_exp_date as pwd_exp_date,
        v_usergroup_gid as usergroup_gid,
        v_out_result as out_result,
        v_out_msg as out_msg;
  END;

  -- get user_gid
  select
    user_gid,
    usergroup_gid,
    user_code,
    user_name,
    pwd,
    user_status,
    attempt_count,
    cast(login_date as date),
    pwd_exp_date
  into
    v_user_gid,
    v_usergroup_gid,
    v_user_code,
    v_user_name,
    v_pwd,
    v_user_status,
    v_attempt_count,
    v_login_date,
    v_pwd_exp_date
  from soft_mst_tuser
  where user_code = in_user_code
  and auth_flag = 'Y'
  and delete_flag = 'N';

  set v_user_gid = ifnull(v_user_gid,0);
  set v_usergroup_gid = ifnull(v_usergroup_gid,0);
  set v_user_code = ifnull(v_user_code,'');
  set v_user_name = ifnull(v_user_name,'');
  set v_pwd = ifnull(v_pwd,'');
  set v_user_status = ifnull(v_user_status,'');
  set v_attempt_count = ifnull(v_attempt_count,0);
  set v_login_date = ifnull(v_login_date,curdate());
  set v_pwd_exp_date = ifnull(v_pwd_exp_date,adddate(curdate(),30));

  /*
  set out_user_gid = v_user_gid;
  set out_pwd_exp_date = v_pwd_exp_date;
  set out_usergroup_gid = v_usergroup_gid;
  set out_user_name = v_user_name;
  */

  if v_user_gid = 0 then
    set v_out_result = 0;
    set v_out_msg = 'Invalid user !';

    -- log it attempt table
    insert into soft_trn_tloginattempt
    (
      login_date,
      user_code,
      system_ip
    )
    values
    (
      sysdate(),
      in_user_code,
      in_ip_addr
    );

    select v_user_gid as user_gid,
        v_user_name as user_name,
        v_pwd_exp_date as pwd_exp_date,
        v_usergroup_gid as usergroup_gid,
        v_out_result as out_result,
        v_out_msg as out_msg;

    leave me;
  end if;

  -- invalid password
  if v_pwd <> in_pwd then
    set v_out_result = 0;
    set v_out_msg = 'Invalid password !';

    -- increase attempt count
    set v_attempt_count = v_attempt_count + 1;

    if v_attempt_count >= in_max_pwd_attempt then
      update soft_mst_tuser set
        user_status = 'N',
        attempt_count = attempt_count + 1
      where user_gid = v_user_gid
      and delete_flag = 'N';

      set v_out_msg = 'Your id was deactivated ! Please contact system administrator !';
    else
      update soft_mst_tuser set
        attempt_count = attempt_count + 1
      where user_gid = v_user_gid
      and delete_flag = 'N';
    end if;

    -- log it attempt table
    insert into soft_trn_tloginattempt
    (
      login_date,
      user_code,
      system_ip
    )
    values
    (
      sysdate(),
      in_user_code,
      in_ip_addr
    );

    select v_user_gid as user_gid,
        v_user_name as user_name,
        v_pwd_exp_date as pwd_exp_date,
        v_usergroup_gid as usergroup_gid,
        v_out_result as out_result,
        v_out_msg as out_msg;

    leave me;
  end if;

  if v_user_status = 'N' then
    set v_out_result = 0;
    set v_out_msg = 'Your id was deactivated ! Please contact system administrator !';

    select v_user_gid as user_gid,
        v_user_name as user_name,
        v_pwd_exp_date as pwd_exp_date,
        v_usergroup_gid as usergroup_gid,
        v_out_result as out_result,
        v_out_msg as out_msg;

    leave me;
  elseif v_user_status = 'D' then
    set v_out_result = 0;
    set v_out_msg = 'Your id was blocked !';

    select v_user_gid as user_gid,
        v_user_name as user_name,
        v_pwd_exp_date as pwd_exp_date,
        v_usergroup_gid as usergroup_gid,
        v_out_result as out_result,
        v_out_msg as out_msg;

    leave me;
  elseif v_user_status <> 'Y' then
    set v_out_result = 0;
    set v_out_msg = concat('Your id status : ',v_user_status);

    select v_user_gid as user_gid,
        v_user_name as user_name,
        v_pwd_exp_date as pwd_exp_date,
        v_usergroup_gid as usergroup_gid,
        v_out_result as out_result,
        v_out_msg as out_msg;

    leave me;
  end if;

  if datediff(curdate(),v_login_date) > 30 then
    update soft_mst_tuser set
      user_status = 'N'
    where user_gid = v_user_gid
    and delete_flag = 'N';

    set v_out_result = 0;
    set v_out_msg = 'Your id was deactivated ! Please contact system administrator !';

    select v_user_gid as user_gid,
        v_user_name as user_name,
        v_pwd_exp_date as pwd_exp_date,
        v_usergroup_gid as usergroup_gid,
        v_out_result as out_result,
        v_out_msg as out_msg;

    leave me;
  end if;

  -- successful login
  insert into soft_trn_tloginhistory
  (
    login_date,
    user_gid,
    system_ip
  )
  values
  (
    sysdate(),
    v_user_gid,
    in_ip_addr
  );

  update soft_mst_tuser set
    login_date = sysdate(),
    attempt_count = 0
  where user_gid = v_user_gid
  and delete_flag = 'N';

  set v_out_msg = 'Login success !';
  set v_out_result = 1;

  select v_user_gid as user_gid,
        v_user_name as user_name,
        v_pwd_exp_date as pwd_exp_date,
        v_usergroup_gid as usergroup_gid,
        v_out_result as out_result,
        v_out_msg as out_msg;

END $$

DELIMITER ;