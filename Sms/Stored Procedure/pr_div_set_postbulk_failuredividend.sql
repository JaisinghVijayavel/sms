DELIMITER $$

drop procedure if exists pr_div_set_postbulk_failuredividend$$

CREATE PROCEDURE pr_div_set_postbulk_failuredividend(
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

  select count(*) into n from div_trn_tfailure
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and div_gid = 0
  and delete_flag = 'N';

  update div_trn_tfailure as f
  inner join div_trn_tdividend as d on f.acc_no = d.acc_no
  and f.folio_no = d.folio_no
  and d.tran_cr_gid > 0
  and d.delete_flag = 'N'
  set f.div_gid = d.div_gid
  where true
  and f.file_gid = if(in_file_gid > 0,in_file_gid,f.file_gid)
  and f.acc_no = if(in_acc_no <> '',in_acc_no,f.acc_no)
  and f.div_gid = 0
  and f.delete_flag = 'N';

  update div_trn_tfailure as f
  inner join div_trn_tdividend as d on f.acc_no = d.acc_no
  and f.warrant_no = d.warrant_no
  and d.tran_cr_gid > 0
  and d.delete_flag = 'N'
  set f.div_gid = d.div_gid
  where true
  and f.file_gid = if(in_file_gid > 0,in_file_gid,f.file_gid)
  and f.acc_no = if(in_acc_no <> '',in_acc_no,f.acc_no)
  and f.warrant_no <> ''
  and f.div_gid = 0
  and f.delete_flag = 'N';

    update div_trn_tfailure set div_gid = 0
  where div_gid in
  (
    select a.div_gid from
    (
      select div_gid,count(*) from div_trn_tfailure
      where true
      and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
      and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
      and div_gid > 0
      and delete_flag = 'N'
      group by div_gid
      having count(*) > 1
    ) as a
  );

  call pr_div_set_post_failuredividend(in_acc_no,in_file_gid,in_system_ip,in_action_by,out_msg,out_result);

  select count(*) into c from div_trn_tfailure
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and div_gid = 0
  and delete_flag = 'N';

  call pr_div_ins_log('Posting failure With Dividend',in_system_ip,in_action_by);

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(n-c as char),' posted successfully !');
  set out_result = 1;
END $$

DELIMITER ;