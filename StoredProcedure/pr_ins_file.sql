DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_ins_file` $$

CREATE PROCEDURE `pr_ins_file`(
  in in_file_name varchar(128),
  in in_sheet_name varchar(128),
  in in_sender_gid int,
  in in_file_type char(1),
  in in_field_property char(1),
  in in_xltemplate_gid int,
  in in_smstemplate_gid int,
  in in_action_by varchar(16),
  out out_file_gid int,
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare v_file_imported int default 1;
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

  if in_file_Name = '' then
    set err_msg := concat(err_msg,'Blank file Name,');
    set err_flag := true;
  end if;

  if in_sheet_Name = '' then
    set err_msg := concat(err_msg,'Blank sheet Name,');
    set err_flag := true;
  end if;

  if not exists(select file_type from sms_mst_tfiletype
    where file_type = in_file_type
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid file type,');
    set err_flag := true;
  end if;

  if not exists(select sender_gid from sms_mst_tsender
    where sender_gid = in_sender_gid
    and active_status = 'Y'
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid sender,');
    set err_flag := true;
  end if;

  if in_field_property <> 'S'
    and in_field_property <> 'V'
    and in_file_type = 'S' then
    set err_msg := concat(err_msg,'Invalid field property,');
    set err_flag := true;
  end if;

  if exists(select file_gid from sms_trn_tfile
    where file_name = in_file_name
    and sheet_name = in_sheet_name
    and file_type = in_file_type
    and delete_flag = 'N') then
    set err_msg  := concat(err_msg,'File already exists');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  INSERT INTO sms_trn_tfile
  (
    file_name,
    sheet_name,
    import_date,
    file_type,
    sender_gid,
    field_property,
    xltemplate_gid,
    smstemplate_gid,
    file_status,
    insert_date,
    insert_by
  )
  VALUES
  (
    in_file_name,
    in_sheet_name,
    curdate(),
    in_file_type,
    in_sender_gid,
    in_field_property,
    in_xltemplate_gid,
    in_smstemplate_gid,
    v_file_imported,
    sysdate(),
    in_action_by
  );

  COMMIT;

  select max(file_gid) into out_file_gid from sms_trn_tfile;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;