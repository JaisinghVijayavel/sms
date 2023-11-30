DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_upd_sender` $$

CREATE PROCEDURE `pr_upd_sender`(
  in in_sender_gid int,
  in in_sender_code varchar(16),
  in in_sender_name varchar(128),
  in in_active_status char(1),
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

  if in_sender_code = '' then
    set err_msg := concat(err_msg,'Blank sender code,');
    set err_flag := true;
  end if;

  if in_sender_name = '' then
    set err_msg := concat(err_msg,'Blank sender name,');
    set err_flag := true;
  end if;

  if in_active_status <> 'Y'
    and in_active_status <> 'N' then
    set err_msg := concat(err_msg,'Invalid active status,');
    set err_flag := true;
  end if;

  if not exists(select sender_gid from sms_mst_tsender
    where sender_gid = in_sender_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid sender gid,');
    set err_flag := true;
  end if;


  if exists(select sender_gid from sms_mst_tsender
    where sender_code = in_sender_code
    and sender_gid <> in_sender_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Sender code already exists,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  update sms_mst_tsender set
    sender_code = in_sender_code,
    sender_name = in_sender_name,
    active_status = in_active_status,
    update_date = sysdate(),
    update_by = in_action_by
  where sender_gid = in_sender_gid 
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;