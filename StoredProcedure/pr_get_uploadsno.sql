DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_get_uploadsno` $$

CREATE PROCEDURE `pr_get_uploadsno`()
me:BEGIN
  declare v_upload_sno int default 0;
  declare v_upload_code varchar(16) default '';
  declare v_txt varchar(16);

  select max(upload_sno) into v_upload_sno from sms_trn_tupload
  where delete_flag = 'N';

  set v_upload_sno = ifnull(v_upload_sno,0) + 1;

  set v_txt = cast(v_upload_sno as char);

  if length(v_txt) > 4 then
    set v_upload_code = v_txt;
  else
    set v_upload_code = lpad(v_upload_sno,4,'0000');
  end if;

  select v_upload_sno as upload_sno,v_upload_code as upload_code;
 END $$

DELIMITER ;