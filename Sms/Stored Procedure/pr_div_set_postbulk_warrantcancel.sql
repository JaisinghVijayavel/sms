DELIMITER $$

drop procedure if exists pr_div_set_postbulk_warrantcancel$$

CREATE PROCEDURE pr_div_set_postbulk_warrantcancel(
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

  select count(*) into n from div_trn_twarrantcancel
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and div_gid = 0
  and delete_flag = 'N';

  update div_trn_twarrantcancel as c
  inner join div_trn_twarrant as w on c.acc_no = w.acc_no
  and c.folio_no = w.folio_no
  and w.div_gid > 0
  and w.delete_flag = 'N'
  set c.div_gid = w.div_gid,c.warrant_gid = w.warrant_gid
  where true
  and c.file_gid = if(in_file_gid > 0,in_file_gid,c.file_gid)
  and c.acc_no = if(in_acc_no <> '',in_acc_no,c.acc_no)
  and c.div_gid = 0
  and c.delete_flag = 'N';

  update div_trn_twarrantcancel set div_gid = 0,warrant_gid = 0
  where warrant_gid in
  (
    select a.warrant_gid from
    (
      select warrant_gid,count(*) from div_trn_twarrantcancel
      where true
      and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
      and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
      and div_gid > 0
      and warrant_gid > 0
      and delete_flag = 'N'
      group by warrant_gid
      having count(*) > 1
    ) as a
  );

  call pr_div_set_post_warrantcancel(in_acc_no,in_file_gid,in_system_ip,in_action_by,out_msg,out_result);

  select count(*) into c from div_trn_twarrantcancel
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and div_gid = 0
  and delete_flag = 'N';

  call pr_div_ins_log('Posting Warrant Cancel',in_system_ip,in_action_by);

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(n-c as char),' posted successfully !');
  set out_result = 1;
END $$

DELIMITER ;