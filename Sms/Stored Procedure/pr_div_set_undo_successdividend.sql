DELIMITER $$

drop procedure if exists pr_div_set_undo_successdividend$$

CREATE PROCEDURE pr_div_set_undo_successdividend(
  in in_acc_no varchar(16),
  in in_file_gid int,
  in in_system_ip varchar(16),
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
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

  select count(*) into n from div_trn_tsuccess
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and div_gid > 0
  and tran_dr_gid = 0
  and delete_flag = 'N';

  start transaction;

  update div_trn_tsuccess as a
  inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
  set a.div_gid = 0 
  where true
  and a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
  and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
  and a.div_gid > 0
  and a.tran_dr_gid = 0
  and a.delete_flag = 'N';

  commit;

  select count(*) into c from div_trn_tsuccess
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and div_gid > 0
  and tran_dr_gid = 0
  and delete_flag = 'N';

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(n-c as char),' undo made successfully !');
  set out_result = 1;
END $$

DELIMITER ;