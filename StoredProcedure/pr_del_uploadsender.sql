DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_del_uploadsender` $$

CREATE PROCEDURE `pr_del_uploadsender`(
  in in_upload_gid int,
  in in_sender_gid int,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_upload_created tinyint default 1;
  declare v_upload_deleted tinyint default 2;
  declare v_sms_upload tinyint default 1;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if not exists(select upload_gid from sms_trn_tupload
    where upload_gid = in_upload_gid
    and upload_status = v_upload_created
    and delete_flag = 'N') then
    set err_msg  := concat(err_msg,'Invalid upload,');
    set err_flag := true;
  end if;

  if exists(select tran_gid from sms_trn_ttran
    where upload_gid = in_upload_gid
    and sender_gid = in_sender_gid
    and sms_status <> v_sms_upload
    and delete_flag = 'N') then
    set err_msg  := concat(err_msg,'Access denied');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  update sms_trn_tuploadsender set
    upload_status = upload_status | v_upload_deleted,
    update_date = sysdate(),
    update_by = in_action_by
  where upload_gid = in_upload_gid
  and sender_gid = in_sender_gid
  and upload_status = v_upload_created
  and delete_flag = 'N';

  update sms_trn_ttran set
    upload_gid = 0,
    sms_status = 0
  where upload_gid = in_upload_gid
  and sender_gid = in_sender_gid
  and sms_status = v_sms_upload
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;