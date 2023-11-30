DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_upd_xltemplate` $$

CREATE PROCEDURE `pr_upd_xltemplate`(
  in in_xltemplate_gid int,
  in in_xltemplate_name varchar(128),
  in in_field_property char(1),
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

  if in_xltemplate_Name = '' then
    set err_msg := concat(err_msg,'Blank xltemplate name,');
    set err_flag := true;
  end if;

  if in_field_property <> 'V'
    and in_field_property <> 'S'
    and in_field_property <> 'C' then
    set err_msg := concat(err_msg,'Invalid field property,');
    set err_flag := true;
  end if;

  if in_active_status <> 'Y'
    and in_active_status <> 'N' then
    set err_msg := concat(err_msg,'Invalid active status,');
    set err_flag := true;
  end if;

  if not exists(select xltemplate_gid from sms_mst_txltemplate
    where xltemplate_gid = in_xltemplate_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid xl template,');
    set err_flag := true;
  end if;

  if exists(select xltemplate_gid from sms_mst_txltemplate
    where xltemplate_name = in_xltemplate_name
    and xltemplate_gid <> in_xltemplate_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Xltemplate name already exists,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  update sms_mst_txltemplate set
    xltemplate_name = in_xltemplate_name,
    field_property = in_field_property,
    active_status = in_active_status,
    update_date = sysdate(),
    update_by = in_action_by
  where xltemplate_gid = in_xltemplate_gid
  and delete_flag = 'N';

  update sms_mst_txltemplatefield set
    delete_flag = 'Y',
    update_date = sysdate(),
    update_by = in_action_by
  where xltemplate_gid = in_xltemplate_gid
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;