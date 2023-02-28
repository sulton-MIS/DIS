select  wp.ID as TB_R_WP_DAILY_ID, 
		wd.ID as TB_R_WP_DAILY_WI_DEN_ID, 
		wd.WORKING_NAME,
		convert(char(5), wd.TIME_FROM, 108) AS TIME_FROM,
		convert(char(5), wd.TIME_TO, 108) AS TIME_TO,
		wd.STOP_SIX,
		wd.TB_M_EMPLOYEE_ID,
		(select itm.FIRST_NAME from TB_M_EMPLOYEE itm where itm.ID_TB_M_EMPLOYEE = wd.TB_M_EMPLOYEE_ID) as ITEM_NAME
from TB_R_WP_DAILY wp 
inner join TB_R_WP_DAILY_WI_DEN wd 
on wd.TB_R_WP_DAILY_ID = wp.ID
WHERE wp.ID = @WP_DAILY_ID