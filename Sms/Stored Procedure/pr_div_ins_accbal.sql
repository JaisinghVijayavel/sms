DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_ins_accbal $$
CREATE PROCEDURE pr_div_ins_accbal(
  in in_file_gid int,
  in in_tran_date date,
  in in_acc_no varchar(16),
  in in_acc_balance decimal(15,2),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_accbal_gid int;

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

  if not exists(select acc_no from div_mst_tacc
    where acc_no = in_acc_no
    and active_flag = 'Y'
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid a/c no,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

 -- duplicate checking
  if exists(select accbal_gid from div_trn_taccbal
    where acc_no = in_acc_no
    and tran_date = in_tran_date
    and delete_flag = 'N') then

    select accbal_gid into v_accbal_gid from div_trn_taccbal
    where acc_no = in_acc_no
    and tran_date = in_tran_date
    and delete_flag = 'N' limit 0,1;

    START TRANSACTION;

    update div_trn_taccbal set
    tran_date = in_tran_date,
    acc_no = in_acc_no,
    acc_balance = in_acc_balance
    where accbal_gid = v_accbal_gid
    and delete_flag = 'N';

    COMMIT;
  else
    START TRANSACTION;

    insert into div_trn_taccbal (file_gid,tran_date,acc_no,acc_balance)
    values (in_file_gid,in_tran_date,in_acc_no,in_acc_balance);

    COMMIT;
  end if;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;