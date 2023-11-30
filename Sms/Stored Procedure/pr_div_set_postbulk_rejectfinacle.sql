DELIMITER $$

drop procedure if exists pr_div_set_postbulk_rejectfinacle$$

CREATE PROCEDURE pr_div_set_postbulk_rejectfinacle(
  in in_acc_no varchar(16),
  in in_file_gid int,
  in in_system_ip varchar(16),
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare v_reject_status tinyint default 0;
  declare done int default 0;
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_acc_no varchar(16);
  declare v_pay_mode char(1);
  declare v_val_date date;
  declare v_div_sum double(15,2);
  declare v_tran_gid int;
  declare v_tran_date date;
  declare n int default 0;
  declare c int default 0;

  Declare cur cursor for
  select acc_no,val_date,pay_mode,sum(div_amount) as div_sum from div_trn_treject
  where tran_cr_gid = 0
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and pay_mode <> 'N'
  and div_gid > 0
  and delete_flag='N'
  group by acc_no,val_date,pay_mode;

  declare continue handler for not found set done = 1;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  select count(*) into n from div_trn_treject
  where tran_cr_gid = 0
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and pay_mode <> 'N'
  and div_gid > 0
  and delete_flag='N';

  -- find reject status
  select status_value into v_reject_status from div_mst_tstatus
  where status_desc = 'Reject'
  and delete_flag = 'N';

  if v_reject_status = 0 then
    set out_msg = 'Reject status not available in status table';
    set out_result = 0;
    leave me;
  end if;

  open cur;
    read_loop:loop
      fetch cur into v_acc_no,v_val_date,v_pay_mode,v_div_sum;

      if done = 1 then
        leave read_loop;
      end if;

      if exists(select tran_gid from div_trn_ttran
        where acc_no = v_acc_no
        and acc_mode = 'C'
        and tran_amount = v_div_sum
        and mapped_amount = 0
        and delete_flag = 'N') then

        select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
        where acc_no = v_acc_no
        and acc_mode = 'C'
        and tran_amount = v_div_sum
        and mapped_amount = 0
        and delete_flag = 'N' limit 0,1;

        start transaction;

        update div_trn_ttran set mapped_amount = tran_amount
        where tran_gid = v_tran_gid
        and mapped_amount = 0
        and delete_flag = 'N';

        update div_trn_treject as a
        inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
        inner join div_trn_tsuccess as c on a.success_gid = c.success_gid and c.delete_flag = 'N'
        set a.tran_cr_gid = v_tran_gid,a.reject_date = v_tran_date,c.reject_date = v_tran_date, 
        b.paid_status = v_reject_status,
        b.div_status = b.div_status | v_reject_status
        where a.acc_no = v_acc_no
        and a.val_date = v_val_date
        and a.pay_mode = v_pay_mode
        and a.tran_cr_gid = 0
        and a.div_gid > 0
        and a.delete_flag = 'N';

        commit;
      end if;
    end loop read_loop;
  close cur;

  set done = 0;

  call pr_div_set_post_rejectfinacle(in_acc_no,in_file_gid,in_system_ip,in_action_by,out_msg,out_result);

  call pr_div_ins_log('Posting Reject With Finacle',in_system_ip,in_action_by);

  select count(*) into c from div_trn_treject
  where tran_cr_gid = 0
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and pay_mode <> 'N'
  and div_gid > 0
  and delete_flag='N';

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast((n-c) as char),' posted successfully !');
  set out_result = 1;
END $$

DELIMITER ;