DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_set_tauth` $$
CREATE PROCEDURE `pr_div_set_tauth`(
  in in_auth_gid int,
  in in_auth_status char(1),
  in in_auth_remark text,
  in in_action varchar(8),
  in in_action_by varchar(10),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_auth_gid int default 0;
  declare v_auth_sql text default '';
  declare v_reject_sql text default '';

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  select
    auth_gid,
    auth_sql,
    reject_sql
  into
    v_auth_gid,
    v_auth_sql,
    v_reject_sql
  from soft_trn_tauth
  where auth_gid = in_auth_gid
  and delete_flag = 'N';

  set v_auth_gid = ifnull(v_auth_gid,0);
  set v_auth_sql = ifnull(v_auth_sql,'');
  set v_reject_sql = ifnull(v_reject_sql,'');

  if v_auth_gid = 0 then
    set out_msg = 'Invalid auth gid';
    set out_result = 0;
    leave me;
  end if;

  if in_auth_flag = 'A' then
    set @auth_sql = v_auth_sql;

    if @auth_sql <> '' then
      PREPARE stmt FROM @auth_sql;
      EXECUTE stmt;
      DEALLOCATE PREPARE stmt;
    end if;

    update soft_trn_tauth set
      auth_date = sysdate(),
      auth_by = in_action,
      auth_flag = 'Y'
    where auth_gid = in_auth_gid
    and auth_flag = 'N'
    and delete_flag = 'N';

    set out_msg = 'Updation done !';
  else
    set @reject_sql = v_reject_sql;

    if @reject_sql <> '' then
      PREPARE stmt FROM @reject_sql;
      EXECUTE stmt;
      DEALLOCATE PREPARE stmt;
    end if;

    update soft_trn_tauth set
      auth_date = sysdate(),
      auth_by = in_action,
      auth_flag = 'R',
      auth_remark = in_auth_remark
    where auth_gid = in_auth_gid
    and auth_flag = 'N'
    and delete_flag = 'N';

    set out_msg = 'Updation Rejected !';
  end if;

  set out_result = 1;
 END $$

DELIMITER ;