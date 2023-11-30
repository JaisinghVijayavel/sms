DELIMITER $$

drop procedure if exists pr_div_set_undo_rejectsuccess$$

CREATE PROCEDURE pr_div_set_undo_rejectsuccess(
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

  select count(*) into n from div_trn_treject
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and div_gid > 0
  and tran_cr_gid = 0
  and delete_flag = 'N';

  start transaction;

  update div_trn_treject as a
  inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
  inner join div_trn_tsuccess as c on a.success_gid = c.success_gid and c.delete_flag = 'N'
  set a.div_gid = 0, a.success_gid = 0,c.reject_gid = 0
  where true
  and a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
  and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
  and a.tran_cr_gid = 0
  and a.delete_flag = 'N';

  commit;

  update div_trn_tsuccess as a
  set a.next_success_gid = 0
  where true
  and a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
  and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
  and a.reject_gid = 0
  and a.next_success_gid > 0
  and a.delete_flag = 'N';

  update div_trn_tsuccess as a
  inner join div_trn_tsuccess as b on b.success_gid = a.prev_success_gid
  and b.next_success_gid = 0
  and b.reject_gid = 0
  and b.file_gid = if(in_file_gid > 0,in_file_gid,b.file_gid)
  and b.delete_flag = 'N'
  set a.prev_success_gid = 0
  where true
  and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
  and a.prev_success_gid > 0
  and a.delete_flag = 'N';

  select count(*) into c from div_trn_treject
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and div_gid > 0
  and tran_cr_gid = 0
  and delete_flag = 'N';

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(n-c as char),' undo made successfully !');
  set out_result = 1;
END $$

DELIMITER ;