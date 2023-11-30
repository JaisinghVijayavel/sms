DELIMITER $$

drop procedure if exists pr_div_set_post_dividendfinacle$$

CREATE PROCEDURE pr_div_set_post_dividendfinacle(
  in in_acc_no varchar(16),
  in in_file_gid int,
  in in_system_ip varchar(16),
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare done int default 0;
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_acc_no varchar(16);
  declare v_val_date date;
  declare v_div_sum double(15,2);
  declare v_tran_gid int default 0;
  declare n int default 0;
  declare c int default 0;

  Declare div_cur cursor for
  select acc_no,sum(div_amount) as div_sum from div_trn_tdividend
  where tran_cr_gid = 0
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and delete_flag='N'
  group by acc_no;

  declare continue handler for not found set done = 1;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  select count(*) into n from div_trn_tdividend
  where tran_cr_gid = 0
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and delete_flag='N';

  open div_cur;
    read_loop:loop
      fetch div_cur into v_acc_no,v_div_sum;

      if done = 1 then
        leave read_loop;
      end if;

      if exists(select tran_gid into v_tran_gid from div_trn_ttran
        where acc_no = v_acc_no
        and tran_amount = v_div_sum
        and acc_mode = 'C'
        and mapped_amount = 0
        and delete_flag = 'N') then

        select tran_gid into v_tran_gid from div_trn_ttran
        where acc_no = v_acc_no
        and tran_amount = v_div_sum
        and acc_mode = 'C'
        and mapped_amount = 0
        and delete_flag = 'N' limit 0,1;

        start transaction;

        update div_trn_ttran set mapped_amount = tran_amount
        where tran_gid = v_tran_gid
        and mapped_amount = 0
        and delete_flag = 'N';

        update div_trn_tdividend set tran_cr_gid = v_tran_gid
        where acc_no = v_acc_no
        and tran_cr_gid = 0
        and delete_flag = 'N';

        commit;
      end if;
    end loop read_loop;
  close div_cur;

  set done = 0;

  call pr_div_ins_log('Posting Dividend With Finacle',in_system_ip,in_action_by);

  select count(*) into c from div_trn_tdividend
  where tran_cr_gid = 0
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and delete_flag='N';

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast((n-c) as char),' posted successfully !');
  set out_result = 1;
END $$

DELIMITER ;