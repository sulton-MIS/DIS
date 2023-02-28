﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;


SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY A.ID_TB_M_WORKING_TYPE ASC) ROW_NUM,
	A.ID_TB_M_WORKING_TYPE AS ID,
	A.WORKING_NAME,
	A.STATUS,
	A.CREATE_BY,
	A.CREATE_DT,
	A.UPDATE_BY,
	A.ICON,
	A.UPDATE_DT
	FROM TB_M_WORKING_TYPE AS A
	WHERE 1=1 AND A.IS_DELETED = 0
';

IF(@WORKING_NAME <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.WORKING_NAME LIKE ''%'+RTRIM(@WORKING_NAME)+'%'' ';
	END
SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+RTRIM(@@DISPLAY)+''' ';
END

EXEC(@@QUERY)