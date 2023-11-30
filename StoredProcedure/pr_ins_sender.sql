DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_ins_sender` $$

CREATE PROCEDURE `pr_ins_sender`(
  in in_sender_code varchar(16),
  in in_sender_name varchar(128),
  in in_active_status char(1),
  in in_action_by varchar(16),
  out out_sender_gid int,
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

  if exists(select sender_gid from sms_mst_tsender
    where sender_code = in_sender_code
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

  INSERT INTO sms_mst_tsender
  (
    sender_code,
    sender_name,
    active_status,
    insert_date,
    insert_by
  )
  VALUES
  (
    in_sender_code,
    in_sender_name,
    in_active_status,
    sysdate(),
    in_action_by
  );

  COMMIT;

  select max(sender_gid) into out_sender_gid from sms_mst_tsender;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;