DELIMITER $$

drop procedure if exists pr_div_set_undo_rejectfinacle$$

CREATE PROCEDURE pr_div_set_undo_rejectfinacle(
  in in_acc_no varchar(16),
  in in_file_gid int,
  in in_system_ip varchar(16),
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare v_reject_status tinyint default 0;
  declare v_success_status tinyint default 0;
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare n int default 0;
  declare c int default 0;

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

  if v_reject_status = 0 then
    set out_msg = 'Reject status not available in status table';
    set out_result = 0;
    leave me;
  end if;

  -- find success status
  select status_value into v_success_status from div_mst_tstatus
  where status_desc = 'Success'
  and delete_flag = 'N';

  if v_success_status = 0 then
    set out_msg = 'Success status not available in status table';
    set out_result = 0;
    leave me;
  end if;

  select count(*) into n from div_trn_treject
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and tran_cr_gid > 0
  and delete_flag = 'N';

  start transaction;

  update div_trn_treject as a
  inner join div_trn_ttran as b on a.tran_cr_gid = b.tran_gid and b.delete_flag = 'N'
  inner join div_trn_tdividend as c on a.div_gid = c.div_gid and c.delete_flag = 'N'
  inner join div_trn_tsuccess as d on a.success_gid = d.success_gid and d.delete_flag = 'N' 
  set a.tran_cr_gid = 0,b.mapped_amount = 0,a.reject_date = null,d.reject_date = null,
  c.paid_status = v_success_status,
  c.div_status = (c.div_status | v_reject_status) ^ v_reject_status
  where true
  and a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
  and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
  and a.tran_cr_gid > 0
  and a.delete_flag = 'N';

  commit;

  select count(*) into c from div_trn_treject
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and tran_cr_gid > 0
  and delete_flag = 'N';

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(n-c as char),' undo made successfully !');
  set out_result = 1;
END $$

DELIMITER ;