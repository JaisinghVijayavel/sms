DELIMITER $$

drop procedure if exists pr_div_set_postbulk_successdividend$$

CREATE PROCEDURE pr_div_set_postbulk_successdividend(
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
  declare n int;
  declare c int;

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
  and div_gid = 0
  and delete_flag = 'N';

  -- based on folio no
  update div_trn_tsuccess as s
  inner join div_trn_tdividend as d on s.acc_no = d.acc_no
  and s.folio_no = d.folio_no
  and s.div_amount = d.div_amount
  and d.tran_cr_gid > 0
  and d.delete_flag = 'N'
  set s.div_gid = d.div_gid
  where true
  and s.file_gid = if(in_file_gid > 0,in_file_gid,s.file_gid)
  and s.acc_no = if(in_acc_no <> '',in_acc_no,s.acc_no)
  and s.div_gid = 0
  and s.delete_flag = 'N';

  -- based on warrant no
  update div_trn_tsuccess as s
  inner join div_trn_tdividend as d on s.acc_no = d.acc_no
  and s.warrant_no = d.warrant_no
  and s.div_amount = d.div_amount
  and d.tran_cr_gid > 0
  and d.delete_flag = 'N'
  set s.div_gid = d.div_gid
  where true
  and s.file_gid = if(in_file_gid > 0,in_file_gid,s.file_gid)
  and s.acc_no = if(in_acc_no <> '',in_acc_no,s.acc_no)
  and s.div_gid = 0
  and s.warrant_no <> '' 
  and s.delete_flag = 'N';

  update div_trn_tsuccess
  set div_gid = 0
  where div_gid in
  (
    select a.div_gid from
    (
      select div_gid,count(*) from div_trn_tsuccess
      where true
      and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
      and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
      and div_gid > 0
      and tran_dr_gid = 0 
      and delete_flag = 'N'
      group by div_gid
      having count(*) > 1
    ) as a
  );

  call pr_div_set_post_successdividend(in_acc_no,in_file_gid,in_system_ip,in_action_by,out_msg,out_result);

  update div_trn_tsuccess as s
  inner join div_trn_tdividend as d on s.div_gid = d.div_gid and d.delete_flag = 'N'
  set s.prev_pay_mode = d.div_pay_mode
  where true
  and s.file_gid = if(in_file_gid > 0,in_file_gid,s.file_gid)
  and s.acc_no = if(in_acc_no <> '',in_acc_no,s.acc_no)
  and s.prev_success_gid = 0
  and s.tran_dr_gid = 0
  and s.pay_mode <> d.div_pay_mode
  and s.delete_flag = 'N';

  select count(*) into c from div_trn_tsuccess
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and div_gid = 0
  and delete_flag = 'N';

  call pr_div_ins_log('Posting Success With Dividend',in_system_ip,in_action_by);

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(n-c as char),' posted successfully !');
  set out_result = 1;
END $$

DELIMITER ;