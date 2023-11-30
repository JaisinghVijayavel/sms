DELIMITER $$

drop procedure if exists pr_div_set_map_rejectfinacle$$

CREATE PROCEDURE pr_div_set_map_rejectfinacle(
  in in_reject_gid int,
  in in_tran_gid int,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_acc_no varchar(16);
  declare v_div_amount double;
  declare v_tran_date date;
  declare v_reject_status tinyint default 0;
  declare v_success_status tinyint default 0;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  -- find reject status
  select status_value into v_reject_status from div_mst_tstatus
  where status_desc = 'Reject'
  and delete_flag = 'N';

  -- find success status
  select status_value into v_success_status from div_mst_tstatus
  where status_desc = 'Success'
  and delete_flag = 'N';

  if v_reject_status = 0 then
    set out_msg = 'Reject status not available in status table';
    set out_result = 0;
    leave me;
  end if;

  if v_success_status = 0 then
    set out_msg = 'Success status not available in status table';
    set out_result = 0;
    leave me;
  end if;

  if not exists(select reject_gid from div_trn_treject
    where reject_gid = in_reject_gid
    and div_gid > 0
    and tran_cr_gid = 0
    and delete_flag = 'N') then 
    set out_msg = 'Access denied !';
    set out_result = 0;
    leave me;
  end if;

  select div_amount,acc_no into v_div_amount,v_acc_no from div_trn_treject
  where reject_gid = in_reject_gid
  and div_gid > 0
  and tran_cr_gid = 0
  and delete_flag = 'N';

  if not exists(select tran_gid from div_trn_ttran
    where tran_gid = in_tran_gid
    and tran_amount = v_div_amount
    and acc_mode = 'C'
    and acc_no = v_acc_no
    and mapped_amount = 0
    and delete_flag = 'N') then
    set out_msg = 'Access denied !';
    set out_result = 0;
    leave me;
  end if;

  select tran_date into v_tran_date from div_trn_ttran
  where tran_gid = in_tran_gid
  and tran_amount = v_div_amount
  and acc_mode = 'C'
  and acc_no = v_acc_no
  and mapped_amount = tran_amount
  and delete_flag = 'N';

  start transaction;

  update div_trn_ttran set mapped_amount = tran_amount
  where tran_gid = in_tran_gid
  and tran_amount = v_div_amount
  and acc_mode = 'C'
  and acc_no = v_acc_no
  and mapped_amount = 0
  and delete_flag = 'N';

  update div_trn_treject as a
  inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
  inner join div_trn_tsuccess as c on a.success_gid = c.success_gid and c.delete_flag = 'N'
  set a.tran_cr_gid = in_tran_gid,a.reject_date = v_tran_date,c.reject_date = v_tran_date,
  b.paid_status = v_reject_status,
  b.div_status = b.div_status | v_reject_status
  where a.reject_gid = in_reject_gid
  and a.tran_cr_gid = 0
  and a.div_gid > 0
  and a.delete_flag = 'N';

  commit;

  set out_msg = 'Record mapped successfully !';
  set out_result = 1;

END $$

DELIMITER ;