﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;


SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY A.ID_TB_M_ITEM ASC) ROW_NUM,
	A.ID_TB_M_ITEM AS ID,
	A.ITEM_NAME,
	A.ITEM_ST,
	A.ITEM_DESC,
	A.ITEM_TYPE,
	(SELECT SYSTEM_VALUE_TXT FROM TB_M_SYSTEM WHERE SYSTEM_ID = ''WP_ITEM_TYPE'' AND SYSTEM_CD = A.ITEM_TYPE) AS ITEM_TYPE_VAL,
	A.CREATED_BY,
	A.CREATED_DT,
	A.UPDATED_BY,
	A.UPDATED_DT
	FROM TB_M_ITEM AS A
	WHERE 1=1 AND IS_DELETED = 0
';

IF(@ITEM_NAME <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.ITEM_NAME LIKE ''%'+RTRIM(@ITEM_NAME)+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)