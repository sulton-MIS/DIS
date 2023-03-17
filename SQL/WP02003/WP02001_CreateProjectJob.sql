﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM TB_R_WP_PROJECT_JOB WHERE ID = @WP_PROJECT_JOB_ID);
	IF(@@CNT > 0)
	BEGIN
		UPDATE TB_R_WP_PROJECT_JOB
		SET JOB_NAME = @JOB_NAME,
			[CHANGED_BY] = @username,
			[CHANGED_DT] = GETDATE()
		WHERE ID = @WP_PROJECT_JOB_ID

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END ELSE
	BEGIN
		INSERT INTO TB_R_WP_PROJECT_JOB
		(
			WP_PROJECT_ID ,
			JOB_NAME ,
			WP_IMPB_NO ,
			CREATED_BY ,
			CREATED_DT ,
			CHANGED_BY ,
			CHANGED_DT 
			
		)
		VALUES
		(
			@WP_PROJECT_ID,
			@JOB_NAME,
			@WP_IMPB_NO,
			@username,
			GETDATE(),
			@username,
			GETDATE()
		);

		SET @@CNT = SCOPE_IDENTITY();
		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT WP_PROJECT_JOB:' +@JOB_NAME+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS,CAST(@@CNT AS VARCHAR(20)) AS WP_PROJECT_JOB_ID