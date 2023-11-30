DELIMITER $$

drop procedure if exists pr_div_del_knockoff$$

CREATE PROCEDURE pr_div_del_knockoff(
  in in_knockoff_gid int,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare v_tran_dr_gid int default 0;
  declare v_tran_cr_gid int default 0;
  declare v_knockoff_amount double default 0;
  declare err_msg text default '';
  declare err_flag varchar(10) default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  select knockoff_amount,tran_dr_gid,tran_cr_gid into
  v_knockoff_amount,v_tran_dr_gid,v_tran_cr_gid from div_trn_tknockoff
  where knockoff_gid = in_knockoff_gid
  and delete_flag = 'N';

  start transaction;

  update div_trn_tknockoff set
  delete_flag = 'Y',
  update_date = sysdate(),
  update_by = in_action_by
  where true
  and knockoff_gid = in_knockoff_gid
  and delete_flag = 'N';

  update div_trn_ttran set
  excp_amount = excp_amount + v_knockoff_amount,
  mapped_amount = mapped_amount - v_knockoff_amount 
  where tran_gid in (v_tran_dr_gid,v_tran_cr_gid)
  and tran_amount >= v_knockoff_amount
  and delete_flag = 'N';

  insert into div_trn_tdelknockoff
  select * from div_trn_tknockoff where knockoff_gid = in_knockoff_gid
  and delete_flag = 'Y';

  commit;

  set out_msg = concat('Record deleted successfully !');
  set out_result = 1;
END $$

DELIMITER ;