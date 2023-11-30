DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_get_xltemplatefield` $$
CREATE PROCEDURE `pr_get_xltemplatefield`(
  in in_xltemplate_gid int
)
me:BEGIN
  select
    a.*,
    b.field_display_desc
  from sms_mst_txltemplatefield as a
  inner join sms_mst_tfield as b on a.field_name = b.field_name and b.delete_flag = 'N'
  where a.xltemplate_gid = in_xltemplate_gid
  and a.delete_flag = 'N';
 END $$

DELIMITER ;