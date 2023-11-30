DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_del_uploadfile` $$

CREATE PROCEDURE `pr_del_uploadfile`(
  in in_upload_gid int,
  in in_uploadfile_gid int,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_upload_created tinyint default 1;
  declare v_uploadfile_created tinyint default 1;
  declare v_uploadfile_deleted tinyint default 2;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;

    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if not exists(select a.upload_gid from sms_trn_tuploadfile as a
    inner join sms_trn_tupload as b on a.upload_gid = a.upload_gid 
      and b.upload_status = v_upload_created
      and b.delete_flag = 'N'
    where a.uploadfile_gid = in_uploadfile_gid
    and a.uploadfile_status = v_uploadfile_created
    and a.delete_flag = 'N') then
    set err_msg  := concat(err_msg,'Access denied');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  update sms_trn_tuploadfile set
    uploadfile_status = uploadfile_status | v_uploadfile_deleted,
    update_date = sysdate(),
    update_by = in_action_by
  where upload_gid = in_upload_gid
  and uploadfile_status = v_uploadfile_created
  and delete_flag = 'N';

  update sms_trn_ttran set
    upload_gid = 0,
    uploadfile_gid = 0
  where upload_gid = in_upload_gid
  and uploadfile_gid = in_uploadfile_gid
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;