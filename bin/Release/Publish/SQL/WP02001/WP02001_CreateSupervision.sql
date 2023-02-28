﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM TB_R_WP_DETAIL_SUPERVISION WHERE ID = @ID);
	IF(@@CNT > 0)
	BEGIN

		UPDATE TB_R_WP_DETAIL_SUPERVISION 
			SET ID_TB_M_EMPLOYEE = @ID_TB_M_EMPLOYEE,	
				[CHANGED_BY] = @username,
				[CHANGED_DT] = GETDATE()
		WHERE ID = @ID;

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

	END ELSE
	BEGIN
		INSERT INTO TB_R_WP_DETAIL_SUPERVISION
		(
			 [WP_PROJECT_JOB_ID]
			,ID_TB_M_EMPLOYEE
			,[CREATED_BY]
			,[CREATED_DT]
			,[CHANGED_BY]
			,[CHANGED_DT]
		)
		VALUES
		(
			@WP_PROJECT_JOB_ID,
			@ID_TB_M_EMPLOYEE
			,@username,
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
	SET @@ERR = 'ERROR INSERT WP_HEADER:' +@WP_IMPB_NO+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS