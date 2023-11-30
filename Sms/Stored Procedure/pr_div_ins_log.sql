DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_ins_log` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_div_ins_log`(
  in in_log_desc varchar(255),
  in in_system_ip varchar(16),
  in in_action_by varchar(16)
)
BEGIN
  insert into div_trn_tlog (log_date,log_by,log_desc,system_ip) values
  (sysdate(),in_action_by,in_log_desc,in_system_ip);
END $$

DELIMITER ;