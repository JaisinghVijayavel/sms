DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_upd_field` $$

CREATE PROCEDURE `pr_upd_field`(
  in in_field_gid int,
  in in_field_display_desc varchar(128),
  in in_field_type varchar(8),
  in in_field_template_code varchar(128),
  in in_field_display_flag char(1),
  in in_field_display_order int,
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

  if in_field_display_flag <> 'Y'
    and in_field_display_flag <> 'N' then
    set err_msg := concat(err_msg,'Invalid display flag,');
    set err_flag := true;
  end if;

  if in_field_display_flag = 'Y' then
    if in_field_display_desc = '' then
      set err_msg := concat(err_msg,'Display name cannot be blank,');
      set err_flag := true;
    end if;

    if in_field_template_code = '' then
      set err_msg := concat(err_msg,'Template code cannot be blank,');
      set err_flag := true;
    end if;

    if in_field_display_order <= 0 then
      set err_msg := concat(err_msg,'Invalid display order,');
      set err_flag := true;
    end if;
  end if;

  if not exists(select field_type from sms_mst_tfieldtype
    where field_type = in_field_type
    and active_status = 'Y'
    and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Invalid field type,');
    set err_flag := true;
  end if;

  if in_active_status <> 'Y'
    and in_active_status <> 'N' then
    set err_msg := concat(err_msg,'Invalid active status,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  update sms_mst_tfield set
    field_display_desc = in_field_display_desc,
    field_type = in_field_type,
    field_template_code = in_field_template_code,
    field_display_flag = in_field_display_flag,
    field_display_order = in_field_display_order,
    active_status = in_active_status,
    update_date = sysdate(),
    update_by = in_action_by
  where field_gid = in_field_gid
  and delete_flag = 'N';

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;