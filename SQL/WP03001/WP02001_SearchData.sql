﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;


SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY a.ID ASC) ROW_NUM,
	ID, PROJECT_CODE, PROJECT_NAME, ID_TB_M_LOC AS LOC_CD, (SELECT LOC_NAME FROM TB_M_LOC WHERE LOC_CD = a.ID_TB_M_LOC) AS LOCATION, 
	convert(varchar(10),IMPLEMENTATION_DATE) as IMPLEMENTATION_DATE, convert(varchar(25), IMPLEMENTATION_TIME, 120) AS IMPLEMENTATION_TIME, 
	DIVISION, Status, EXECUTOR, CONTRACTOR,
	LEADER, SUPERVISOR, CREATED_BY, CREATED_DT, CHANGED_BY, CHANGED_DT
	FROM dbo.TB_R_WP_HEADER as a 
	WHERE 1=1
';

IF(@PROJECT_NAME <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND Project_Name LIKE ''%'+@PROJECT_NAME+'%'' ';
	END

IF(@PROJECT_LOCATION <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND Location LIKE ''%'+@PROJECT_LOCATION+'%'' ';
	END

IF(@PROJECT_DATE <> '' AND @PROJECT_DATETO <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND Tanggal_Pelaksanaan BETWEEN '''+@PROJECT_DATE+''' AND '''+@PROJECT_DATETO+''' ';
	END

IF(@PROJECT_TIME <> '' AND @PROJECT_TIMETO <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND Jam_Pelaksanaan BETWEEN '''+@PROJECT_DATE+''' AND '''+@PROJECT_DATETO+''' ';
	END

IF(@DIVISION <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND Divisi_Dept LIKE ''%'+@DIVISION+'%'' ';
	END

IF(@STATUS <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND Status = '''+@STATUS+''' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)