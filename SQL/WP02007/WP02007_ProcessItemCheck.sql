﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@MSG VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);
DECLARE @@CHK_DELETE VARCHAR(5);
DECLARE @@COUNTER INT;
DECLARE @@MSG_START VARCHAR(MAX);
DECLARE @@MSG_SUCCESS VARCHAR(MAX);
DECLARE @@MSG_END VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM TB_R_WP_DETAIL_ITEM_CHECK WHERE ID = @ID);
	IF(@@CNT > 0)
	BEGIN
		SET @@COUNTER = (SELECT (CASE WHEN (SELECT COUNT(PROCESS_ID) FROM TB_R_LOG_H) = 0 THEN 1 ELSE (SELECT TOP 1 PROCESS_ID FROM TB_R_LOG_H ORDER BY PROCESS_ID DESC) + 1 END));
		EXEC SP_INSERT_UPDATE_LOG_H @username,'','WP02007',1,'1','Update',@@COUNTER;

		SET @@MSG_START = 'LOG001 : '+ (SELECT dbo.GenerateMessage('LOG001','','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Start', 'LOG001', 'Info',  @@MSG_START;
		
		UPDATE TB_R_WP_DETAIL_ITEM_CHECK
		SET ITEM_NAME = @ITEM_NAME,
			ID_TB_M_EMPLOYEE = @ID_TB_M_EMPLOYEE,
			ITEM_STATUS = @ITEM_STATUS,
			ITEM_DESCRIPTION = @ITEM_DESCRIPTION,
			[CHANGED_BY] = @username,
			[CHANGED_DT] = GETDATE()
		WHERE ID = @WP_PROJECT_JOB_ID

		SET @@MSG_SUCCESS  = 'MWP003 : '+ (SELECT dbo.GenerateMessage('MWP003','ITEM CHECK','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Updated', 'MWP003', 'Info',  @@MSG_SUCCESS;

		SET @@MSG_END  = 'LOG007 : '+ (SELECT dbo.GenerateMessage('LOG007','','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'END', 'LOG007', 'Info',  @@MSG_END;

		EXEC SP_INSERT_UPDATE_LOG_H 
		@username,'','WP02007','1',1,'Update',@@COUNTER;
		
		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END ELSE
	BEGIN
		SET @@COUNTER = (SELECT (CASE WHEN (SELECT COUNT(PROCESS_ID) FROM TB_R_LOG_H) = 0 THEN 1 ELSE (SELECT TOP 1 PROCESS_ID FROM TB_R_LOG_H ORDER BY PROCESS_ID DESC) + 1 END));
		EXEC SP_INSERT_UPDATE_LOG_H @username,'','WP02007',1,'1','CREATE',@@COUNTER;

		SET @@MSG_START = 'LOG001 : '+ (SELECT dbo.GenerateMessage('LOG001','','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Start', 'LOG001', 'Info',  @@MSG_START;

		INSERT INTO [dbo].[TB_R_WP_DETAIL_ITEM_CHECK]
           ([WP_PROJECT_JOB_ID]
           ,[ITEM_NAME]
           ,[ITEM_DESCRIPTION]
           ,[ID_TB_M_EMPLOYEE]
           ,[ITEM_STATUS]
           ,[CREATED_BY]
           ,[CREATED_DT]
           ,[CHANGED_BY]
           ,[CHANGED_DT])
		VALUES
		(
			@WP_PROJECT_JOB_ID,
			@ITEM_NAME,
			@ITEM_DESCRIPTION,
			@ID_TB_M_EMPLOYEE,
			@ITEM_STATUS,
			@username,
			GETDATE(),
			@username,
			GETDATE()
		);

		SET @@CNT = SCOPE_IDENTITY();
		SET @@MSG_SUCCESS = 'MWP001 : '+ (SELECT dbo.GenerateMessage('MWP001','ITEM CHECK','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Duplicate', 'MWP001', 'Info',  @@MSG_SUCCESS;

		SET @@MSG_END = 'LOG007 : '+ (SELECT dbo.GenerateMessage('LOG007','','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'END', 'LOG007', 'Info',  @@MSG_END;

		EXEC SP_INSERT_UPDATE_LOG_H 
		@username,'','WP02007','1',1,'CREATE',@@COUNTER;

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT TB_R_WP_DETAIL_ITEM_CHECK:' +@ITEM_NAME+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS,@@CNT AS ID