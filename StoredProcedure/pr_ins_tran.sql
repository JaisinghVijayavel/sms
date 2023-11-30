DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_ins_tran` $$

CREATE PROCEDURE `pr_ins_tran`(
  in in_file_gid int,
  in in_sender_gid int,
  in in_smstemplate_gid int,
  in in_sms_template_id varchar(32),
  in in_mobile_no varchar(16),
  in in_sms_txt text,
  in in_ref_col1 varchar(255),
  in in_ref_col2 varchar(255),
  in in_ref_col3 varchar(255),
  in in_ref_col4 varchar(255),
  in in_ref_col5 varchar(255),
  in in_ref_col6 varchar(255),
  in in_ref_col7 varchar(255),
  in in_ref_col8 varchar(255),
  in in_ref_col9 varchar(255),
  in in_ref_col10 varchar(255),
  in in_ref_col11 varchar(255),
  in in_ref_col12 varchar(255),
  in in_ref_col13 varchar(255),
  in in_ref_col14 varchar(255),
  in in_ref_col15 varchar(255),
  in in_ref_col16 varchar(255),
  in in_ref_col17 varchar(255),
  in in_ref_col18 varchar(255),
  in in_ref_col19 varchar(255),
  in in_ref_col20 varchar(255),
  in in_ref_col21 varchar(255),
  in in_ref_col22 varchar(255),
  in in_ref_col23 varchar(255),
  in in_ref_col24 varchar(255),
  in in_ref_col25 varchar(255),
  in in_ref_col26 varchar(255),
  in in_ref_col27 varchar(255),
  in in_ref_col28 varchar(255),
  in in_ref_col29 varchar(255),
  in in_ref_col30 varchar(255),
  in in_ref_col31 varchar(255),
  in in_ref_col32 varchar(255),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_sms_length int default 0;
  declare v_sms_count int default 0;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;

  set in_sms_template_id = ifnull(in_sms_template_id,'');

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

  if in_smstemplate_gid > 0 then
    if not exists(select smstemplate_gid from sms_mst_tsmstemplate
      where smstemplate_gid = in_smstemplate_gid
      and active_status = 'Y'
      and delete_flag = 'N') then
      set err_msg  := concat(err_msg,'Invalid sms template,');
      set err_flag := true;
    end if;
  end if;

  if in_sms_template_id = '' then
    set err_msg  := concat(err_msg,'Sms template id cannot be blank,');
    set err_flag := true;
  end if;

  -- length of sms
  set v_sms_length = length(in_sms_txt);

  if v_sms_length > 0 then
    if v_sms_length > 1377 then
      set err_msg  := concat(err_msg,'sms length exceeds length 1377,');
      set err_flag := true;
    else
      select msg_count into v_sms_count from  sms_mst_tmessage
        where v_sms_length between msg_start and msg_end
        and delete_flag = 'N';
    end if;
  else
      set err_msg  := concat(err_msg,'sms cannot be blank,');
      set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  INSERT INTO sms_trn_ttran
  (
    file_gid,
    sender_gid,
    smstemplate_gid,
    sms_template_id,
    mobile_no,
    sms_txt,
    sms_length,
    sms_count,
    ref_col1,
    ref_col2,
    ref_col3,
    ref_col4,
    ref_col5,
    ref_col6,
    ref_col7,
    ref_col8,
    ref_col9,
    ref_col10,
    ref_col11,
    ref_col12,
    ref_col13,
    ref_col14,
    ref_col15,
    ref_col16,
    ref_col17,
    ref_col18,
    ref_col19,
    ref_col20,
    ref_col21,
    ref_col22,
    ref_col23,
    ref_col24,
    ref_col25,
    ref_col26,
    ref_col27,
    ref_col28,
    ref_col29,
    ref_col30,
    ref_col31,
    ref_col32
  )
  VALUES
  (
    in_file_gid,
    in_sender_gid,
    in_smstemplate_gid,
    in_sms_template_id,
    in_mobile_no,
    in_sms_txt,
    v_sms_length,
    v_sms_count,
    in_ref_col1,
    in_ref_col2,
    in_ref_col3,
    in_ref_col4,
    in_ref_col5,
    in_ref_col6,
    in_ref_col7,
    in_ref_col8,
    in_ref_col9,
    in_ref_col10,
    in_ref_col11,
    in_ref_col12,
    in_ref_col13,
    in_ref_col14,
    in_ref_col15,
    in_ref_col16,
    in_ref_col17,
    in_ref_col18,
    in_ref_col19,
    in_ref_col20,
    in_ref_col21,
    in_ref_col22,
    in_ref_col23,
    in_ref_col24,
    in_ref_col25,
    in_ref_col26,
    in_ref_col27,
    in_ref_col28,
    in_ref_col29,
    in_ref_col30,
    in_ref_col31,
    in_ref_col32
  );

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;