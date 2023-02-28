select  wp.ID as TB_R_WP_DAILY_ID, 
		wd.ID as ID, 
		wp.TITLE,
		wp.DAILY_DOC,
		wd.TB_M_ITEM_ID AS ID_TB_M_ITEM,
		(select itm.ITEM_NAME from TB_M_ITEM itm where itm.ID_TB_M_ITEM = wd.TB_M_ITEM_ID) as ITEM_NAME
from TB_R_WP_DAILY wp 
inner join TB_R_WP_DAILY_WORK_EQUIPMENT wd 
on wd.TB_R_WP_DAILY_ID = wp.ID
WHERE wp.ID = @WP_DAILY_ID