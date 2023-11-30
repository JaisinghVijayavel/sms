DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_set_breakline` $$
CREATE PROCEDURE `pr_div_set_breakline`(
  in in_tran_gid int,
  in in_breakup_amount text,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_acc_no varchar(16) default '';
  declare v_acc_mode char(1) default '';
  declare v_mult int default 0;
  declare v_tran_amount double(15,2) default 0;
  declare v_excp_amount double(15,2) default 0;
  declare v_new_tran_gid int default 0;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  if in_breakup_amount = "" then
    set err_msg := concat(err_msg,'Invalid breakup amount,');
    set err_flag := true;
  end if;

  if in_tran_gid = 0 then
    set err_msg := concat(err_msg,'Invalid tran gid,');
    set err_flag := true;
  end if;

  select
    excp_amount,acc_mode
  into
    v_excp_amount,v_acc_mode
  from div_trn_ttran
  where tran_gid = in_tran_gid
  and delete_flag = 'N';

  set v_excp_amount = ifnull(v_excp_amount,0);

  if v_excp_amount = 0 then
    set err_msg := concat(err_msg,'Exception amount is zero,');
    set err_flag := true;
  end if;

  if err_flag = false then
    if v_acc_mode = 'D' then
      insert into div_trn_ttran
      (
        file_gid,
        tran_date,
        acc_no,
        tran_desc,
        tran_amount,
        excp_amount,
        mapped_amount,
        acc_mode,
        mult,
        tran_remark1
      )
      select
        file_gid,
        tran_date,
        acc_no,
        'Adj brekup amount',
        v_excp_amount,
        v_excp_amount,
        0,
        'C',
        1,
        substr(in_breakup_amount,1,255)
      from div_trn_ttran
      where tran_gid = in_tran_gid
      and delete_flag = 'N';
    else
      insert into div_trn_ttran
      (
        file_gid,
        tran_date,
        acc_no,
        tran_desc,
        tran_amount,
        excp_amount,
        mapped_amount,
        acc_mode,
        mult,
        tran_remark1
      )
      select
        file_gid,
        tran_date,
        acc_no,
        'Adj brekup amount',
        v_excp_amount,
        v_excp_amount,
        0,
        'D',
        -1,
        substr(in_breakup_amount,1,255)
      from div_trn_ttran
      where tran_gid = in_tran_gid
      and delete_flag = 'N';
    end if;

    -- select new tran_gid
    select max(tran_gid) into v_new_tran_gid from div_trn_ttran;
    set v_new_tran_gid = ifnull(v_new_tran_gid,0);

    -- breakup
    set @breakup_amount = in_breakup_amount;

    while (locate('+',@breakup_amount) > 0)
    do
      set @value = cast(substr(@breakup_amount,1,locate('+',@breakup_amount)-1) as unsigned);

      insert into div_trn_ttran
      (
        file_gid,
        tran_date,
        acc_no,
        tran_desc,
        tran_amount,
        excp_amount,
        mapped_amount,
        acc_mode,
        mult,
        ref_no,
        tran_ref_id,
        tran_psrl,
        tran_isid,
        tran_remark1,
        tran_remark2
      )
      select
        file_gid,
        tran_date,
        acc_no,
        tran_desc,
        @value,
        @value,
        0,
        acc_mode,
        mult,
        ref_no,
        tran_ref_id,
        tran_psrl,
        tran_isid,
        substr(in_breakup_amount,1,255),
        cast(in_tran_gid as char)
      from div_trn_ttran
      where tran_gid = in_tran_gid
      and delete_flag = 'N';

      set @breakup_amount = substr(@breakup_amount,locate('+',@breakup_amount)+1);
    end while;

    if v_acc_mode = 'D' then
      call pr_div_ins_knockoff(v_excp_amount,in_tran_gid,v_new_tran_gid,4,in_action_by,@outresult,@outmsg,@knockoff_gid);
    else
      call pr_div_ins_knockoff(v_excp_amount,v_new_tran_gid,in_tran_gid,4,in_action_by,@outresult,@outmsg,@knockoff_gid);
    end if;

    set out_result = 1;
    set out_msg = 'Record breakup successfully !';
  else
    set out_result = 0;
    set out_msg = err_msg;
  end if;
 END $$

DELIMITER ;