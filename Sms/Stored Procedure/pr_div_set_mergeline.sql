DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_set_mergeline` $$
CREATE PROCEDURE `pr_div_set_mergeline`(
  in in_tran_gid text,
  in in_merge_amount decimal(15,2),
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
  declare v_tran_gid int default 0;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  if in_merge_amount <= 0 then
    set err_msg := concat(err_msg,'Invalid merge amount,');
    set err_flag := true;
  end if;

  if in_tran_gid = "" then
    set err_msg := concat(err_msg,'Invalid tran gid,');
    set err_flag := true;
  else
    set @tran_gid = in_tran_gid;

    if locate(',',@tran_gid) > 0 then
      set @value_gid = cast(substr(@tran_gid,1,locate(',',@tran_gid)-1) as unsigned);

      select acc_no,acc_mode,mult into v_acc_no,v_acc_mode,v_mult from div_trn_ttran
      where tran_gid = @value_gid
      and delete_flag = 'N';

      set v_acc_no = ifnull(v_acc_no,'');
      set v_acc_mode = ifnull(v_acc_mode,'');
      set v_mult = ifnull(v_mult,0);

      if v_acc_no = '' then
        set err_msg := concat(err_msg,'Invalid tran gid,');
        set err_flag := true;
      end if;
    else
      set err_msg := concat(err_msg,'Invalid tran gid,');
      set err_flag := true;
    end if;
  end if;

  if err_flag = false then
    set @tran_gid = in_tran_gid;

    while (locate(',',@tran_gid) > 0)
    do
      set @value = cast(substr(@tran_gid,1,locate(',',@tran_gid)-1) as unsigned);

      select
        excp_amount
      into
        v_excp_amount
      from div_trn_ttran
      where tran_gid = @value
      and acc_no = v_acc_no
      and acc_mode = v_acc_mode
      and mapped_amount = 0
      and delete_flag = 'N';

      set v_excp_amount = ifnull(v_excp_amount,0);
      set v_tran_amount = round(v_tran_amount + v_excp_amount,2);

      set @tran_gid = substr(@tran_gid,locate(',',@tran_gid)+1);
    end while;

    if v_tran_amount <> in_merge_amount then
      set err_msg := concat(err_msg,'Amount mismatch,',cast(v_excp_amount as char));
      set err_flag := true;
    end if;
  end if;

  if err_flag = false then
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
      'Adj merged lines',
      in_merge_amount,
      in_merge_amount,
      0,
      acc_mode,
      mult,
      substr(in_tran_gid,1,255)
    from div_trn_ttran
    where tran_gid = @value_gid
    and delete_flag = 'N';

    -- insert new adjustment lines
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
        'Adj merged lines',
        in_merge_amount,
        in_merge_amount,
        0,
        'C',
        1,
        substr(in_tran_gid,1,255)
      from div_trn_ttran
      where tran_gid = @value_gid
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
        'merged lines',
        in_merge_amount,
        in_merge_amount,
        0,
        'D',
        -1,
        substr(in_tran_gid,1,255)
      from div_trn_ttran
      where tran_gid = @value_gid
      and delete_flag = 'N';
    end if;

    -- select new tran_gid
    select max(tran_gid) into v_tran_gid from div_trn_ttran;
    set v_tran_gid = ifnull(v_tran_gid,0);

    set @tran_gid = in_tran_gid;

    while (locate(',',@tran_gid) > 0)
    do
      set @value = cast(substr(@tran_gid,1,locate(',',@tran_gid)-1) as unsigned);

      select
        excp_amount
      into
        v_excp_amount
      from div_trn_ttran
      where tran_gid = @value
      and acc_no = v_acc_no
      and acc_mode = v_acc_mode
      and mapped_amount = 0
      and delete_flag = 'N';

      set v_excp_amount = ifnull(v_excp_amount,0);

      if v_excp_amount > 0 then
        if v_acc_mode = 'D' then
          call pr_div_ins_knockoff(v_excp_amount,v_tran_gid,@value,2,in_action_by,@outresult,@outmsg,@knockoff_gid);
        else
          call pr_div_ins_knockoff(v_excp_amount,@value,v_tran_gid,2,in_action_by,@outresult,@outmsg,@knockoff_gid);
        end if;
      end if;

      set @tran_gid = substr(@tran_gid,locate(',',@tran_gid)+1);
    end while;

    set out_result = 1;
    set out_msg = 'Record merged successfully !';
  else
    set out_result = 0;
    set out_msg = err_msg;
  end if;

 END $$

DELIMITER ;