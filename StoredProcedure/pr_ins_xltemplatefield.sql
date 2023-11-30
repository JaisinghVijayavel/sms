DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_ins_xltemplatefield` $$

CREATE PROCEDURE `pr_ins_xltemplatefield`(
  in in_xltemplate_gid int,
  in in_xlcolumn_name varchar(128),
  in in_field_name varchar(128),
  in in_mandatory_flag char(1),
  in in_field_format varchar(32),
  in in_field_length smallint,
  in in_field_default_value varchar(255),
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

  if not exists(select xltemplate_gid from sms_mst_txltemplate
    where xltemplate_gid = in_xltemplate_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid xltemplate name,');
    set err_flag := true;
  end if;

  if in_xlcolumn_Name = '' then
    set err_msg := concat(err_msg,'Blank xl column name,');
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

  if in_field_length < 0 then
    set err_msg := concat(err_msg,'Invalid field length,');
    set err_flag := true;
  end if;

  if in_active_status <> 'Y'
    and in_active_status <> 'N' then
    set err_msg := concat(err_msg,'Invalid active status,');
    set err_flag := true;
  end if;

  if in_mandatory_flag <> 'Y'
    and in_mandatory_flag <> 'N' then
    set err_msg := concat(err_msg,'Invalid mandatory flag,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  INSERT INTO sms_mst_txltemplatefield
  (
    xltemplate_gid,
    xlcolumn_name,
    field_name,
    mandatory_flag,
    field_format,
    field_length,
    field_default_value,
    active_status,
    insert_date,
    insert_by
  )
  VALUES
  (
    in_xltemplate_gid,
    in_xlcolumn_name,
    in_field_name,
    in_mandatory_flag,
    in_field_format,
    in_field_length,
    in_field_default_value,
    in_active_status,
    sysdate(),
    in_action_by 
  );

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;