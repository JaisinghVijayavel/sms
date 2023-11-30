DELIMITER $$

drop procedure if exists pr_div_set_post_warrantcancel$$

CREATE PROCEDURE pr_div_set_post_warrantcancel(
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
  declare v_folio_no varchar(64);
  declare v_acc_no varchar(16);
  declare v_warrantcancel_gid int;
  declare v_warrant_gid int default 0;
  declare v_div_gid int default 0;
  declare v_warrant_amount double;
  declare n int default 0;
  declare c int default 0;

  Declare wc_cur cursor for
  select warrantcancel_gid,folio_no,acc_no,warrant_amount from div_trn_twarrantcancel
  where div_gid = 0
  and warrant_gid = 0
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

  open wc_cur;
    read_loop:loop
      fetch wc_cur into v_warrantcancel_gid,v_folio_no,v_acc_no,v_warrant_amount;
      set n = n + 1;

      if done = 1 then
        leave read_loop;
      end if;

      if exists(select warrant_gid,div_gid into v_warrant_gid,v_div_gid from div_trn_twarrant
        where folio_no = v_folio_no
        and acc_no = v_acc_no
        and warrant_amount = v_warrant_amount
        and div_gid > 0
        and delete_flag = 'N' limit 0,1) then

        start transaction;

        update div_trn_twarrantcancel set div_gid = v_div_gid,warrant_gid = v_warrant_gid
        where warrantcancel_gid = v_warrantcancel_gid
        and warrant_gid = 0
        and div_gid = 0
        and delete_flag = 'N';

        commit;

        set c = c + 1;
      end if;
    end loop read_loop;
  close wc_cur;

  set done = 0;

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(c as char),' posted successfully !');
  set out_result = 1;
END $$

DELIMITER ;