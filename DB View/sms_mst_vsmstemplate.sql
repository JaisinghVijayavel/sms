alter view sms_mst_vsmstemplate as
  select a.*,b.sender_code,b.sender_name from sms_mst_tsmstemplate as a
  left join sms_mst_tsender as b on a.sender_gid = b.sender_gid and b.delete_flag = 'N'
  where a.delete_flag = 'N'
  order by smstemplate_gid;
