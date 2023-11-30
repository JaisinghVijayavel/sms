DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_del_sender` $$

CREATE PROCEDURE `pr_del_sender`(
  in in_sender_gid int,
  in in_action_by varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag varchar(10) default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if not exists(select sender_gid from sms_mst_tsender
    where sender_gid = in_sender_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid sender gid,');
    set err_flag := true;
  end if;

  if exists(select sender_gid from sms_trn_ttran
    where sender_gid = in_sender_gid
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

  update sms_mst_tsender set
    delete_flag = 'Y',
    update_date = sysdate(),
    update_by = in_action_by
  where sender_gid = in_sender_gid
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;