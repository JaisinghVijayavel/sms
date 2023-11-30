DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_ins_smstemplate` $$

CREATE PROCEDURE `pr_ins_smstemplate`(
  in in_smstemplate_name varchar(128),
  in in_sender_gid int,
  in in_sms_template text,
  in in_active_status char(1),
  in in_action_by varchar(16),
  out out_smstemplate_gid int,
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
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Smstemplate name already exists,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  INSERT INTO sms_mst_tsmstemplate
  (
    smstemplate_name,
    sender_gid,
    sms_template,
    active_status,
    insert_date,
    insert_by
  )
  VALUES
  (
    in_smstemplate_name,
    in_sender_gid,
    in_sms_template,
    in_active_status,
    sysdate(),
    in_action_by
  );

  COMMIT;

  select max(smstemplate_gid) into out_smstemplate_gid from sms_mst_tsmstemplate;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;