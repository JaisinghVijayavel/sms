DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_set_uploadtran` $$

CREATE PROCEDURE `pr_set_uploadtran`(
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
  declare v_sms_upload int default 1;

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
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid upload gid,');
    set err_flag := true;
  end if;

  if not exists(select sender_gid from sms_mst_tsender
    where sender_gid = in_sender_gid
    and active_status = 'Y'
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid sender gid,');
    set err_flag := true;
  end if;

  if not exists(select sender_gid from sms_trn_ttran
    where sender_gid = in_sender_gid
    and upload_gid = 0
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Record not found,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  update sms_trn_ttran set
    upload_gid = in_upload_gid,
    sms_status = v_sms_upload
  where sender_gid = in_sender_gid
  and upload_gid = 0
  and sms_status = 0
  and delete_flag = 'N';

  insert sms_trn_tuploadsender
  (
    upload_gid,
    sender_gid,
    upload_status,
    insert_date,
    insert_by
  )
  values
  (
    in_upload_gid,
    in_sender_gid,
    v_upload_created,
    sysdate(),
    in_action_by 
  );

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;