DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_del_xltemplate` $$
CREATE PROCEDURE `pr_div_del_xltemplate`(
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
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;

  if exists(select file_gid from div_trn_tfile
    where xltemplate_gid = in_xltemplate_gid
    and delete_flag = 'N') then
    set out_msg = concat(err_msg,'Access denied !');
    set out_result = 0;
    leave me;
  end if;

  start transaction;

  update div_mst_txltemplate set
  delete_flag = 'Y',
  update_date = sysdate(),
  update_by = in_action_by
  where true
  and xltemplate_gid = in_xltemplate_gid
  and delete_flag = 'N';

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