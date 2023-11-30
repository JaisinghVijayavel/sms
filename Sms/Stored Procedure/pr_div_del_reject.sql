DELIMITER $$

drop procedure if exists pr_div_del_reject$$

CREATE PROCEDURE pr_div_del_reject(
  in in_reject_gid int,
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

  if exists(select reject_gid from div_trn_treject
    where true
    and reject_gid = in_reject_gid
    and div_gid > 0
    and delete_flag = 'N') then

    set out_msg = 'Access denied !';
    set out_result = 0;
    leave me;
  end if;

  start transaction;

  update div_trn_treject as a
  set a.delete_flag = 'Y'
  where true
  and a.reject_gid = in_reject_gid
  and a.div_gid = 0
  and a.tran_cr_gid = 0
  and a.delete_flag = 'N';

  commit;

  set out_msg = concat('Record deleted successfully !');
  set out_result = 1;
END $$

DELIMITER ;