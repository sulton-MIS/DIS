﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;


SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY A.USERNAME ASC) ROW_NUM,
	A.USERNAME AS ID,
	A.USERNAME,
	A.PLANT_CD,
	A.PLANT_NM,
	A.COMPANY,
	A.CREATED_BY,
	A.CREATED_DT,
	A.CHANGED_BY as UPDATED_BY,
	A.CHANGED_DT as UPDATED_DT
	FROM TB_M_USER_PLANT AS A
	WHERE 1=1
';

IF(@USERNAME <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.USERNAME LIKE ''%'+@USERNAME+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)