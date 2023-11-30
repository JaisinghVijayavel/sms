DELIMITER $$

drop procedure if exists pr_div_del_success$$

CREATE PROCEDURE pr_div_del_success(
  in in_success_gid int,
  in in_action_by varchar(16),
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

  if exists(select success_gid from div_trn_tsuccess
    where true
    and success_gid = in_success_gid
    and div_gid > 0
    and delete_flag = 'N') then

    set out_msg = 'Access denied !';
    set out_result = 0;
    leave me;
  end if;

  start transaction;

  update div_trn_tsuccess as a
  inner join div_trn_tsuccess as b on a.prev_success_gid = b.success_gid and b.delete_flag = 'N'
  set a.prev_success_gid = 0,b.next_success_gid = 0,b.next_pay_mode = b.pay_mode
  where a.success_gid = in_success_gid 
  and a.prev_success_gid > 0
  and a.div_gid = 0
  and a.delete_flag = 'N';

  update div_trn_tsuccess as a
  set a.delete_flag = 'Y'
  where true
  and a.success_gid = in_success_gid
  and a.div_gid = 0
  and a.tran_dr_gid = 0
  and a.tran_cr_gid = 0
  and a.delete_flag = 'N';

  commit;

  set out_msg = concat('Record deleted successfully !');
  set out_result = 1;
END $$

DELIMITER ;