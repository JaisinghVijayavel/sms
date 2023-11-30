DELIMITER $$

drop procedure if exists pr_div_set_unmap_rejectfinacle$$

CREATE PROCEDURE pr_div_set_unmap_rejectfinacle(
  in in_reject_gid int,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare v_div_amount double default 0;
  declare v_tran_gid int default 0;
  declare v_reject_status tinyint default 0;
  declare v_success_status tinyint default 0;
  declare err_msg text default '';
  declare err_flag varchar(10) default false;

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

  if exists(select reject_gid from div_trn_treject
    where true
    and reject_gid = in_reject_gid
    and tran_cr_gid = 0
    and delete_flag = 'N') then

    set out_msg = 'Access denied !';
    set out_result = 0;
    leave me;
  end if;

  select tran_cr_gid,div_amount into v_tran_gid,v_div_amount from div_trn_treject
  where true
  and reject_gid = in_reject_gid
  and tran_cr_gid > 0
  and delete_flag = 'N';

  if not exists(select tran_gid from div_trn_ttran
    where true
    and tran_gid = v_tran_gid
    and tran_amount = v_div_amount
    and mapped_amount = tran_amount
    and delete_flag = 'N') then

    set out_msg = 'Access denied !';
    set out_result = 0;
    leave me;
  end if;

  start transaction;

  update div_trn_treject as a
  inner join div_trn_ttran as b on a.tran_cr_gid = b.tran_gid and a.div_amount = b.tran_amount and b.delete_flag = 'N'
  inner join div_trn_tdividend as c on a.div_gid = c.div_gid and c.delete_flag = 'N'
  inner join div_trn_tsuccess as d on a.success_gid = d.success_gid and d.delete_flag = 'N'
  set a.tran_cr_gid = 0,d.tran_cr_gid = 0,
  b.mapped_amount = 0,a.reject_date = null,d.reject_date = null,
  c.paid_status = v_success_status,
  c.div_status = (c.div_status | v_reject_status) ^ v_reject_status
  where true
  and a.reject_gid = in_reject_gid
  and a.tran_cr_gid = v_tran_gid
  and a.delete_flag = 'N';

  commit;

  set out_msg = 'Record unmapped successfully !';
  set out_result = 1;
END $$

DELIMITER ;