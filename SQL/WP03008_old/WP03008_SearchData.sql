﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;


SET @@QUERY = '';
SET @@QUERY = '
SELECT 
	*
FROM 
(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY A.ID_TB_M_EMPLOYEE ASC) ROW_NUM,
		A.ID_TB_M_EMPLOYEE AS ID,
		A.REG_NO,
		A.FIRST_NAME,
		A.LAST_NAME,
		A.USERNAME,
		A.EMAIL,
		A.ADDRESS,
		A.PHONE,
		A.IDENTITY_TYPE,
		A.IDENTITY_NO,
		A.SAFETY_INDUCTION_NO,
		convert(varchar(10), A.SAFETY_INDUCTION_FROM, 120) AS SI_FROM,
		convert(varchar(10), A.SAFETY_INDUCTION_TO, 120) AS SI_TO,
		A.IS_DELETED,
		A.CREATE_BY,
		A.CREATE_DT,
		A.UPDATE_BY,
		A.UPDATE_DT
	FROM 
		TB_M_EMPLOYEE AS A
	WHERE 
		A.IS_DELETED = 0
		AND A.ID_TB_M_COMPANY IS NULL
		AND A.PIC_STATUS = ''MEMBER''
';

IF(@Anzen <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.ID_TB_M_EMPLOYEE_ANZEN = '''+@Anzen+''' ';
	END
IF(@RegNo <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.REG_NO LIKE ''%'+@RegNo+'%'' ';
	END
IF(@IdentityNo <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.IDENTITY_NO LIKE ''%'+@IdentityNo+'%'' ';
	END
IF(@UserName <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.USERNAME LIKE ''%'+@UserName+'%'' ';
	END
IF(@Email <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.EMAIL LIKE ''%'+@Email+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)