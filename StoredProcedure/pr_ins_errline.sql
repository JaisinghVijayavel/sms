DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_ins_errline` $$
CREATE PROCEDURE `pr_ins_errline`(
  in_file_gid int,
  in_errline_no int,
  in_errline_desc text
)
BEGIN
  insert into sms_trn_terrline (file_gid,errline_no,errline_desc) values
  (in_file_gid,in_errline_no,in_errline_desc);
END $$

DELIMITER ;