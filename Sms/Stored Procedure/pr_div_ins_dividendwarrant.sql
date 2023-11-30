DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_ins_dividendwarrant $$
CREATE PROCEDURE pr_div_ins_dividendwarrant(
  in in_file_gid int,
  in in_folio_no varchar(64),
  in in_acc_no varchar(16),
  in in_ben_name varchar(128),
  in in_div_amount double(15,2),
  in in_share_count int,
  in in_share_value double(15,2),
  in in_val_date date,
  in in_div_pay_mode char(1),
  in in_warrant_no varchar(32),
  in in_ref_no varchar(32),
  in in_ben_acc_no varchar(32),
  in in_ben_ifsc_code varchar(32),
  in in_ben_add1 varchar(64),
  in in_ben_add2 varchar(64),
  in in_ben_add3 varchar(64),
  in in_ben_add4 varchar(64),
  in in_ben_city varchar(64),
  in in_ben_pincode varchar(16),
  in in_ben_email_id varchar(64),
  in in_div_remark varchar(255),
  in in_line_no int,
  in in_errline_flag boolean,
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

    if in_errline_flag = true then
      call pr_div_ins_errline(in_file_gid,in_line_no,out_msg);
    end if;
  END;

  -- validation
  if in_file_gid = 0 then
    set err_msg := concat(err_msg,'Blank file Name,');
    set err_flag := true;
  end if;

  if in_folio_no = '' then
    set err_msg := concat(err_msg,'Blank folio no,');
    set err_flag := true;
  end if;

  if in_acc_no = '' then
    set err_msg := concat(err_msg,'Blank a/c no,');
    set err_flag := true;
  end if;

  if in_val_date is null then
    set err_msg := concat(err_msg,'Blank value date,');
    set err_flag := true;
  end if;

  if in_div_amount <= 0 then
    set err_msg := concat(err_msg,'Divident amount should be > 0,');
    set err_flag := true;
  end if;

  if not exists(select paymode_gid from div_mst_tpaymode
    where paymode_code = in_div_pay_mode
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid pay mode,');
    set err_flag := true;
  end if;

  if not exists(select acc_no from div_mst_tacc
    where acc_no = in_acc_no
    and active_flag = 'Y'
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid a/c no,');
    set err_flag := true;
  end if;

  -- duplicate checking
  if exists(select div_gid from div_trn_tdividend
    where folio_no = in_folio_no
    and warrant_no = in_warrant_no
    and acc_no = in_acc_no
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Duplicate record,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;

    if in_errline_flag = true then
      call pr_div_ins_errline(in_file_gid,in_line_no,out_msg);
    end if;

    leave me;
  end if;

  START TRANSACTION;

  insert into div_trn_tdividend
  (file_gid,folio_no,acc_no,ben_name,div_amount,share_count,share_value,val_date,div_pay_mode,ben_acc_no,
  ben_ifsc_code,ben_add1,ben_add2,ben_add3,ben_add4,ben_city,ben_pincode,ben_email_id,ref_no,warrant_no,div_remark) values
  (in_file_gid,in_folio_no,in_acc_no,in_ben_name,in_div_amount,in_share_count,in_share_value,in_val_date,in_div_pay_mode,
  in_ben_acc_no,in_ben_ifsc_code,in_ben_add1,in_ben_add2,in_ben_add3,in_ben_add4,in_ben_city,in_ben_pincode,in_ben_email_id,
  in_ref_no,in_warrant_no,in_div_remark);

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;