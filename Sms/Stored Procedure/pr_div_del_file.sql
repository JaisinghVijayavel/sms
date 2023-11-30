DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_del_file` $$
CREATE PROCEDURE `pr_div_del_file`(
  in in_file_gid int,
  in in_file_type tinyint,
  in in_action_by varchar(16),
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
  if in_file_gid = 0 then
    set err_msg := concat(err_msg,'Blank file Name,');
    set err_flag := true;
  end if;

  if not exists (select filetype_gid from div_mst_tfiletype
    where filetype_value = in_file_type
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid file type,');
    set err_flag := true;
  end if;

  -- finacle
  if in_file_type = 1 then
    if exists(select tran_gid from div_trn_ttran
      where file_gid = in_file_gid
      and mapped_amount > 0
      and delete_flag = 'N' limit 0,1) then
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    end if;

    if err_flag = true then
      set out_result = 0;
      set out_msg = err_msg;
      leave me;
    end if;

    START TRANSACTION;

    update div_trn_tfile set
    update_date = sysdate(),
    update_by = in_action_by,
    delete_flag = 'Y'
    where file_gid = in_file_gid
    and delete_flag = 'N';

    delete from div_trn_ttran
    where file_gid = in_file_gid
    and delete_flag = 'N';

    update div_trn_ttranacc set
    delete_flag = 'Y'
    where file_gid = in_file_gid
    and delete_flag = 'N';

    delete from div_trn_terrline
    where file_gid = in_file_gid
    and delete_flag = 'N';

    COMMIT;

    set out_result = 1;
    set out_msg = 'File deleted successfully !';
    leave me;
  end if;

  -- success/failure
  if in_file_type = 9 then
    if exists (select success_gid from div_trn_tsuccess
      where file_gid = in_file_gid
      and div_gid > 0
      and delete_flag = 'N') then
      set err_msg := concat(err_msg,'Success Access denied,');
      set err_flag := true;
    end if;

    if exists (select reject_gid from div_trn_treject
      where file_gid = in_file_gid
      and div_gid > 0
      and delete_flag = 'N' limit 0,1) then
      set err_msg := concat(err_msg,'Reject Access denied,');
      set err_flag := true;
    end if;

    if exists (select failure_gid from div_trn_tfailure
      where file_gid = in_file_gid
      and div_gid > 0
      and delete_flag = 'N' limit 0,1) then
      set err_msg := concat(err_msg,'Failure Access denied,');
      set err_flag := true;
    end if;

    -- check next success_gid mapped
    if exists (select success_gid from div_trn_tsuccess
      where file_gid = in_file_gid
      and next_success_gid > 0
      and delete_flag = 'N' limit 0,1) then
      set err_msg := concat(err_msg,'Next success gid mapped,');
      set err_flag := true;
    end if;

    if err_flag = true then
      set out_result = 0;
      set out_msg = err_msg;
      leave me;
    end if;

    START TRANSACTION;

    update div_trn_tfile set
    update_date = sysdate(),
    update_by = in_action_by,
    delete_flag = 'Y'
    where file_gid = in_file_gid
    and delete_flag = 'N';

    update div_trn_tsuccess as a
    inner join div_trn_tsuccess as b on a.prev_success_gid = b.success_gid and b.delete_flag = 'N'
    set a.prev_success_gid = 0,b.next_success_gid = 0,b.next_pay_mode = b.pay_mode
    where a.file_gid = in_file_gid
    and a.prev_success_gid > 0
    and a.div_gid = 0
    and a.delete_flag = 'N';

    delete from div_trn_tsuccess
    where file_gid = in_file_gid
    and div_gid = 0
    and delete_flag = 'N';

    delete from div_trn_treject
    where file_gid = in_file_gid
    and div_gid = 0
    and delete_flag = 'N';

    delete from div_trn_tfailure
    where file_gid = in_file_gid
    and div_gid = 0
    and delete_flag = 'N';

    delete from div_trn_terrline
    where file_gid = in_file_gid
    and delete_flag = 'N';

    COMMIT;

    set out_result = 1;
    set out_msg = 'File deleted successfully !';
    leave me;
  end if;

  -- success
  if in_file_type = 2 then
    if exists (select success_gid from div_trn_tsuccess
      where file_gid = in_file_gid
      and div_gid > 0
      and delete_flag = 'N') then
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    end if;

    if err_flag = true then
      set out_result = 0;
      set out_msg = err_msg;
      leave me;
    end if;

    -- check next success_gid mapped
    if exists (select success_gid from div_trn_tsuccess
      where file_gid = in_file_gid
      and next_success_gid > 0
      and delete_flag = 'N' limit 0,1) then
      set err_msg := concat(err_msg,'Next success gid mapped,');
      set err_flag := true;
    end if;

    if err_flag = true then
      set out_result = 0;
      set out_msg = err_msg;
      leave me;
    end if;

    START TRANSACTION;

    update div_trn_tfile set
    update_date = sysdate(),
    update_by = in_action_by,
    delete_flag = 'Y'
    where file_gid = in_file_gid
    and delete_flag = 'N';

    update div_trn_tsuccess as a
    inner join div_trn_tsuccess as b on a.prev_success_gid = b.success_gid and b.delete_flag = 'N'
    set a.prev_success_gid = 0,b.next_success_gid = 0,b.next_pay_mode = b.pay_mode
    where a.file_gid = in_file_gid
    and a.prev_success_gid > 0
    and a.div_gid = 0
    and a.delete_flag = 'N';

    delete from div_trn_tsuccess
    where file_gid = in_file_gid
    and div_gid = 0
    and delete_flag = 'N';

    delete from div_trn_terrline
    where file_gid = in_file_gid
    and delete_flag = 'N';

    COMMIT;

    set out_result = 1;
    set out_msg = 'File deleted successfully !';
    leave me;
  end if;


  -- failure
  if in_file_type = 3 then
    if exists (select failure_gid from div_trn_tfailure
      where file_gid = in_file_gid
      and div_gid > 0
      and delete_flag = 'N' limit 0,1) then
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    end if;

    if err_flag = true then
      set out_result = 0;
      set out_msg = err_msg;
      leave me;
    end if;

    START TRANSACTION;

    update div_trn_tfile set
    update_date = sysdate(),
    update_by = in_action_by,
    delete_flag = 'Y'
    where file_gid = in_file_gid
    and delete_flag = 'N';

    delete from div_trn_tfailure
    where file_gid = in_file_gid
    and div_gid = 0
    and delete_flag = 'N';

    delete from div_trn_terrline
    where file_gid = in_file_gid
    and delete_flag = 'N';

    COMMIT;

    set out_result = 1;
    set out_msg = 'File deleted successfully !';
    leave me;
  end if;

  -- reject
  if in_file_type = 4 then
    if exists (select reject_gid from div_trn_treject
      where file_gid = in_file_gid
      and div_gid > 0
      and delete_flag = 'N' limit 0,1) then
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    end if;

    if err_flag = true then
      set out_result = 0;
      set out_msg = err_msg;
      leave me;
    end if;

    START TRANSACTION;

    update div_trn_tfile set
    update_date = sysdate(),
    update_by = in_action_by,
    delete_flag = 'Y'
    where file_gid = in_file_gid
    and delete_flag = 'N';

    delete from div_trn_treject
    where file_gid = in_file_gid
    and div_gid = 0
    and delete_flag = 'N';

    delete from div_trn_terrline
    where file_gid = in_file_gid
    and delete_flag = 'N';

    COMMIT;

    set out_result = 1;
    set out_msg = 'File deleted successfully !';
    leave me;
  end if;

  -- warrant
  if in_file_type = 5 then
    if exists (select warrant_gid from div_trn_twarrant
      where file_gid = in_file_gid
      and div_gid > 0
      and delete_flag = 'N' limit 0,1) then
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    end if;

    if err_flag = true then
      set out_result = 0;
      set out_msg = err_msg;
      leave me;
    end if;

    START TRANSACTION;

    update div_trn_tfile set
    update_date = sysdate(),
    update_by = in_action_by,
    delete_flag = 'Y'
    where file_gid = in_file_gid
    and delete_flag = 'N';

    delete from div_trn_twarrant
    where file_gid = in_file_gid
    and div_gid = 0
    and delete_flag = 'N';

    delete from div_trn_terrline
    where file_gid = in_file_gid
    and delete_flag = 'N';

    COMMIT;

    set out_result = 1;
    set out_msg = 'File deleted successfully !';
    leave me;
  end if;

  -- warrant cancel
  if in_file_type = 6 then
    if exists (select warrantcancel_gid from div_trn_twarrantcancel
      where file_gid = in_file_gid
      and div_gid > 0
      and delete_flag = 'N' limit 0,1) then
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    end if;

    if err_flag = true then
      set out_result = 0;
      set out_msg = err_msg;
      leave me;
    end if;

    START TRANSACTION;

    update div_trn_tfile set
    update_date = sysdate(),
    update_by = in_action_by,
    delete_flag = 'Y'
    where file_gid = in_file_gid
    and delete_flag = 'N';

    delete from div_trn_twarrantcancel
    where file_gid = in_file_gid
    and div_gid = 0
    and delete_flag = 'N';

    delete from div_trn_terrline
    where file_gid = in_file_gid
    and delete_flag = 'N';

    COMMIT;

    set out_result = 1;
    set out_msg = 'File deleted successfully !';
    leave me;
  end if;

  -- warrant cancel
  if in_file_type = 7 then
    if exists (select div_gid from div_trn_tdividend
      where file_gid = in_file_gid
      and tran_cr_gid > 0
      and delete_flag = 'N' limit 0,1)
      or
      exists (select a.div_gid from div_trn_tdividend as a
      inner join div_trn_tsuccess as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = in_file_gid
      and a.delete_flag = 'N' limit 0,1)
      or
      exists (select a.div_gid from div_trn_tdividend as a
      inner join div_trn_tfailure as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = in_file_gid
      and a.delete_flag = 'N' limit 0,1)
      or
      exists (select a.div_gid from div_trn_tdividend as a
      inner join div_trn_treject as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = in_file_gid
      and a.delete_flag = 'N' limit 0,1)
      or
      exists (select a.div_gid from div_trn_tdividend as a
      inner join div_trn_twarrant as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = in_file_gid
      and a.delete_flag = 'N' limit 0,1)
      or
      exists (select a.div_gid from div_trn_tdividend as a
      inner join div_trn_twarrantcancel as b on a.div_gid = b.div_gid and b.delete_flag = 'N'
      where a.file_gid = in_file_gid
      and a.delete_flag = 'N' limit 0,1)
      then
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    end if;

    if err_flag = true then
      set out_result = 0;
      set out_msg = err_msg;
      leave me;
    end if;

    START TRANSACTION;

    update div_trn_tfile set
    update_date = sysdate(),
    update_by = in_action_by,
    delete_flag = 'Y'
    where file_gid = in_file_gid
    and delete_flag = 'N';

    delete from div_trn_tdividend
    where file_gid = in_file_gid
    and delete_flag = 'N';

    delete from div_trn_terrline
    where file_gid = in_file_gid
    and delete_flag = 'N';

    COMMIT;

    set out_result = 1;
    set out_msg = 'File deleted successfully !';
    leave me;
  end if;
END $$

DELIMITER ;