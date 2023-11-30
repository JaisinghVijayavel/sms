DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_set_post_warrantfinacle` $$
CREATE PROCEDURE `pr_div_set_post_warrantfinacle`(
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
  declare v_warrant_gid int;
  declare v_chq_date date;
  declare v_acc_no varchar(16);
  declare v_chq_no varchar(16);
  declare v_warrant_no varchar(16);
  declare v_warrant_amount double(15,2);
  declare v_ben_name varchar(12);
  declare v_tran_gid int;
  declare v_insert_flag boolean default false;
  declare n int default 0;
  declare c int default 0;

  Declare cur cursor for
  select warrant_gid,acc_no,chq_date,chq_no,warrant_amount,warrant_no from div_trn_twarrant
  where tran_dr_gid = 0
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

  open cur;
    read_loop:loop
      fetch cur into v_warrant_gid,v_acc_no,v_chq_date,v_chq_no,v_warrant_amount,v_warrant_no;

      if done = 1 then
        leave read_loop;
      end if;

      set n = n + 1;
      set v_insert_flag = false;

      if exists(select tran_gid into v_tran_gid from div_trn_ttran
        where tran_date = v_val_date
        and acc_no = v_acc_no
        and acc_mode = 'D'
        and tran_amount = v_warrant_amount
        and tran_desc like concat('%',v_chq_no,'%')
        and tran_desc like concat('%',v_warrant_no,'%')
        and tran_date <= date_add(v_chq_date,interval 3 month)
        and mapped_amount = 0
        and delete_flag = 'N' limit 0,1) then

        set v_insert_flag = true;
      else
        set v_insert_flag = false;
      end if;

      if v_insert_flag = true then
        start transaction;

        update div_trn_ttran set mapped_amount = tran_amount
        where tran_gid = v_tran_gid
        and mapped_amount = 0
        and delete_flag = 'N';

        update div_trn_twarrant set tran_dr_gid = v_tran_gid
        where warrant_gid = v_warrant_gid
        and tran_dr_gid = 0
        and div_gid > 0
        and delete_flag = 'N';

        commit;

        set c = c + 1;
      end if;
  end loop read_loop;

  close cur;

  set done = 0;

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(c as char),' posted warrantfully !');
  set out_result = 1;
END $$

DELIMITER ;