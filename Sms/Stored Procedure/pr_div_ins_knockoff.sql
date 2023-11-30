DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_ins_knockoff $$
CREATE PROCEDURE pr_div_ins_knockoff(
  in in_knockoff_amount decimal(15,2),
  in in_tran_dr_gid int,
  in in_tran_cr_gid int,
  in in_knockoff_type int,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10),
  out out_knockoff_gid int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_dr_acc_no varchar(16);
  declare v_dr_excp_amount double(15,2) default 0;
  declare v_cr_acc_no varchar(16);
  declare v_cr_excp_amount double(15,2) default 0;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  -- validation
  if in_knockoff_amount <= 0 then
    set err_msg := concat(err_msg,'Invalid knockoff amount,');
    set err_flag := true;
  end if;

  if in_tran_dr_gid <= 0 then
    set err_msg := concat(err_msg,'Invalid tran dr gid,');
    set err_flag := true;
  end if;

  if in_tran_cr_gid <= 0 then
    set err_msg := concat(err_msg,'Invalid tran cr gid,');
    set err_flag := true;
  end if;

  select acc_no,excp_amount into v_dr_acc_no,v_dr_excp_amount from div_trn_ttran
  where tran_gid = in_tran_dr_gid
  and delete_flag = 'N';

  if v_dr_excp_amount < in_knockoff_amount then
    set err_msg := concat(err_msg,'DR exception not available,');
    set err_flag := true;
  end if;

  select acc_no,excp_amount into v_cr_acc_no,v_cr_excp_amount from div_trn_ttran
  where tran_gid = in_tran_cr_gid
  and delete_flag = 'N';

  if v_cr_excp_amount < in_knockoff_amount then
    set err_msg := concat(err_msg,'CR exception not available,');
    set err_flag := true;
  end if;

  if v_dr_acc_no <> v_cr_acc_no then
    set err_msg := concat(err_msg,'A/C no mismatch,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  insert into div_trn_tknockoff
  (knockoff_date,knockoff_amount,tran_dr_gid,tran_cr_gid,knockoff_type,insert_date,insert_by) values
  (curdate(),in_knockoff_amount,in_tran_dr_gid,in_tran_cr_gid,in_knockoff_type,sysdate(),in_action_by);

  update div_trn_ttran set
  excp_amount = excp_amount - in_knockoff_amount,
  mapped_amount = mapped_amount + in_knockoff_amount 
  where tran_gid in (in_tran_dr_gid,in_tran_cr_gid)
  and excp_amount >= in_knockoff_amount
  and delete_flag = 'N';

  select max(knockoff_gid) into out_knockoff_gid from div_trn_tknockoff;

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;