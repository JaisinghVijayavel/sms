DELIMITER $$

DROP PROCEDURE IF EXISTS pr_div_ins_tranacc $$
CREATE PROCEDURE pr_div_ins_tranacc(in in_file_gid int)
me:BEGIN
  START TRANSACTION;

  INSERT INTO div_trn_ttranacc (file_gid,tran_date,acc_no)
  select distinct file_gid,tran_date,acc_no from div_trn_ttran
  where file_gid = in_file_gid
  and delete_flag = 'N';

  COMMIT;
 END $$

DELIMITER ;