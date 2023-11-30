DELIMITER $$

drop procedure if exists pr_div_set_unmap_successdividend$$

CREATE PROCEDURE pr_div_set_unmap_successdividend(
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
    and tran_dr_gid > 0
    and delete_flag = 'N') then

    set out_msg = 'Access denied !';
    set out_result = 0;
    leave me;
  end if;

  start transaction;

  update div_trn_tsuccess as a
  inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
  set a.div_gid = 0
  where true
  and a.success_gid = in_success_gid
  and a.div_gid > 0
  and a.tran_dr_gid = 0
  and a.delete_flag = 'N';

  commit;

  set out_msg = concat('Record unmapped successfully !');
  set out_result = 1;
END $$

DELIMITER ;