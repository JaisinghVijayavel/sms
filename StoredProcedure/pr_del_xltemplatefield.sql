DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_del_xltemplatefield` $$

CREATE PROCEDURE `pr_del_xltemplatefield`(
  in in_xltemplate_gid int,
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

    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if not exists(select xltemplate_gid from sms_mst_txltemplate
    where xltemplate_gid = in_xltemplate_gid
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid xltemplate name,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  update sms_mst_txltemplatefield set
    delete_flag = 'Y',
    update_date = sysdate(),
    update_by = in_action_by
  where xltemplate_gid = in_xltemplate_gid
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;