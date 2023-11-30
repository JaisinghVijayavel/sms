DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_ins_xltemplate` $$
CREATE PROCEDURE `pr_div_ins_xltemplate`(
  in in_xltemplate_gid int,
  in in_xltemplate_name varchar(64),
  in in_filetype int,
  in in_action_by varchar(10),
  out out_xltemplate_gid int,
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

  set in_xltemplate_gid = ifnull(in_xltemplate_gid,0);

  if in_xltemplate_name = '' then
    set err_msg := concat(err_msg,'Blank template name,');
    set err_flag := true;
  end if;

  if not exists(select filetype_value from div_mst_tfiletype
    where filetype_value = in_filetype
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid file type,');
    set err_flag := true;
  end if;

  if in_xltemplate_gid = 0 then
    if exists(select xltemplate_gid from div_mst_txltemplate
      where xltemplate_name = in_xltemplate_name
      and filetype_value = in_filetype
      and delete_flag = 'N') then
      set err_msg  := concat(err_msg,'Template already exists');
      set err_flag := true;
    end if;
  else
    if exists(select xltemplate_gid from div_mst_txltemplate
      where xltemplate_name = in_xltemplate_name
      and filetype_value = in_filetype
      and xltemplate_gid <> in_xltemplate_gid
      and delete_flag = 'N') then
      set err_msg  := concat(err_msg,'Template already exists');
      set err_flag := true;
    end if;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  if in_xltemplate_gid = 0 then
    INSERT INTO div_mst_txltemplate(filetype_value,xltemplate_name,insert_date,insert_by)
    VALUES(in_filetype,in_xltemplate_name,sysdate(),in_action_by);

    select max(xltemplate_gid) into out_xltemplate_gid from div_mst_txltemplate;
  else
    update div_mst_txltemplate set
      filetype_value = in_filetype,
      xltemplate_name = in_xltemplate_name,
      update_date = sysdate(),
      update_by = in_action_by
    where xltemplate_gid = in_xltemplate_gid
    and delete_flag = 'N';

    set out_xltemplate_gid = in_xltemplate_gid;
  end if;

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;