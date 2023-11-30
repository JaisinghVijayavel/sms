DELIMITER $$

drop procedure if exists pr_div_set_postbulk_rejectsuccess$$

CREATE PROCEDURE pr_div_set_postbulk_rejectsuccess(
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

  select count(*) into n from div_trn_treject
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and success_gid = 0
  and delete_flag = 'N';

  update div_trn_treject as r
  inner join div_trn_tsuccess as s on r.acc_no = s.acc_no
  and s.folio_no = r.folio_no
  and s.val_date = r.val_date 
  and s.tran_dr_gid > 0
  and s.reject_gid = 0
  and r.pay_mode = s.pay_mode
  and r.ref_no = s.ref_no
  and r.div_amount = s.div_amount
  and s.div_gid > 0
  and s.delete_flag = 'N'
  set r.success_gid = s.success_gid,s.reject_gid = r.reject_gid,r.div_gid = s.div_gid
  where true
  and r.file_gid = if(in_file_gid > 0,in_file_gid,r.file_gid)
  and r.acc_no = if(in_acc_no <> '',in_acc_no,r.acc_no)
  and r.success_gid = 0
  and r.delete_flag = 'N';

  update div_trn_treject set success_gid = 0,div_gid = 0
  where success_gid in
  (
    select a.success_gid from
    (
      select success_gid,count(*) from div_trn_treject
      where true
      and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
      and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
      and div_gid > 0
      and success_gid > 0
      and tran_cr_gid = 0 
      and delete_flag = 'N'
      group by success_gid
      having count(*) > 1
    ) as a
  );

  update div_trn_tsuccess as s
  left join div_trn_treject as r on s.reject_gid = r.reject_gid and r.delete_flag = 'N'
  set s.reject_gid = 0
  where r.reject_gid is null
  and s.reject_gid > 0
  and s.delete_flag = 'N';

  -- undo cases more than one reject_gid posted in success table
  update div_trn_treject as a
  inner join div_trn_tsuccess as c on a.success_gid = c.success_gid and c.delete_flag = 'N'
  set a.div_gid = 0, a.success_gid = 0,c.reject_gid = 0
  where true
  and a.reject_gid in
  (
    select a.reject_gid from
    (
      select a.reject_gid,count(*) from div_trn_treject as a
      inner join div_trn_tsuccess as b on a.reject_gid = b.reject_gid and b.delete_flag = 'N'
      where true
      and a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
      and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
      and a.div_gid > 0
      and a.success_gid > 0
      and a.delete_flag = 'N'
      group by a.reject_gid
      having count(*) > 1
    ) as a
  )
  and a.tran_cr_gid = 0
  and a.delete_flag = 'N';

  call pr_div_set_post_rejectsuccess(in_acc_no,in_file_gid,in_system_ip,in_action_by,out_msg,out_result);

  select count(*) into c from div_trn_treject
  where true
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and success_gid = 0
  and delete_flag = 'N';

  call pr_div_ins_log('Posting Reject With Success',in_system_ip,in_action_by);

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(n-c as char),' posted successfully !');
  set out_result = 1;
END $$

DELIMITER ;