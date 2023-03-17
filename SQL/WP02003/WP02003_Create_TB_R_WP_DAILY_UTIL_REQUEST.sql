﻿DECLARE @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);
BEGIN TRY
	
	INSERT INTO TB_R_WP_DAILY_UTIL_REQUEST
	(
		[ID]
		,[TB_R_WP_DAILY_ID]
		,[TB_M_ITEM_ID]
		,[CREATE_BY]
		,[CREATE_DT]
		,[UPDATE_BY]
		,[UPDATE_DT]
	)
	VALUES
	(
		@TB_R_WP_DAILY_UTIL_REQUEST_ID,
		@TB_R_WP_DAILY_ID,
		@TB_M_ITEM_ID,
		@username,
		GETDATE(),
		@username,
		GETDATE()
	);

	SET @@CHK = 'TRUE';
	SET @@ERR = 'NOTHING';
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT TB_R_WP_DAILY_UTIL_REQUEST:' +@TB_R_WP_DAILY_UTIL_REQUEST_ID+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS