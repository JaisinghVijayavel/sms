DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_get_menuaccess` $$
CREATE PROCEDURE `pr_get_menuaccess`(
  in in_menu_name varchar(255),
  in in_user_gid int,
  in in_usergroup_gid int,
  in in_user_code varchar(16),
  in in_pwd varchar(255)
)
me:BEGIN
  select count(*) from soft_mst_trights as a
  inner join soft_mst_tuser as b on a.usergroup_gid = b.usergroup_gid
  and b.user_code = in_user_code
  and b.pwd = in_pwd
  and b.delete_flag = 'N'
  where a.usergroup_gid = in_usergroup_gid
  and a.menu_name = in_menu_name
  and a.rights_flag = 1
  and a.delete_flag = 'N';
END $$

DELIMITER ;