DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_ins_rejecttemplate $$
CREATE PROCEDURE pr_div_ins_rejecttemplate(
  in in_file_gid int,
  in in_folio_no varchar(64),
  in in_acc_no varchar(16),
  in in_ben_name varchar(128),
  in in_div_amount double(15,2),
  in in_val_date date,
  in in_pay_mode varchar(64),
  in in_batch_no varchar(32),
  in in_warrant_no varchar(32),
  in in_ref_no varchar(32),
  in in_crn_no varchar(64),
  in in_ben_acc_no varchar(32),
  in in_ben_ifsc_code varchar(32),
  in in_reject_code varchar(8),
  in in_reject_reason varchar(255),
  in in_stage varchar(64),
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

  set in_stage = upper(in_stage);

  if in_stage='RETURN' or in_stage = 'FAILED' or in_stage = 'CANCELINSTRUMENT' then

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

	  if in_folio_no = '' then
		set err_msg := concat(err_msg,'Blank folio no,');
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

	  -- duplicate checking
	  if exists(select reject_gid from div_trn_treject
		where folio_no = in_folio_no
		and acc_no = in_acc_no
		and val_date = in_val_date
		and ref_no = in_ref_no
		and div_amount = in_div_amount
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

	  insert into div_trn_treject
	  (file_gid,folio_no,acc_no,ben_name,div_amount,val_date,pay_mode,ref_no,ben_acc_no,
	  ben_ifsc_code,batch_no,warrant_no,crn_no,reject_code,reject_reason) values
	  (in_file_gid,in_folio_no,in_acc_no,in_ben_name,in_div_amount,in_val_date,in_pay_mode,
	  in_ref_no,in_ben_acc_no,in_ben_ifsc_code,in_batch_no,in_warrant_no,in_crn_no,in_reject_code,in_reject_reason);

	  COMMIT;

	  set out_result = 1;
	  set out_msg = 'Record updated successfully !';
  end if;
 END $$

DELIMITER ;