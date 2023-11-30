DELIMITER $$

drop procedure if exists pr_div_set_unmap_successfinacle$$

CREATE PROCEDURE pr_div_set_unmap_successfinacle(
  in in_success_gid int,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare v_success_status tinyint default 0;
  declare v_div_amount double;
  declare v_tran_gid int;
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

  if exists(select success_gid from div_trn_tsuccess
    where true
    and success_gid = in_success_gid
    and tran_dr_gid > 0
    and tran_cr_gid > 0
    and delete_flag = 'N') then

    set out_msg = 'Access denied !';
    set out_result = 0;
    leave me;
  end if;

  select tran_dr_gid,div_amount into v_tran_gid,v_div_amount from div_trn_tsuccess
  where true
  and success_gid = in_success_gid
  and tran_dr_gid > 0
  and tran_cr_gid = 0
  and delete_flag = 'N';

  if not exists(select tran_gid from div_trn_ttran
    where true
    and tran_gid = v_tran_gid
    and tran_amount = v_tran_amount
    and mapped_amount = 0
    and delete_flag = 'N') then

    set out_msg = 'Access denied !';
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

  start transaction;

  update div_trn_tsuccess as a
  inner join div_trn_ttran as b on a.tran_dr_gid = b.tran_gid and b.delete_flag = 'N'
  inner join div_trn_tdividend as c on a.div_gid = c.div_gid and c.delete_flag = 'N'
  set a.tran_dr_gid = 0,a.success_date = null,b.mapped_amount = 0,
  c.paid_status = 0,
  c.div_status = (c.div_status | v_success_status) ^ v_success_status,
  c.curr_pay_mode = c.prev_pay_mode,c.prev_pay_mode = null 
  where true
  and a.success_gid = in_success_gid
  and a.tran_dr_gid > 0
  and a.tran_cr_gid = 0
  and b.tran_amount = v_div_amount
  and a.delete_flag = 'N';

  commit;

  set out_msg = concat('Record unmapped successfully !');
  set out_result = 1;
END $$

DELIMITER ;