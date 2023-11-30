DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_ins_filenew $$
CREATE PROCEDURE pr_div_ins_filenew(
  in in_file_name varchar(50),
  in in_sheet_name varchar(50),
  in in_file_type tinyint(3),
  in in_filesub_type smallint,
  in in_xltemplate_gid int,
  in in_action_by varchar(10),
  out out_file_gid int,
  out out_msg text,
  out out_result int(10)
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag varchar(10) default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  -- validation
  if in_file_Name = '' then
    set err_msg := concat(err_msg,'Blank file Name,');
    set err_flag := true;
  end if;

  if not exists(select filetype_value from div_mst_tfiletype
    where filetype_value = in_file_type
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid file type,');
    set err_flag := true;
  end if;

 -- duplicate checking
  if exists(select file_gid from div_trn_tfile
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

  INSERT INTO div_trn_tfile(file_name,sheet_name,file_type,filesub_type,xltemplate_gid,insert_date,insert_by)
  VALUES(in_file_name,in_sheet_name,in_file_type,in_filesub_type,in_xltemplate_gid,sysdate(),in_action_by);

  COMMIT;

  select max(file_gid) into out_file_gid from div_trn_tfile;
  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;