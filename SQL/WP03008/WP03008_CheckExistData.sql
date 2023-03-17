
--select
--	COUNT(A.ID_TB_M_EMPLOYEE)
--from 
--	TB_M_EMPLOYEE A
--where 
--	A.REG_NO = '' + @param1 + ''
DECLARE @@QUERY VARCHAR(MAX);

IF(@param_data = 'RegNo')
	BEGIN
		SET @@QUERY = 'select COUNT(A.ID_TB_M_EMPLOYEE) from TB_M_EMPLOYEE A where A.REG_NO = '''+@param1+''' ';
	END

IF(@param_data = 'IdentityNo')
	BEGIN
		SET @@QUERY = 'select COUNT(A.ID_TB_M_EMPLOYEE) from TB_M_EMPLOYEE A where A.IDENTITY_NO = '''+@param1+''' ';
	END

IF(@param_data = 'UserName')
	BEGIN
		SET @@QUERY = 'select COUNT(A.ID_TB_M_EMPLOYEE) from TB_M_EMPLOYEE A where A.USERNAME = '''+@param1+''' ';
	END

IF(@param_data = 'Email')
	BEGIN
		SET @@QUERY = 'select COUNT(A.ID_TB_M_EMPLOYEE) from TB_M_EMPLOYEE A where A.EMAIL = '''+@param1+''' ';
	END

EXEC(@@QUERY)