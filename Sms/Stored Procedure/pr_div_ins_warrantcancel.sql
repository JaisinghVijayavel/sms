DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_ins_warrantcancel $$
CREATE PROCEDURE pr_div_ins_warrantcancel(
  in in_file_gid int,
  in in_folio_no varchar(64),
  in in_acc_no varchar(16),
  in in_ben_name varchar(128),
  in in_warrant_date date,
  in in_warrant_no varchar(16),
  in in_chq_no varchar(16),
  in in_warrant_amount double(15,2),
  in in_cancel_date date,
  in in_cancel_remark varchar(255),
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

  if in_warrant_date is null then
    set err_msg := concat(err_msg,'Blank warrant date,');
    set err_flag := true;
  end if;

  if in_warrant_no = '' then
    set err_msg := concat(err_msg,'Blank warrant no,');
    set err_flag := true;
  end if;

  if in_chq_no = '' then
    set err_msg := concat(err_msg,'Blank cheque no,');
    set err_flag := true;
  end if;

  if in_cancel_date is null then
    set err_msg := concat(err_msg,'Blank cancel date,');
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
  if exists(select warrantcancel_gid from div_trn_twarrantcancel
    where folio_no = in_folio_no
    and acc_no = in_acc_no
    and warrant_no = in_warrant_no
    and delete_flag = 'N') then

    set err_msg := concat(err_msg,'Duplicate record,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  insert into div_trn_twarrantcancel
  (file_gid,folio_no,acc_no,ben_name,warrant_date,warrant_no,chq_no,warrant_amount,
  cancel_date,cancel_remark) value
  (in_file_gid,in_folio_no,in_acc_no,in_ben_name,in_warrant_date,in_warrant_no,in_chq_no,
  in_warrant_amount,in_cancel_date,in_cancel_remark);

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;