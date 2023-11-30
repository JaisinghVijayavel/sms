DELIMITER $$

drop procedure if exists pr_div_set_post_rejectdividend$$

CREATE PROCEDURE pr_div_set_post_rejectdividend(
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
  declare v_reject_gid int;
  declare v_div_gid int default 0;
  declare v_div_amount double;
  declare n int default 0;
  declare c int default 0;

  Declare reject_cur cursor for
  select reject_gid,folio_no,acc_no,div_amount from div_trn_treject
  where div_gid = 0
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

  open reject_cur;
    read_loop:loop
      fetch reject_cur into v_reject_gid,v_folio_no,v_acc_no,v_div_amount;

      if done = 1 then
        leave read_loop;
      end if;

      set n = n + 1;

      if exists(select div_gid into v_div_gid from div_trn_tdividend
        where folio_no = v_folio_no
        and acc_no = v_acc_no
        and div_amount = v_div_amount
        and tran_cr_gid > 0 
        and delete_flag = 'N' limit 0,1) then

        start transaction;

        update div_trn_treject set div_gid = v_div_gid
        where reject_gid = v_reject_gid
        and div_gid = 0
        and delete_flag = 'N';

        commit;

        set c = c + 1;
      end if;
    end loop read_loop;
  close reject_cur;

  set done = 0;

  set out_msg = concat('Out of ',cast(n as char),' record(s) ',cast(c as char),' posted successfully !');
  set out_result = 1;
END $$

DELIMITER ;