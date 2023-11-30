DELIMITER $$

drop procedure if exists pr_div_set_post_rejectfinacle$$

CREATE PROCEDURE pr_div_set_post_rejectfinacle(
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
  declare v_reject_gid int;
  declare v_acc_no varchar(16);
  declare v_pay_mode char(1);
  declare v_val_date date;
  declare v_div_amount double(15,2);
  declare v_ben_name varchar(12);
  declare v_ref_no varchar(32);
  declare v_crn_no varchar(64);
  declare v_tran_gid int;
  declare v_tran_date date;
  declare v_insert_flag boolean default false;
  declare n int default 0;
  declare c int default 0;
  declare v_reject_status tinyint default 0;
  declare v_success_status tinyint default 0;

  Declare cur cursor for
  select reject_gid,acc_no,val_date,pay_mode,div_amount,substr(ben_name,1,12) as ben_name,ref_no,crn_no from div_trn_treject
  where tran_cr_gid = 0
  and div_gid > 0
  and file_gid = if(in_file_gid > 0,in_file_gid,file_gid)
  and acc_no = if(in_acc_no <> '',in_acc_no,acc_no)
  and delete_flag='N';

  declare continue handler for not found set done = 1;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  -- find reject status
  select status_value into v_reject_status from div_mst_tstatus
  where status_desc = 'Reject'
  and delete_flag = 'N';

  -- find success status
  select status_value into v_success_status from div_mst_tstatus
  where status_desc = 'Success'
  and delete_flag = 'N';

  if v_reject_status = 0 then
    set out_msg = 'Reject status not available in status table';
    set out_result = 0;
    leave me;
  end if;

  if v_success_status = 0 then
    set out_msg = 'Success status not available in status table';
    set out_result = 0;
    leave me;
  end if;

  open cur;
    read_loop:loop
      fetch cur into v_reject_gid,v_acc_no,v_val_date,v_pay_mode,v_div_amount,v_ben_name,v_ref_no,v_crn_no;

      if done = 1 then
        leave read_loop;
      end if;

      set n = n + 1;
      set v_insert_flag = false;

      if v_pay_mode = 'N' then
        if exists(select tran_gid from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'NEFT%'
          and tran_desc like concat('%',v_ref_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N') and v_ref_no <> '' and v_insert_flag = false then

          select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'NEFT%'
          and tran_desc like concat('%',v_ref_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N' limit 0,1;

          set v_insert_flag = true;
        else
          set v_insert_flag = false;
        end if;

        if exists(select tran_gid from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'NEFT%'
          and tran_desc like concat('%',v_ben_name,'%')
          and mapped_amount = 0
          and delete_flag = 'N') and v_ben_name <> '' and v_insert_flag = false then

          select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'NEFT%'
          and tran_desc like concat('%',v_ben_name,'%')
          and mapped_amount = 0
          and delete_flag = 'N' limit 0,1;

          set v_insert_flag = true;
        end if;

        if exists(select tran_gid from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'NEFT%'
          and tran_desc like concat('%',v_crn_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N') and v_crn_no <> '' and v_insert_flag = false then

          select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'NEFT%'
          and tran_desc like concat('%',v_crn_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N' limit 0,1;

          set v_insert_flag = true;
        end if;
      end if;

      if v_pay_mode = 'I' then
        if exists(select tran_gid from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'REV%'
          and tran_desc like concat('%',v_acc_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N')
          and v_insert_flag = false then

          select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'REV%'
          and tran_desc like concat('%',v_acc_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N' limit 0,1;

          set v_insert_flag = true;
        else
          set v_insert_flag = false;
        end if;
      end if;

      if v_pay_mode = 'R' and v_ref_no <> '' then
        if exists(select tran_gid from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'RTGS%'
          and tran_desc like concat('%',v_ref_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N')
          and v_insert_flag = false then

          select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'C'
          and tran_amount = v_div_amount
          and tran_desc like 'RTGS%'
          and tran_desc like concat('%',v_ref_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N' limit 0,1;

          set v_insert_flag = true;
        end if;
      end if;

      if v_insert_flag = true then
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
        where a.reject_gid = v_reject_gid
        and a.tran_cr_gid = 0
        and a.div_gid > 0
        and a.delete_flag = 'N';

        commit;

        set c = c + 1;
      end if;
    end loop read_loop;
  close cur;

  set done = 0;

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(c as char),' posted rejectfully !');
  set out_result = 1;
END $$

DELIMITER ;