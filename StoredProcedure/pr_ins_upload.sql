DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_ins_upload` $$

CREATE PROCEDURE `pr_ins_upload`(
  in in_upload_code varchar(128),
  in in_upload_sno int,
  in in_action_by varchar(16),
  out out_upload_gid int,
  out out_msg text,
  out out_result int(10)
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_upload_created tinyint default 1;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if in_upload_code = '' then
    set err_msg := concat(err_msg,'Invalid upload code,');
    set err_flag := true;
  end if;

  if in_upload_sno = 0 then
    set err_msg := concat(err_msg,'Invalid upload sno,');
    set err_flag := true;
  end if;

  if exists(select upload_gid from sms_trn_tupload
    where upload_sno = in_upload_sno
    and delete_flag = 'N') then
    set err_msg  := concat(err_msg,'Upload already exists');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  INSERT INTO sms_trn_tupload
  (
    upload_date,
    upload_code,
    upload_sno,
    upload_status,
    insert_date,
    insert_by
  )
  VALUES
  (
    curdate(),
    in_upload_code,
    in_upload_sno,
    v_upload_created,
    sysdate(),
    in_action_by
  );

  COMMIT;

  select max(upload_gid) into out_upload_gid from sms_trn_tupload;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;