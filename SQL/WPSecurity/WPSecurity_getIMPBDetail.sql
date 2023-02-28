﻿DECLARE @@GETWHERE VARCHAR(MAX);
DECLARE @@QUERY VARCHAR(MAX);
IF(@TYPE  = 'IMPB')
BEGIN
	SET @@GETWHERE = 'B.WP_IMPB_NO = '''+@ID+''' ';
END
ELSE
BEGIN
	SET @@GETWHERE = 'B.ID = '''+@ID+''' ';
END

SET @@QUERY = 'SELECT 
TOP 1
A.PROJECT_NAME AS PROJECT_NAME,
A.ID AS ID_PROJECT,
(SELECT LOC_NAME FROM TB_M_LOCATION WHERE ID_TB_M_LOCATION = A.ID_TB_M_LOCATION) AS LOKASI_PROYEK,
(SELECT AREA_NAME FROM TB_M_AREA WHERE ID_TB_M_AREA = A.ID_TB_M_AREA) AS AREA,
A.PROJECT_STATUS AS STATUS_IJIN_KERJA,
(SELECT distinct TOP 1 DIV FROM [dbo].[TB_M_ORG_RANK] where DIV_ID is not null AND DIV_ID = a.DEP_OR_DIV_CODE) AS DIVISI,
B.WP_IMPB_NO AS IMPB_NO,
(SELECT TOP 1 (SELECT SYSTEM_VALUE_TXT FROM TB_M_SYSTEM WHERE SYSTEM_ID = ''WP_WORKING_HOURS'' AND SYSTEM_TYPE = ''SHIFT'' +CONVERT(VARCHAR(5),TB_R_WP_DETAIL_SHIFT.SHIFT_ID) ) AS SHIFT_HOUR FROM TB_R_WP_DETAIL_SHIFT) AS JAM_PELAKSANAAN,
CONVERT(varchar(10), B.START_DATE, 120) AS MULAI_PELAKSANAAN,CONVERT(varchar(10),  B.END_DATE, 120) AS AKHIR_PELAKSANAAN FROM TB_R_WP_PROJECT AS A 
INNER JOIN TB_R_WP_PROJECT_JOB AS B ON A.ID = B.WP_PROJECT_ID  WHERE ';

SET @@QUERY = @@QUERY + @@GETWHERE;

EXEC(@@QUERY);
