DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_del_xltemplatefld` $$
CREATE PROCEDURE `pr_div_del_xltemplatefld`(
  in in_xltemplate_gid int,
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  start transaction;

  update div_mst_txltemplatefld set
  delete_flag = 'Y'
  where true
  and xltemplate_gid = in_xltemplate_gid
  and delete_flag = 'N';

  commit;

  set out_msg = concat('Record deleted successfully !');
  set out_result = 1;
END $$

DELIMITER ;