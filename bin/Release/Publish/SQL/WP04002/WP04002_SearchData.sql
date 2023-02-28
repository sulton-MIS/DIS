﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;


SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY A.ID_TB_M_ROLE ASC) ROW_NUM,
	A.ID_TB_M_ROLE AS ID,
	A.ROLE_NAME,
	A.ROLE_ST,
	A.ROLE_DESC,
	B.ID_TB_M_AUTHORIZATION_FUNCTION AS AUTH_ID,
	B.AUTHORIZATION_NAME AS AUTH_NAME,
	A.SESSION_TIME_OUT,
	A.LOCK_TIME_OUT,
	A.CREATED_BY,
	A.CREATED_DT,
	A.UPDATED_BY,
	A.UPDATED_DT
	FROM TB_M_ROLE AS A
	INNER JOIN TB_M_AUTHORIZATION_FUNCTION AS B ON A.ID_TB_M_AUTHORIZATION_FUNCTION = B.ID_TB_M_AUTHORIZATION_FUNCTION
	WHERE 1=1
';

IF(@ROLE_NAME <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.ROLE_NAME LIKE ''%'+@ROLE_NAME+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)