DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
BEGIN TRY
	UPDATE TB_R_LEARN_REG_PROJ_EMPLOYEE SET 
							ID_TB_M_EMPLOYEE = @Worker
							,ID_TB_R_WP_PROJECT = @Project
							,ID_TB_M_COMPANY = @Company
							,DATE_JOIN_PROJECT = @JoinDate
							,COMPANY_FROM = @Company_from
							,COMPANY_TO = @Company_to

							,UPDATED_BY = @Username
							,UPDATED_DT = GETDATE()
					WHERE ID_TB_R_LEARN_REG_PROJ_EMPLOYEE = @ID
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE TB_R_LEARN_REG_PROJ_EMPLOYEE:' +@Worker+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS