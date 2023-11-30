DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_del_tranfile` $$
CREATE PROCEDURE `pr_div_del_tranfile`(
  in in_file_gid int,
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

  if exists(select tran_gid from div_trn_ttran
    where file_gid = in_file_gid
    and mapped_amount > 0
    and delete_flag = 'N') then
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

  COMMIT;

  set out_result = 1;
  set out_msg = 'File deleted successfully !';
 END $$

DELIMITER ;