﻿DECLARE @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);
BEGIN TRY
	IF (@ACTION = 'add')
	BEGIN
		INSERT INTO TB_R_WP_DAILY_WI_DEN
		(
			[ID]
			,[TB_R_WP_DAILY_ID]
			,[WORKING_NAME]
			,[TIME_FROM]
			,[TIME_TO]
			,[STOP_SIX]
			,[TB_M_EMPLOYEE_ID]
			,[CREATE_BY]
			,[CREATE_DT]
			,[UPDATE_BY]
			,[UPDATE_DT]
		)
		VALUES
		(
			@TB_R_WP_DAILY_WI_DEN_ID,
			@TB_R_WP_DAILY_ID,
			@WORKING_NAME,
			@TIME_FROM,
			@TIME_TO,
			@STOP_SIX,
			@TB_M_EMPLOYEE_ID,
			@username,
			GETDATE(),
			@username,
			GETDATE()
		);
	END
	ELSE
	BEGIN
		UPDATE TB_R_WP_DAILY_WI_DEN
		SET TB_M_EMPLOYEE_ID = @TB_M_EMPLOYEE_ID,
		WORKING_NAME = @WORKING_NAME,
		TIME_FROM = @TIME_FROM,
		TIME_TO = @TIME_TO,
		STOP_SIX = @STOP_SIX,
		UPDATE_BY = @username,
		UPDATE_DT = GETDATE()
		WHERE ID = @TB_R_WP_DAILY_WI_DEN_ID AND TB_R_WP_DAILY_ID = @TB_R_WP_DAILY_ID;
	END;

	SET @@CHK = 'TRUE';
	SET @@ERR = 'NOTHING';
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT TB_R_WP_DAILY_WI_DEN:' +@TB_R_WP_DAILY_WI_DEN_ID+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS