DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_set_fileremark` $$
CREATE PROCEDURE `pr_div_set_fileremark`(
  in_file_gid int,
  in_file_remark varchar(255)
)
BEGIN
  update div_trn_tfile set file_remark = in_file_remark,update_date=sysdate() 
  where file_gid = in_file_gid
  and delete_flag = 'N';
END $$

DELIMITER ;