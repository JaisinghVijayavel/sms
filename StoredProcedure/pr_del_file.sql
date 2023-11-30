DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_del_file` $$

CREATE PROCEDURE `pr_del_file`(
  in in_file_gid int,
  in in_file_type char(1),
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare v_file_deleted int default 2;
  declare err_msg text default '';
  declare err_flag boolean default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if not exists(select file_gid from sms_trn_tfile
    where file_gid = in_file_gid
    and file_type = in_file_type 
    and delete_flag = 'N') then
    set err_msg  := concat(err_msg,'Invalid file !');
    set err_flag := true;
  end if;

  if in_file_type = 'S' then
    if exists(select file_gid from sms_trn_ttran
      where file_gid = in_file_gid
      and upload_gid > 0
      and delete_flag = 'N') then
      set err_msg  := concat(err_msg,'Access denied !');
      set err_flag := true;
    end if;
  elseif in_file_type = 'R' then
    if exists(select file_gid from sms_trn_tresponse
      where file_gid = in_file_gid
      and tran_gid > 0
      and delete_flag = 'N') then
      set err_msg  := concat(err_msg,'Access denied !');
      set err_flag := true;
    end if;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  if in_file_type = 'S' then
    update sms_trn_ttran set
      delete_flag = 'Y'
    where file_gid = in_file_gid
    and upload_gid = 0
    and delete_flag = 'N';
  elseif in_file_type = 'R' then
    update sms_trn_tresponse set
      delete_flag = 'Y'
    where file_gid = in_file_gid
    and tran_gid = 0
    and delete_flag = 'N';
  end if;

  update sms_trn_tfile set
    update_date = sysdate(),
    update_by = in_action_by,
    file_status = file_status | v_file_deleted
  where file_gid = in_file_gid
  and file_type = in_file_type
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'File deleted successfully !';
 END $$

DELIMITER ;