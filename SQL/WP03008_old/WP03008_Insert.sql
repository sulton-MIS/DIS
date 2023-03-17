DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM TB_M_EMPLOYEE WHERE REG_NO = @RegNo AND USERNAME = @Username_member);
	IF(@@CNT > 0)
	BEGIN
		SELECT 
			@@MSG_TEXT = MSG_TEXT,
			@@MSG_TYPE = MSG_TYPE
		FROM dbo.FN_GENERATE_MSG('MPISSTD049E', 'REGISTER MEMBER : ' +@RegNo , NULL, NULL, NULL);
		SET @@CHK = 'FALSE';
		SET @@ERR = @@MSG_TEXT;
		
	END ELSE
	BEGIN
		
		INSERT INTO TB_M_EMPLOYEE
		(
			   REG_NO
			  ,FIRST_NAME
			  ,LAST_NAME
			  ,USERNAME
			  ,[PASSWORD]
			  ,EMAIL
			  ,[ADDRESS]
			  ,PHONE
			  ,IDENTITY_TYPE
			  ,IDENTITY_NO
			  ,SAFETY_INDUCTION_NO
			  ,SAFETY_INDUCTION_FROM
			  ,SAFETY_INDUCTION_TO
			  ,ID_TB_M_EMPLOYEE_ANZEN

			  ,ID_TB_M_COMPANY
			  ,PIC_STATUS
			  ,CREATE_BY
			  ,CREATE_DT
			  ,UPDATE_BY
			  ,UPDATE_DT
		)
		VALUES
		(
			@RegNo
			, @FirstName
            , @LastName
            , @Username_member
            , @Password
            , @Email
            , @Address
            , @Phone
            , @IdentityType
            , @IdentityNo
            , @SINo
            , @SIFrom
            , @SITo
            , @Anzen

			,NULL
			,'MEMBER'
			,@Username
			,GETDATE()
			,@Username
			,GETDATE()
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR REGISTER MEMBER :' +@RegNo+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
