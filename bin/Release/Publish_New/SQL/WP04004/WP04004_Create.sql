﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM TB_M_USER_PLANT WHERE USERNAME = @USERNAME);
	IF(@@CNT > 0)
	BEGIN
		SET @@CHK = 'FALSE';
		SET @@ERR = 'Data Has been Registered';
		
	END ELSE
	BEGIN
		
		INSERT INTO TB_M_USER_PLANT
		(
			 [USERNAME]
			,[PLANT_CD]
			,[PLANT_NM]
			,[COMPANY]
			,[CREATED_BY]
			,[CREATED_DT]
			,[CHANGED_BY]
			,[CHANGED_DT]
			
		)
		VALUES
		(
			@USERNAME,
			@PLANT_CD,
			@PLANT_NM,
			@COMPANY,
			@username,
			GETDATE(),
			@username,
			GETDATE()
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT TB_M_USER_PLANT:' +@USERNAME+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS