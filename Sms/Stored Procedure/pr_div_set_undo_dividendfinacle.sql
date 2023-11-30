DELIMITER $$

drop procedure if exists pr_div_set_undo_dividendfinacle$$

CREATE PROCEDURE pr_div_set_undo_dividendfinacle(
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

  select count(*) into n from div_trn_tdividend
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and tran_cr_gid > 0
  and delete_flag = 'N';

  if
    not (exists
    (
      select a.div_gid from div_trn_tdividend as a
      inner join div_trn_tsuccess as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
      and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
      and a.delete_flag = 'N'
    ) or
    exists
    (
      select a.div_gid from div_trn_tdividend as a
      inner join div_trn_tfailure as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
      and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
      and a.tran_cr_gid > 0
      and a.delete_flag = 'N'
    ) or
    exists
    (
      select a.div_gid from div_trn_tdividend as a
      inner join div_trn_treject as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
      and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
      and a.tran_cr_gid > 0
      and a.delete_flag = 'N'
    ) or
    exists
    (
      select a.div_gid from div_trn_tdividend as a
      inner join div_trn_twarrant as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
      and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
      and a.tran_cr_gid > 0
      and a.delete_flag = 'N'
    ) or
    exists
    (
      select a.div_gid from div_trn_tdividend as a
      inner join div_trn_twarrantcancel as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
      and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
      and a.tran_cr_gid > 0
      and a.delete_flag = 'N'
    )) then

    start transaction;

      update div_trn_tdividend as a
      inner join div_trn_ttran as b on a.tran_cr_gid = b.tran_gid and b.delete_flag = 'N'
      set a.tran_cr_gid = 0,b.mapped_amount = 0
      where a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
      and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
      and a.tran_cr_gid > 0
      and a.delete_flag = 'N';

    commit;

    set out_result = 0;
  else
    call pr_div_ins_log('Undo Dividend With Finacle Access Denied',in_system_ip,in_action_by);

    set out_msg = 'Access denied !';
    set out_result = 0;

    leave me;
  end if;

  select count(*) into c from div_trn_tdividend
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and tran_cr_gid > 0
  and delete_flag = 'N';

  call pr_div_ins_log('Undo Dividend With Finacle',in_system_ip,in_action_by);

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(n-c as char),' undo made successfully !');
  set out_result = 1;
END $$

DELIMITER ;