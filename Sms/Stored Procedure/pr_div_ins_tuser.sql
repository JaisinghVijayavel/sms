DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_div_ins_tuser` $$
CREATE PROCEDURE `pr_div_ins_tuser`(
  in in_user_gid int,
  in in_user_code varchar(16),
  in in_user_name varchar(128),
  in in_addr1 varchar(64),
  in in_addr2 varchar(64),
  in in_addr3 varchar(64),
  in in_addr4 varchar(64),
  in in_city varchar(64),
  in in_pincode varchar(8),
  in in_sex varchar(8),
  in in_dob date,
  in in_doj date,
  in in_dor date,
  in in_desig_name varchar(64),
  in in_dept_name varchar(64),
  in in_user_status char(1),
  in in_pwd varchar(64),
  in in_usergroup_gid int,
  in in_auth_desc varchar(255),
  in in_auth_dtl text,
  in in_action varchar(8),
  in in_action_by varchar(10),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_user_gid int default 0;
  declare v_auth_sql text default '';
  declare v_reject_sql text default '';
  declare v_auth_desc varchar(255) default '';

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set out_msg = 'SQLEXCEPTION';
    set out_result = 0;
  END;


  if in_action = 'INSERT' or in_action = 'UPDATE' then
    if in_user_code = '' then
      set err_msg := concat(err_msg,'User code cannot be empty,');
      set err_flag := true;
    end if;

    if in_user_name = '' then
      set err_msg := concat(err_msg,'User name cannot be empty,');
      set err_flag := true;
    end if;

    if in_sex = '' then
      set err_msg := concat(err_msg,'Sex cannot be empty,');
      set err_flag := true;
    end if;

    if in_desig_name = '' then
      set err_msg := concat(err_msg,'Designation cannot be empty,');
      set err_flag := true;
    end if;

    if in_dept_name = '' then
      set err_msg := concat(err_msg,'Department cannot be empty,');
      set err_flag := true;
    end if;
  end if;

  if in_action = 'UPDATE' or in_action = 'DELETE' then
    if in_user_gid = 0 then
      set err_msg := concat(err_msg,'Please select the user,');
      set err_flag := true;
    end if;
  end if;

  if err_flag = false then
    if in_action = 'INSERT' then
      if exists(select user_gid from soft_mst_tuser
        where user_code = in_user_code
        and delete_flag = 'N') then
        set err_msg := concat(err_msg,'Duplicate record,');
        set err_flag := true;
      end if;
    end if;

    if in_action = 'UPDATE' then
      if exists(select user_gid from soft_mst_tuser
        where user_code = in_user_code
        and user_gid <> in_user_gid
        and delete_flag = 'N') then
        set err_msg := concat(err_msg,'Duplicate record,');
        set err_flag := true;
      end if;
    end if;

    if in_action = 'DELETE' then
      if exists(select acc_no from div_trn_ttran
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        or exists(select acc_no from div_trn_tdividend
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        or exists(select acc_no from div_trn_treject
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        or exists(select acc_no from div_trn_tfailure
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        or exists(select acc_no from div_trn_tsuccess
        where acc_no = in_acc_no
        and delete_flag = 'N' limit 0,1)
        then
        set err_msg := concat(err_msg,'Duplicate record,');
        set err_flag := true;
      end if;
    end if;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  if in_action = 'INSERT' then
    insert into soft_mst_tuser
    (
      user_code,
      user_name,
      addr1,
      addr2,
      addr3,
      addr4,
      city,
      pincode,
      contact_no,
      sex,
      dob,
      doj,
      desig_name,
      dept_name,
      user_status,
      pwd,
      usergroup_gid
    )
    values
    (
      in_user_code,
      in_user_name,
      in_addr1,
      in_addr2,
      in_addr3,
      in_addr4,
      in_city,
      in_pincode,
      in_contact_no,
      in_sex,
      in_dob,
      in_doj,
      in_design_name,
      in_dept_name,
      in_user_status,
      in_pwd,
      in_usergroup_gid
    );

    select user_gid into v_user_gid from soft_mst_tuser
    where user_code = in_user_code
    and delete_flag = 'N';

    set v_user_gid = ifnull(v_user_gid,0);

    if in_dor <> null then
      update soft_mst_tuser set
        dor = in_dor
      where user_gid = v_user_gid
      and delete_flag = 'N';
    end if;

    set v_auth_sql = concat(v_auth_sql,'update soft_mst_tuser set auth_flag = ',char(39),'Y',char(39),' ');
    set v_auth_sql = concat(v_auth_sql,'where user_gid = ',char(39),cast(v_user_gid as char),char(39),' ');
    set v_auth_sql = concat(v_auth_sql,'and delete_flag = ',char(39),'N',char(39),' ');

    set v_reject_sql = concat(v_reject_sql,'update soft_mst_tuser set auth_flag = ',char(39),'R',char(39),',');
    set v_reject_sql = concat(v_reject_sql,'delete_flag = ',char(39),'Y',char(39),' ');
    set v_reject_sql = concat(v_reject_sql,'where user_gid = ',char(39),cast(v_user_gid as char),char(39),' ');
    set v_reject_sql = concat(v_reject_sql,'and delete_flag = ',char(39),'N',char(39),' ');

    set out_msg = 'Added User Information Send for Approval...';
  end if;

  if in_action = 'UPDATE' then
    set v_auth_sql = concat(v_auth_sql,'update soft_mst_tuser set ');
    set v_auth_sql = concat(v_auth_sql,'user_code = ',char(39),in_user_code,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'user_name = ',char(39),in_user_name,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'addr1 = ',char(39),in_addr1,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'addr2 = ',char(39),in_addr2,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'addr3 = ',char(39),in_addr3,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'addr4 = ',char(39),in_addr4,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'city = ',char(39),in_city,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'pincode = ',char(39),in_pincode,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'contact_no = ',char(39),in_contact_no,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'login_date = sysdate(),');
    set v_auth_sql = concat(v_auth_sql,'sex = ',char(39),in_sex,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'dob = ',char(39),date_format(in_dob,'%Y-%m-%d'),char(39),',');
    set v_auth_sql = concat(v_auth_sql,'doj = ',char(39),date_format(in_doj,'%Y-%m-%d'),char(39),',');

    if in_dor = null then
      set v_auth_sql = concat(v_auth_sql,'dor = null,');
    else
      set v_auth_sql = concat(v_auth_sql,'dor = ',char(39),date_format(in_dor,'%Y-%m-%d'),char(39),',');
    end if;

    set v_auth_sql = concat(v_auth_sql,'desig_name = ',char(39),in_desig_name,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'dept_name = ',char(39),in_dept_name,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'usergroup_gid = ',char(39),in_usergroup_gid,char(39),',');
    set v_auth_sql = concat(v_auth_sql,'user_status = ',char(39),in_user_statu,char(39),' ');
    set v_auth_sql = concat(v_auth_sql,'where user_gid = ',char(39),in_user_gid,char(39),' ');
    set v_auth_sql = concat(v_auth_sql,'and delete_flag = ',char(39),'N',char(39));

    set v_reject_sql = '';

    set out_msg = 'Updated User Information Send for Approval...';
  end if;

  if in_action = 'DELETE' then
    set v_auth_sql = concat(v_auth_sql,'update soft_mst_tuser set delete_flag = ',char(39),'Y',char(39),' ');
    set v_auth_sql = concat(v_auth_sql,'where user_gid = ',char(39),cast(v_user_gid as char),char(39),' ');
    set v_auth_sql = concat(v_auth_sql,'and delete_flag = ',char(39),'N',char(39),' ');

    set out_msg = 'Record Deletion Send for Approval...';
  end if;

  insert into soft_trn_tauth
  (
    entry_date,
    entry_by,
    qry_desc,
    qry_detail,
    auth_qry,
    reject_qry
  )
  values
  (
    sysdate(),
    in_action,
    in_auth_desc,
    in_auth_dtl,
    v_auth_sql,
    v_reject_sql
  );

  set out_result = 1;
 END $$

DELIMITER ;