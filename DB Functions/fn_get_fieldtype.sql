DELIMITER $$

DROP function IF EXISTS fn_get_fieldtype $$

create function fn_get_fieldtype
(
  in_field_name varchar(128)
) returns varchar(8)
begin
  declare ret varchar(8);

  select
    field_type into ret
  from sms_mst_tfield
  where field_name = in_field_name
  and delete_flag = 'N';

  return ret;
END $$
DELIMITER ;