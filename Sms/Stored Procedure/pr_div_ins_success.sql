DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_ins_success $$
CREATE PROCEDURE pr_div_ins_success(
  in in_file_gid int,
  in in_folio_no varchar(64),
  in in_acc_no varchar(16),
  in in_ben_name varchar(128),
  in in_div_amount double(15,2),
  in in_share_count int,
  in in_share_value double(15,2),
  in in_val_date date,
  in in_pay_mode varchar(64),
  in in_ben_acc_no varchar(32),
  in in_ben_ifsc_code varchar(32),
  in in_ben_add1 varchar(64),
  in in_ben_add2 varchar(64),
  in in_ben_add3 varchar(64),
  in in_ben_add4 varchar(64),
  in in_ben_city varchar(64),
  in in_ben_pincode varchar(16),
  in in_ben_email_id varchar(64),
  in in_batch_no varchar(32),
  in in_chq_no varchar(16),
  in in_ref_no varchar(32),
  in in_warrant_no varchar(32),
  in in_success_remark varchar(255),
  in in_line_no int,
  in in_errline_flag boolean,
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_prev_success_gid int default 0;
  declare v_next_success_gid int default 0;
  declare v_reject_gid int default 0;
  declare v_prev_paymode char(1);
  declare v_count int default 0;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;

    if in_errline_flag = true then
      call pr_div_ins_errline(in_file_gid,in_line_no,out_msg);
    end if;
  END;

  -- retrieve pay_mode
  set in_pay_mode = replace(upper(in_pay_mode),' ','');

  if in_pay_mode = 'DD' or in_pay_mode = 'DEMANDDRAFT' then
    set in_pay_mode = 'D';
  end if;

  if in_pay_mode = 'NEFT' then
    set in_pay_mode = 'N';
  end if;

  if in_pay_mode = 'INTERNALFUNDTRANSFER' then
    set in_pay_mode = 'I';
  end if;

  if in_pay_mode = 'RTGS' then
    set in_pay_mode = 'R';
  end if;

  set in_pay_mode = mid(in_pay_mode,1,1);

  -- validation
  if in_file_gid = 0 then
    set err_msg := concat(err_msg,'Blank file Name,');
    set err_flag := true;
  end if;

  if in_acc_no = '' then
    set err_msg := concat(err_msg,'Blank a/c no,');
    set err_flag := true;
  end if;

  if in_val_date = '0001-01-01' then
    set err_msg := concat(err_msg,'Invalid value date,');
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
    where paymode_code = in_pay_mode
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

  if in_folio_no = '' and in_warrant_no <> '' and err_flag = false then
    select folio_no into in_folio_no from div_trn_tdividend
    where acc_no = in_acc_no
    and warrant_no = in_warrant_no
    and delete_flag = 'N';
  end if;

  if in_folio_no = '' then
    set err_msg := concat(err_msg,'Blank folio no,');
    set err_flag := true;
  end if;

  -- duplicate checking
  if exists(select success_gid from div_trn_tsuccess
    where (folio_no = in_folio_no or folio_no = in_warrant_no)
    and acc_no = in_acc_no
    and div_amount = in_div_amount 
    and val_date = in_val_date
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

  -- find previous success
  select success_gid,pay_mode,reject_gid into v_prev_success_gid,v_prev_paymode,v_reject_gid from div_trn_tsuccess
  where (folio_no = in_folio_no or folio_no = in_warrant_no)
  and acc_no = in_acc_no
  and div_amount = in_div_amount 
  and next_success_gid = 0
  and delete_flag = 'N';

  if v_prev_success_gid > 0 then
    if v_reject_gid = 0 then
      set err_msg := concat(err_msg,'Reject not mapped for previous success line,');

      set out_result = 0;
      set out_msg = err_msg;

      if in_errline_flag = true then
        call pr_div_ins_errline(in_file_gid,in_line_no,out_msg);
      end if;

      leave me;
    end if;
  else
    set v_prev_paymode = in_pay_mode;
  end if;

  START TRANSACTION;

  insert into div_trn_tsuccess
  (file_gid,folio_no,acc_no,ben_name,div_amount,share_count,share_value,val_date,pay_mode,ben_acc_no,
  ben_ifsc_code,ben_add1,ben_add2,ben_add3,ben_add4,ben_city,ben_pincode,ben_email_id,
  ref_no,batch_no,chq_no,warrant_no,success_remark,prev_success_gid,prev_pay_mode,next_pay_mode) values
  (in_file_gid,in_folio_no,in_acc_no,in_ben_name,in_div_amount,in_share_count,in_share_value,in_val_date,in_pay_mode,
  in_ben_acc_no,in_ben_ifsc_code,in_ben_add1,in_ben_add2,in_ben_add3,in_ben_add4,in_ben_city,in_ben_pincode,in_ben_email_id,
  in_ref_no,in_batch_no,in_chq_no,in_warrant_no,in_success_remark,v_prev_success_gid,v_prev_paymode,in_pay_mode);

  if v_prev_success_gid > 0 then
    select max(success_gid) into v_next_success_gid from div_trn_tsuccess;

    update div_trn_tsuccess set
    next_success_gid = v_next_success_gid,
    next_pay_mode = in_pay_mode
    where success_gid = v_prev_success_gid
    and next_success_gid = 0
    and delete_flag = 'N';
  end if;

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;