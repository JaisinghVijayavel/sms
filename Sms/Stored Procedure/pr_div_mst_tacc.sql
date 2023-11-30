DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_mst_tacc $$
CREATE PROCEDURE pr_div_mst_tacc(
  in in_acc_gid int,
  in in_acc_no varchar(16),
  in in_acc_name varchar(128),
  in in_active_flag char(1),
  in in_action varchar(8),
  in in_action_by varchar(10),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  -- validation
  if in_action = 'INSERT' or in_action = 'UPDATE' then
    if in_acc_no = '' then
      set err_msg := concat(err_msg,'Blank a/c no,');
      set err_flag := true;
    end if;

    if in_acc_name = '' then
      set err_msg := concat(err_msg,'Blank a/c name,');
      set err_flag := true;
    end if;

    if in_active_flag <> 'Y' and in_active_flag <> 'N' then
      set err_msg := concat(err_msg,'Invalid active flag,');
      set err_flag := true;
    end if;
  end if;

  if in_action = 'UPDATE' or in_action = 'DELETE' then
    if in_acc_gid = 0 then
      set err_msg := concat(err_msg,'Please select the a/c,');
      set err_flag := true;
    end if;
  end if;

  if err_flag = false then
    -- duplicate checking
    if in_action = 'INSERT' then
      if exists(select acc_gid from div_mst_tacc
        where acc_no = in_acc_no
        and delete_flag = 'N') then
        set err_msg := concat(err_msg,'Duplicate record,');
        set err_flag := true;
      end if;
    end if;

    if in_action = 'UPDATE' then
      if exists(select acc_gid from div_mst_tacc
        where acc_no = in_acc_no
        and acc_gid <> in_acc_gid
        and delete_flag = 'N') then
        set err_msg := concat(err_msg,'Duplicate record,');
        set err_flag := true;
      end if;
    end if;

    if in_action = 'DELETE' then
      if exists(select acc_no from div_trn_ttran
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        or exists(select acc_no from div_trn_tdividend
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        or exists(select acc_no from div_trn_treject 
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        or exists(select acc_no from div_trn_tfailure
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        or exists(select acc_no from div_trn_tsuccess
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        then
        set err_msg := concat(err_msg,'Duplicate record,');
        set err_flag := true;
      end if;
    end if;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  if in_action = 'INSERT' then
    START TRANSACTION;
    insert into div_mst_tacc (acc_no,acc_name,active_flag,insert_date,insert_by) values
    (in_acc_no,in_acc_name,in_active_flag,sysdate(),in_action_by);
    COMMIT;

    set out_msg = 'Record inserted successfully !';
  end if;

  if in_action = 'UPDATE' then
    START TRANSACTION;
    update div_mst_tacc set
    acc_no = in_acc_no,
    acc_name = in_acc_name,
    active_flag = in_active_flag,
    update_date = sysdate(),
    update_by = in_action_by
    where acc_gid = in_acc_gid
    and delete_flag = 'N';
    COMMIT;

    set out_msg = 'Record updated successfully !';
  end if;

  if in_action = 'DELETE' then
    START TRANSACTION;
    update div_mst_tacc set
    delete_flag = 'Y',
    update_date = sysdate(),
    update_by = in_action_by
    where acc_gid = in_acc_gid
    and delete_flag = 'N';
    COMMIT;

    set out_msg = 'Record deleted successfully !';
  end if;

  set out_result = 1;
 END $$

DELIMITER ;