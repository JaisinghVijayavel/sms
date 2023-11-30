DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_ins_smstemplatefield` $$

CREATE PROCEDURE `pr_ins_smstemplatefield`(
  in in_smstemplate_gid int,
  in in_field_name varchar(128),
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
    ROLLBACK;

    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if not exists(select smstemplate_gid from sms_mst_tsmstemplate
    where smstemplate_gid = in_smstemplate_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid sms template name,');
    set err_flag := true;
  end if;

  if not exists(select field_gid from sms_mst_tfield
    where field_name = in_field_name
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid field name,');
    set err_flag := true;
  end if;

  if in_active_status <> 'Y'
    and in_active_status <> 'N' then
    set err_msg := concat(err_msg,'Invalid active status,');
    set err_flag := true;
  end if;

  if exists(select smstemplatefield_gid from sms_mst_tsmstemplatefield
    where smstemplate_gid = in_smstemplate_gid
    and field_name = in_field_name
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Sms template field already exists,');
    set err_flag := true;
  end if;

  if in_active_status <> 'Y'
    and in_active_status <> 'N' then
    set err_msg := concat(err_msg,'Invalid active status,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  INSERT INTO sms_mst_tsmstemplatefield
  (
    smstemplate_gid,
    field_name,
    active_status,
    insert_date,
    insert_by
  )
  VALUES
  (
    in_smstemplate_gid,
    in_field_name,
    in_active_status,
    sysdate(),
    in_action_by
  );

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;