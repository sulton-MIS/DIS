DECLARE @@QUERY VARCHAR(MAX);
SET @@QUERY = '';
SET @@QUERY = 'SELECT ISNULL(max(ROW_NUM),0)  
			   FROM(
					select  ROW_NUMBER() OVER (ORDER BY wp.ID ASC) ROW_NUM,
							wp.ID as WP_DAILY_ID, 
							wp.TB_R_WP_PROJECT_ID AS PROJECT_ID, 
							wp.TB_R_WP_PROJECT_JOB_ID as PROJECT_JOB_ID, 
							pr.PROJECT_NAME, 
							pr.IMPLEMENT_DATE_FROM as DATE_FROM, 
							pr.IMPLEMENT_DATE_TO as DATE_TO, 
							ar.AREA_NAME as PROJECT_LOCATION, 
							pr.DEP_OR_DIV_CODE as DIVISI  
					from TB_R_WP_DAILY wp 
					left join TB_R_WP_PROJECT pr 
					on pr.ID = wp.TB_R_WP_PROJECT_ID 
					left join TB_M_AREA ar 
					on ar.ID_TB_M_AREA = pr.ID_TB_M_AREA 
					where 1=1 and wp.ACTIVE = 1 ';

IF(@PROJECT_NAME <> '')
BEGIN
	SET @@QUERY = @@QUERY + 'AND PROJECT_NAME LIKE ''%'+@PROJECT_NAME+'%'' ';
END

SET @@QUERY = @@QUERY +') as TB';

EXEC(@@QUERY)