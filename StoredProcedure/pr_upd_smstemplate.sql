DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_upd_smstemplate` $$

CREATE PROCEDURE `pr_upd_smstemplate`(
  in in_smstemplate_gid int,
  in in_smstemplate_name varchar(128),
  in in_sender_gid int,
  in in_sms_template text,
  in in_active_status char(1),
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag varchar(10) default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if not exists(select smstemplate_gid from sms_mst_tsmstemplate
    where smstemplate_gid = in_smstemplate_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid sms template,');
    set err_flag := true;
  end if;

  if in_smstemplate_Name = '' then
    set err_msg := concat(err_msg,'Blank sms template name,');
    set err_flag := true;
  end if;

  if in_active_status <> 'Y'
    and in_active_status <> 'N' then
    set err_msg := concat(err_msg,'Invalid active status,');
    set err_flag := true;
  end if;

  if not exists(select sender_gid from sms_mst_tsender
    where sender_gid = in_sender_gid
    and active_status = 'Y'
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid sender,');
    set err_flag := true;
  end if;

  if in_sms_template = '' then
    set err_msg := concat(err_msg,'Sms template cannot be blank,');
    set err_flag := true;
  end if;

  if exists(select smstemplate_gid from sms_mst_tsmstemplate
    where smstemplate_name = in_smstemplate_name
    and smstemplate_gid <> in_smstemplate_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Sms template name already exists,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  update sms_mst_tsmstemplate set
    smstemplate_name = in_smstemplate_name,
    sender_gid = in_sender_gid,
    sms_template = in_sms_template,
    active_status = in_active_status,
    update_date = sysdate(),
    update_by = in_action_by
  where smstemplate_gid = in_smstemplate_gid
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;