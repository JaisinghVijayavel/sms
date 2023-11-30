DELIMITER $$

drop procedure if exists pr_div_set_post_successfinacle$$

CREATE PROCEDURE pr_div_set_post_successfinacle(
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
  declare v_success_gid int;
  declare v_acc_no varchar(16);
  declare v_pay_mode char(1);
  declare v_val_date date;
  declare v_chq_no varchar(16);
  declare v_batch_no varchar(32);
  declare v_warrant_no varchar(32);
  declare v_ref_no varchar(32);
  declare v_div_amount double(15,2);
  declare v_ben_name varchar(12);
  declare v_tran_gid int;
  declare v_tran_date date;
  declare v_insert_flag boolean default false;
  declare v_success_status tinyint default 0;
  declare v_reject_status tinyint default 2;
  declare n int default 0;
  declare c int default 0;
  declare v_count int default 0;

  Declare cur cursor for
  select a.success_gid,a.acc_no,a.val_date,a.pay_mode,a.div_amount,
  a.chq_no,a.batch_no,a.warrant_no,a.ref_no,
  trim(substr(a.ben_name,1,10)) as ben_name
  from div_trn_tsuccess as a
  inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
  where a.tran_dr_gid = 0
  and a.div_gid > 0
  and a.file_gid = if(in_file_gid > 0,in_file_gid,a.file_gid)
  and a.acc_no = if(in_acc_no <> '',in_acc_no,a.acc_no)
  and a.pay_mode in ('N','W','D','R')
  and b.paid_status in (0,v_reject_status)
  and a.delete_flag='N';

  declare continue handler for not found set done = 1;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  -- find success status
  select status_value into v_success_status from div_mst_tstatus
  where status_desc = 'Success'
  and delete_flag = 'N';

  if v_success_status = 0 then
    set out_msg = 'Success status not available in status table';
    set out_result = 0;
    leave me;
  end if;

  open cur;
    read_loop:loop
      fetch cur into v_success_gid,v_acc_no,v_val_date,v_pay_mode,v_div_amount,v_chq_no,v_batch_no,v_warrant_no,v_ref_no,v_ben_name;

      if done = 1 then
        leave read_loop;
      end if;

      set n = n + 1;
      set v_insert_flag = false;

      if v_pay_mode = 'N' then
        if v_batch_no <> '' then
          if exists(select tran_gid from div_trn_ttran
            where tran_date = v_val_date
            and acc_no = v_acc_no
            and acc_mode = 'D'
            and tran_amount = v_div_amount
            and tran_desc like 'NEFT%'
            and tran_desc like concat('%',v_batch_no,'%')
            and mapped_amount = 0
            and delete_flag = 'N') and v_pay_mode = 'N' and v_batch_no <> '' then

            select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
            where tran_date = v_val_date
            and acc_no = v_acc_no
            and acc_mode = 'D'
            and tran_amount = v_div_amount
            and tran_desc like 'NEFT%'
            and tran_desc like concat('%',v_batch_no,'%')
            and mapped_amount = 0
            and delete_flag = 'N' limit 0,1;

            set v_insert_flag = true;
          else
            set v_insert_flag = false;
          end if;
        end if;

        if v_insert_flag = false and v_ref_no <> '' then
          if exists(select tran_gid from div_trn_ttran
            where tran_date = v_val_date
            and acc_no = v_acc_no
            and acc_mode = 'D'
            and tran_amount = v_div_amount
            and tran_desc like 'NEFT%'
            and tran_desc like concat('%',v_ref_no,'%')
            and mapped_amount = 0
            and delete_flag = 'N') and v_pay_mode = 'N' and v_ref_no <> '' then

            select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
            where tran_date = v_val_date
            and acc_no = v_acc_no
            and acc_mode = 'D'
            and tran_amount = v_div_amount
            and tran_desc like 'NEFT%'
            and tran_desc like concat('%',v_ref_no,'%')
            and mapped_amount = 0
            and delete_flag = 'N' limit 0,1;

            set v_insert_flag = true;
          else
            set v_insert_flag = false;
          end if;
        end if;
      end if;

      if v_pay_mode = 'R' and v_batch_no <> '' then
        if exists(select tran_gid from div_trn_ttran
          where tran_date = v_val_date
          and acc_no = v_acc_no
          and acc_mode = 'D'
          and tran_amount = v_div_amount
          and tran_desc like 'RTGS%'
          and tran_desc like concat('%',v_batch_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N') and v_pay_mode = 'R' and v_batch_no <> '' then

          select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
          where tran_date = v_val_date
          and acc_no = v_acc_no
          and acc_mode = 'D'
          and tran_amount = v_div_amount
          and tran_desc like 'RTGS%'
          and tran_desc like concat('%',v_batch_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N' limit 0,1;

          set v_insert_flag = true;
        else
          set v_insert_flag = false;
        end if;
      end if;

      if v_pay_mode = 'W' and v_chq_no <> '' then
        if exists(select tran_gid from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'D'
          and tran_amount = v_div_amount
          and tran_desc like concat('%',v_chq_no,'%')
          and tran_desc like concat('%',v_warrant_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N') then

          select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'D'
          and tran_amount = v_div_amount
          and tran_desc like concat('%',v_chq_no,'%')
          and tran_desc like concat('%',v_warrant_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N' limit 0,1;

          set v_insert_flag = true;
        elseif exists(select tran_gid from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'D'
          and tran_amount = v_div_amount
          and tran_desc like concat('%',v_chq_no,'%')
          and tran_date = v_val_date
          and mapped_amount = 0
          and delete_flag = 'N') then

          select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'D'
          and tran_amount = v_div_amount
          and tran_desc like concat('%',v_chq_no,'%')
          and tran_date = v_val_date
          and mapped_amount = 0
          and delete_flag = 'N' limit 0,1;

          set v_insert_flag = true;
        else
          set v_insert_flag = false;
        end if;

        if v_insert_flag = false and v_ref_no <> '' then
          if exists(select tran_gid from div_trn_ttran
            where acc_no = v_acc_no
            and acc_mode = 'D'
            and tran_amount = v_div_amount
            and tran_desc like concat('%',v_chq_no,'%')
            and tran_desc like concat('%',v_ref_no,'%')
            and mapped_amount = 0
            and delete_flag = 'N') then

            select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
            where acc_no = v_acc_no
            and acc_mode = 'D'
            and tran_amount = v_div_amount
            and tran_desc like concat('%',v_chq_no,'%')
            and tran_desc like concat('%',v_ref_no,'%')
            and mapped_amount = 0
            and delete_flag = 'N' limit 0,1;

            set v_insert_flag = true;
          else
            set v_insert_flag = false;
          end if;
        end if;
      end if;

      if v_pay_mode = 'D' and v_batch_no <> '' then
        if exists(select tran_gid from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'D'
          and tran_amount = v_div_amount
          and tran_desc like concat('%',v_batch_no,'%')
          and tran_desc like concat('%',v_warrant_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N') then

          select tran_gid,tran_date into v_tran_gid,v_tran_date from div_trn_ttran
          where acc_no = v_acc_no
          and acc_mode = 'D'
          and tran_amount = v_div_amount
          and tran_desc like concat('%',v_batch_no,'%')
          and tran_desc like concat('%',v_warrant_no,'%')
          and mapped_amount = 0
          and delete_flag = 'N' limit 0,1;

          set v_insert_flag = true;
        else
          set v_insert_flag = false;
        end if;
      end if;

      select count(*) into v_count from div_trn_tsuccess as a
      inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.success_gid = v_success_gid
      and a.tran_dr_gid = 0
      and b.paid_status = v_success_status
      and a.delete_flag = 'N';

      if v_count > 0 then
        set v_insert_flag = false;
      end if;

      if v_insert_flag = true then
        start transaction;

        update div_trn_ttran set mapped_amount = tran_amount
        where tran_gid = v_tran_gid
        and mapped_amount = 0
        and delete_flag = 'N';

        update div_trn_tsuccess as a
        inner join div_trn_tdividend as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
        set a.tran_dr_gid = v_tran_gid,
        a.success_date = v_tran_date,
        b.paid_status = v_success_status,
        b.div_status = b.div_status | v_success_status,
        b.curr_pay_mode = a.pay_mode,
        b.prev_pay_mode = b.curr_pay_mode
        where a.success_gid = v_success_gid
        and a.tran_dr_gid = 0
        and b.paid_status in (0,v_reject_status)
        and a.delete_flag = 'N';

        commit;

        set c = c + 1;
      end if;
    end loop read_loop;
  close cur;

  set done = 0;

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(c as char),' posted successfully !');
  set out_result = 1;
END $$

DELIMITER ;