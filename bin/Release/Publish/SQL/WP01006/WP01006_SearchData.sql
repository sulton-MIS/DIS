﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;


SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY A.ID_TB_M_COMPANY ASC) ROW_NUM,
		A.ID_TB_M_COMPANY AS ID,
		A.COMPANY_CODE,
		A.COMPANY_NAME,
		A.COMPANY_INITIAL,
		A.CONTACT_PERSON,
		A.EMAIL,
		A.ADDRESS,
		A.PHONE,
		A.STATUS,
		A.FLAG,
		A.CREATED_BY,
		A.CREATED_DT,
		A.UPDATED_BY,
		A.UPDATED_DT
		FROM TB_M_COMPANY AS A
		WHERE 1=1 AND IS_DELETED = 0
';


IF(@COMPANY_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.COMPANY_CODE LIKE ''%'+RTRIM(@COMPANY_CODE)+'%'' ';
	END

IF(@COMPANY_NAME <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.COMPANY_NAME LIKE ''%'+RTRIM(@COMPANY_NAME)+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)