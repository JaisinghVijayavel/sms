DELIMITER $$

drop procedure if exists pr_div_set_map_successfinacle$$

CREATE PROCEDURE pr_div_set_map_successfinacle(
  in in_success_gid int,
  in in_tran_gid int,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_success_gid int;
  declare v_acc_no varchar(16);
  declare v_pay_mode char(1);
  declare v_val_date date;
  declare v_batch_no varchar(32);
  declare v_warrant_no varchar(32);
  declare v_div_amount double(15,2);
  declare v_ben_name varchar(12);
  declare v_tran_date date;
  declare v_insert_flag boolean default false;
  declare v_success_status tinyint default 0;

  -- find success status
  select status_value into v_success_status from div_mst_tstatus
  where status_desc = 'Success'
  and delete_flag = 'N';

  if v_success_status = 0 then
    set out_msg = 'Success status not available in status table';
    set out_result = 0;
    leave me;
  end if;

  select a.success_gid,a.acc_no,a.val_date,a.pay_mode,a.div_amount,a.batch_no,a.warrant_no,
  trim(substr(a.ben_name,1,10)) as ben_name into
  v_success_gid,v_acc_no,v_val_date,v_pay_mode,v_div_amount,v_batch_no,v_warrant_no,v_ben_name
  from div_trn_tsuccess as a
  inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
  where a.success_gid = in_success_gid
  and a.tran_dr_gid = 0
  and a.div_gid > 0
  and a.pay_mode in ('N','W')
  and b.paid_status <> v_success_status
  and a.delete_flag='N';

  if exists(select tran_gid from div_trn_ttran
    where tran_gid = in_tran_gid
    and acc_no = v_acc_no
    and acc_mode = 'D'
    and tran_amount = v_div_amount
    and mapped_amount = 0
    and delete_flag = 'N') then

    select tran_date into v_tran_date from div_trn_ttran
    where tran_gid = in_tran_gid
    and acc_no = v_acc_no
    and acc_mode = 'D'
    and tran_amount = v_div_amount
    and mapped_amount = 0
    and delete_flag = 'N';

    set v_insert_flag = true;
  else
    set v_insert_flag = false;
  end if;

  if v_insert_flag = true then
    start transaction;

    update div_trn_ttran set mapped_amount = tran_amount
    where tran_gid = in_tran_gid
    and mapped_amount = 0
    and delete_flag = 'N';

    update div_trn_tsuccess as a
    inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
    set a.tran_dr_gid = in_tran_gid,
    a.success_date = v_tran_date,
    b.paid_status = v_success_status,
    b.div_status = b.div_status | v_success_status,
    b.curr_pay_mode = a.pay_mode,
    b.prev_pay_mode = b.curr_pay_mode,
    a.mapped_date = sysdate(),
    a.mapped_by = in_action_by
    where a.success_gid = in_success_gid
    and a.tran_dr_gid = 0
    and b.paid_status <> v_success_status
    and a.delete_flag = 'N';

    commit;

    set out_msg = 'Record mapped successfully !';
    set out_result = 1;
  else
    set out_msg = 'Mapping failed';
    set out_result = 0;
  end if;

END $$

DELIMITER ;