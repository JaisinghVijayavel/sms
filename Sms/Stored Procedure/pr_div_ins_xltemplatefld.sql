DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_ins_xltemplatefld` $$
CREATE PROCEDURE `pr_div_ins_xltemplatefld`(
  in in_xltemplate_gid int,
  in in_xltemplatefld_name varchar(64),
  in in_filetypefld_gid int,
  in in_disp_order int,
  out out_xltemplatefld_gid int,
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
  set in_filetypefld_gid = ifnull(in_filetypefld_gid,0);
  set in_disp_order = ifnull(in_disp_order,0);

  if in_xltemplatefld_name = '' then
    set err_msg := concat(err_msg,'Blank template field name,');
    set err_flag := true;
  end if;

  if in_xltemplate_gid = 0 then
    set err_msg := concat(err_mst,'template gid cannot be zero,');
    set err_flag := true;
  end if;

  if in_filetypefld_gid = 0 then
    set err_msg := concat(err_msg,'filetype gid cannot be zero,');
    set err_flag := true;
  end if;

  if exists(select xltemplatefld_gid from div_mst_txltemplatefld
    where xltemplate_gid = in_xltemplate_gid
    and xltemplatefld_name = in_xltemplatefld_name
    and delete_flag = 'N') then
    set err_msg  := concat(err_msg,'Template field already exists,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  INSERT INTO div_mst_txltemplatefld(xltemplate_gid,xltemplatefld_name,filetypefld_gid,disp_order)
  VALUES(in_xltemplate_gid,in_xltemplatefld_name,in_filetypefld_gid,in_disp_order);

  select max(xltemplatefld_gid) into out_xltemplatefld_gid from div_mst_txltemplatefld;

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;