DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_upd_smssend` $$

CREATE PROCEDURE `pr_upd_smssend`(
  in in_tran_gid int,
  in in_sms_status int,
  in in_err_code varchar(8),
  in in_job_id varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_sms_upload int default 1;
  declare v_sms_success int default 2;
  declare v_sms_failed int default 4;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;

  START TRANSACTION;

  update sms_trn_ttran set
    send_date = sysdate(),
    sms_status = sms_status | in_sms_status,
    err_code = in_err_code,
    job_id = in_job_id
  where tran_gid = in_tran_gid
  and sms_status & v_sms_upload > 0
  and sms_status & v_sms_success = 0
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;