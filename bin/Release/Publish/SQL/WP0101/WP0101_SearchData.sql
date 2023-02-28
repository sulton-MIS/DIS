DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;


SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY a.ID ASC) ROW_NUM,
	ID, Project_CD, Project_Name, c.LOC_NAME as Location, convert(varchar(10),Tanggal_Pelaksanaan) as Tanggal_Pelaksanaan, convert(varchar(25), Jam_Pelaksanaan, 120) AS Jam_Pelaksanaan, Divisi_Dept AS DIVISION, SYSTEM_VALUE_TXT AS Status, Status AS Status_ID, Pelaksana, Nama_Kontraktor,
	Nama_Pimpinan AS NAMA_PIMPINAN, Nama_Pengawas, CREATE_BY, CREATE_DT, UPDATE_BY AS CHANGED_BY, UPDATE_DT AS CHANGED_DT
	FROM dbo.TB_R_WP_HEADER as a  LEFT JOIN (SELECT SYSTEM_CD, SYSTEM_VALUE_TXT FROM TB_M_SYSTEM WHERE SYSTEM_ID = ''WP_STATUS'') AS b ON a.Status = b.SYSTEM_CD
	LEFT JOIN (SELECT LOC_NAME, LOC_CD FROM TB_M_LOC) AS c ON a.Location = c.LOC_NAME
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