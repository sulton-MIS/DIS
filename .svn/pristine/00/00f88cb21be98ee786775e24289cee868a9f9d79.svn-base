DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
BEGIN TRY
	UPDATE TB_M_EMPLOYEE SET 
							REG_NO = @RegNo
							,FIRST_NAME = @FirstName
							,LAST_NAME = @LastName
							,USERNAME = @Username_member
							,EMAIL = @Email
							,[ADDRESS] = @Address
							,PHONE = @Phone
							,IDENTITY_TYPE = @IdentityType
							,IDENTITY_NO = @IdentityNo
							,SAFETY_INDUCTION_NO = @SINo
							,SAFETY_INDUCTION_FROM = @SIFrom
							,SAFETY_INDUCTION_TO = @SITo

							,UPDATE_BY = @Username
							,UPDATE_DT = GETDATE()
					WHERE ID_TB_M_EMPLOYEE = @Id
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ID_TB_M_EMPLOYEE:' +@RegNo+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS