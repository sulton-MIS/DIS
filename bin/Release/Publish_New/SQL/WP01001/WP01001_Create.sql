﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@MSG VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);
DECLARE @@CHK_DELETE VARCHAR(5);

DECLARE @@COUNTER INT= (SELECT (CASE WHEN (SELECT COUNT(PROCESS_ID) FROM TB_R_LOG_H) = 0 THEN 1 ELSE (SELECT TOP 1 PROCESS_ID FROM TB_R_LOG_H ORDER BY PROCESS_ID DESC) + 1 END));
EXEC SP_INSERT_UPDATE_LOG_H @USERNAME,'','WP01001',1,'1','CREATE',@@COUNTER;

DECLARE @@MSG_START VARCHAR(MAX) = 'LOG001 : '+ (SELECT dbo.GenerateMessage('LOG001','','',''));
EXEC SP_INSERT_LOG_D @@COUNTER, 'Start', 'LOG001', 'Info',  @@MSG_START;

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM TB_M_SYSTEM WHERE SYSTEM_ID = @SYSTEM_ID AND SYSTEM_TYPE = @SYSTEM_TYPE AND SYSTEM_CD = @SYSTEM_CD);

	DECLARE @@MSG_CHECK VARCHAR(MAX) = 'LOG002 : '+ (SELECT dbo.GenerateMessage('LOG002','','',''));
	EXEC SP_INSERT_LOG_D @@COUNTER, 'Check', 'LOG002', 'Info',  @@MSG_CHECK;

	IF(@@CNT > 0)
	BEGIN
		SET @@CHK = 'FALSE';
		SET @@MSG = 'DUPLICATE';
		
		DECLARE @@MSG_WARNING VARCHAR(MAX) = 'MWP004 : '+ (SELECT dbo.GenerateMessage('MWP004','System ID And System Type And System Code','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Duplicate', 'MWP004', 'Info',  @@MSG_WARNING;

	END ELSE
	BEGIN
		INSERT INTO TB_M_SYSTEM
		(
			 [SYSTEM_ID],
			 [SYSTEM_TYPE],
			 [SYSTEM_CD],
			 [SYSTEM_VALID_FR],
			 [SYSTEM_VALID_TO],
			 [SYSTEM_VALUE_TXT],
			 [SYSTEM_VALUE_NUM],
			 [SYSTEM_VALUE_DT],
			 [CREATED_BY],
			 [CREATED_DT],
			 [CHANGED_BY],
			 [CHANGED_DT],
			 [IS_DELETED]
		)
		VALUES
		(
			@SYSTEM_ID,
			@SYSTEM_TYPE,
			@SYSTEM_CD,
			@SYSTEM_VALID_FR,
			@SYSTEM_VALID_TO,
			@SYSTEM_VALUE_TXT,
			CASE WHEN Isnumeric(@SYSTEM_VALUE_NUM) = 1
			THEN CONVERT(DECIMAL(18,2),@SYSTEM_VALUE_NUM) 
			ELSE 0 END,
			@SYSTEM_VALUE_DT,
			@USERNAME,
			GETDATE(),
			@USERNAME,
			GETDATE(),
			0
		);

		DECLARE @@MSG_SUCCESS VARCHAR(MAX) = 'MWP001 : '+ (SELECT dbo.GenerateMessage('MWP001','SYSTEM MASTER','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Duplicate', 'MWP001', 'Info',  @@MSG_SUCCESS;

		SET @@CHK = 'TRUE';
		SET @@MSG = 'Success';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@MSG = 'ERROR INSERT TB_M_SYSTEM: ' +@SYSTEM_ID+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@MSG AS LINE_STS

DECLARE @@MSG_END VARCHAR(MAX) = 'LOG007 : '+ (SELECT dbo.GenerateMessage('LOG007','','',''));
EXEC SP_INSERT_LOG_D @@COUNTER, 'END', 'LOG007', 'Info',  @@MSG_END;

EXEC SP_INSERT_UPDATE_LOG_H 
@USERNAME,'','WP01001','1',1,'CREATE',@@COUNTER;