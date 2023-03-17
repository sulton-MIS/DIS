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
	SET @@CNT = (SELECT COUNT(1) FROM TB_R_WP_DETAIL_WORKING WHERE ID = @ID);
	IF(@@CNT > 0)
	BEGIN
		SET @@COUNTER = (SELECT (CASE WHEN (SELECT COUNT(PROCESS_ID) FROM TB_R_LOG_H) = 0 THEN 1 ELSE (SELECT TOP 1 PROCESS_ID FROM TB_R_LOG_H ORDER BY PROCESS_ID DESC) + 1 END));
		EXEC SP_INSERT_UPDATE_LOG_H @username,'','WP02002',1,'1','Update',@@COUNTER;

		SET @@MSG_START = 'LOG001 : '+ (SELECT dbo.GenerateMessage('LOG001','','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Start', 'LOG001', 'Info',  @@MSG_START;


		UPDATE TB_R_WP_DETAIL_WORKING 
			SET ID_TB_M_WORKING_TYPE = @ID_TB_M_WORKING_TYPE,
				DANGER_TYPE = @DANGER_TYPE,
				DAY_1 = @DAY_1,
				DAY_2 = @DAY_2,
				DAY_3 = @DAY_3,
				DAY_4 = @DAY_4,
				DAY_5 = @DAY_5,
				DAY_6 = @DAY_6,
				DAY_7 = @DAY_7,
				SIX_A = @SIX_A,
				SIX_B = @SIX_B,
				SIX_C = @SIX_C,
				SIX_D = @SIX_D,
				SIX_E = @SIX_E,
				SIX_F = @SIX_F,
				SIX_ALPHA = @SIX_ALPHA,
				[CHANGED_BY] = @username,
				[CHANGED_DT] = GETDATE()
		WHERE ID = @ID;

		SET @@MSG_SUCCESS  = 'MWP003 : '+ (SELECT dbo.GenerateMessage('MWP003','IMPB LIST WORKING','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Updated', 'MWP003', 'Info',  @@MSG_SUCCESS;

		SET @@MSG_END  = 'LOG007 : '+ (SELECT dbo.GenerateMessage('LOG007','','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'END', 'LOG007', 'Info',  @@MSG_END;

		EXEC SP_INSERT_UPDATE_LOG_H 
		@username,'','WP02002','1',1,'Update',@@COUNTER;
		
		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

	END ELSE
	BEGIN
		SET @@COUNTER = (SELECT (CASE WHEN (SELECT COUNT(PROCESS_ID) FROM TB_R_LOG_H) = 0 THEN 1 ELSE (SELECT TOP 1 PROCESS_ID FROM TB_R_LOG_H ORDER BY PROCESS_ID DESC) + 1 END));
		EXEC SP_INSERT_UPDATE_LOG_H @username,'','WP02002',1,'1','CREATE',@@COUNTER;

		SET @@MSG_START = 'LOG001 : '+ (SELECT dbo.GenerateMessage('LOG001','','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Start', 'LOG001', 'Info',  @@MSG_START;
		
		INSERT INTO TB_R_WP_DETAIL_WORKING
		(
			 [WP_PROJECT_JOB_ID]
			,ID_TB_M_WORKING_TYPE
			,DANGER_TYPE
			,SIX_A
			,SIX_B
			,SIX_C
			,SIX_D
			,SIX_E
			,SIX_F
			,SIX_ALPHA
			,DAY_1
			,DAY_2
			,DAY_3
			,DAY_4
			,DAY_5
			,DAY_6
			,DAY_7
			,[CREATED_BY]
			,[CREATED_DT]
			,[CHANGED_BY]
			,[CHANGED_DT]
		)
		VALUES
		(
			@WP_PROJECT_JOB_ID,
			@ID_TB_M_WORKING_TYPE
			,@DANGER_TYPE
			,@SIX_A
			,@SIX_B
			,@SIX_C
			,@SIX_D
			,@SIX_E
			,@SIX_F
			,@SIX_ALPHA
			,@DAY_1
			,@DAY_2
			,@DAY_3
			,@DAY_4
			,@DAY_5
			,@DAY_6
			,@DAY_7
			,@username,
			GETDATE(),
			@username,
			GETDATE()
		);

		SET @@MSG_SUCCESS = 'MWP001 : '+ (SELECT dbo.GenerateMessage('MWP001','IMPB LIST WORKING','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Duplicate', 'MWP001', 'Info',  @@MSG_SUCCESS;

		SET @@MSG_END = 'LOG007 : '+ (SELECT dbo.GenerateMessage('LOG007','','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'END', 'LOG007', 'Info',  @@MSG_END;

		EXEC SP_INSERT_UPDATE_LOG_H 
		@username,'','WP02002','1',1,'CREATE',@@COUNTER;

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT TB_R_WP_DETAIL_WORKING:' +@WP_PROJECT_JOB_ID+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS