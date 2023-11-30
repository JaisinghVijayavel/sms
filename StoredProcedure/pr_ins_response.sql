DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_ins_response` $$

CREATE PROCEDURE `pr_ins_response`(
  in in_file_gid int,
  in in_sender_gid int,
  in in_mobile_no varchar(16),
  in in_response_txt text,
  in in_response_date datetime,
  out out_msg text,
  out out_result int(10)
)
me:BEGIN

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
    and delete_flag = 'N') then
    set err_msg  := concat(err_msg,'Invalid file,');
    set err_flag := true;
  end if;

  if not exists(select sender_gid from sms_mst_tsender
    where sender_gid = in_sender_gid
    and active_status = 'Y'
    and delete_flag = 'N') then
    set err_msg  := concat(err_msg,'Invalid sender,');
    set err_flag := true;
  end if;

  set in_response_txt = trim(in_response_txt);

  if in_response_txt <> 'NO' then
    set err_msg  := concat(err_msg,'Invalid response text,');
    set err_flag := true;
  end if;

  if in_response_date is null or day(in_response_date) = 1 then
    set err_msg  := concat(err_msg,'Invalid response date,');
    set err_flag := true;
  elseif datediff(in_response_date,sysdate()) > 0 then
    set err_msg  := concat(err_msg,'Future response date,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  INSERT INTO sms_trn_tresponse
  (
    file_gid,
    sender_gid,
    mobile_no,
    response_txt,
    response_date
  )
  VALUES
  (
    in_file_gid,
    in_sender_gid,
    in_mobile_no,
    in_response_txt,
    in_response_date
  );

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;