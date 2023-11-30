DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_ins_tran $$
CREATE PROCEDURE pr_div_ins_tran(
  in in_file_gid int,
  in in_tran_date date,
  in in_acc_no varchar(16),
  in in_tran_desc varchar(255),
  in in_tran_amount double(15,2),
  in in_balance_flag boolean,
  in in_balance_amount double(15,2),
  in in_acc_mode char(1),
  in in_ref_no varchar(64),
  in in_tran_ref_id varchar(32),
  in in_tran_psrl varchar(16),
  in in_tran_isid varchar(16),
  in in_tran_remark1 varchar(255),
  in in_dedup_flag boolean,
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_mult tinyint;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  -- validation
  if in_file_gid = 0 then
    set err_msg := concat(err_msg,'Blank file Name,');
    set err_flag := true;
  end if;

  if in_tran_date is null then
    set err_msg := concat(err_msg,'Blank transaction date,');
    set err_flag := true;
  end if;

  if in_acc_no = '' then
    set err_msg := concat(err_msg,'Blank a/c no,');
    set err_flag := true;
  end if;

  if in_tran_amount <= 0 then
    set err_msg := concat(err_msg,'Amount should be > 0,');
    set err_flag := true;
  end if;

  if in_acc_mode <> 'C' and in_acc_mode <> 'D' then
    set err_msg := concat(err_msg,'Invalid a/c mode,');
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
  if in_dedup_flag = true then
    if exists(select tranacc_gid from div_trn_ttranacc
      where tran_date = in_tran_date
      and acc_no = in_acc_no
      and file_gid <> in_file_gid
      and delete_flag = 'N') then

      set out_result = -1;
      set out_msg = concat('Import failed, record already available for a/c ',in_acc_no,', date ',in_tran_date);
      leave me;
    end if;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  if in_acc_mode = 'D' then
    set v_mult = -1;
  else
    set v_mult = 1;
  end if;

  START TRANSACTION;

  insert into div_trn_ttran
  (file_gid,tran_date,acc_no,tran_desc,tran_amount,excp_amount,mapped_amount,acc_mode,mult,tran_ref_id,
  tran_psrl,tran_isid,ref_no,tran_remark1) values
  (in_file_gid,in_tran_date,in_acc_no,in_tran_desc,in_tran_amount,in_tran_amount,0,in_acc_mode,v_mult,in_tran_ref_id,
  in_tran_psrl,in_tran_isid,in_ref_no,in_tran_remark1);

  if in_balance_flag = true then
    call pr_div_ins_accbal(in_file_gid,in_tran_date,in_acc_no,in_balance_amount,out_msg,out_result);
  end if;

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;