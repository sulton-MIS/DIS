DECLARE @@QUERY VARCHAR(MAX);

SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
		SELECT 
			ROW_NUMBER() OVER (ORDER BY A.ID_TB_M_EMPLOYEE ASC) ROW_NUM
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


EXEC(@@QUERY);

