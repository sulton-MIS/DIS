﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@STATUS INT = 0;

DECLARE @@COUNTER INT= (SELECT (CASE WHEN (SELECT COUNT(PROCESS_ID) FROM TB_R_LOG_H) = 0 THEN 1 ELSE (SELECT TOP 1 PROCESS_ID FROM TB_R_LOG_H ORDER BY PROCESS_ID DESC) + 1 END));
EXEC SP_INSERT_UPDATE_LOG_H @USERNAME,'','WP01002',1,'1','Update',@@COUNTER;

DECLARE @@MSG_START VARCHAR(MAX) = 'LOG001 : '+ (SELECT dbo.GenerateMessage('LOG001','','',''));
EXEC SP_INSERT_LOG_D @@COUNTER, 'Start', 'LOG001', 'Info',  @@MSG_START;

IF(@AREA_ST = 'null')
BEGIN
	SET @@STATUS = 0;
END
ELSE
BEGIN
	SET @@STATUS = @AREA_ST;
END

DECLARE @@MSG_CHECK VARCHAR(MAX) = 'LOG002 : '+ (SELECT dbo.GenerateMessage('LOG002','','',''));
EXEC SP_INSERT_LOG_D @@COUNTER, 'Check', 'LOG002', 'Info',  @@MSG_CHECK;

BEGIN TRY
	UPDATE TB_M_AREA SET AREA_CD = @AREA_CODE, AREA_ST = @@STATUS, AREA_NAME = @AREA_NAME, IMAGE_PATH = 'Content/Upload/Area/'+REPLACE(@AREA_CODE+'.'+@EXT, ' ', ''), UPDATE_BY = @USERNAME, UPDATE_DT = GETDATE() WHERE ID_TB_M_AREA = @ID
	DECLARE @@MSG_SUCCESS VARCHAR(MAX) = 'MWP003 : '+ (SELECT dbo.GenerateMessage('MWP003','AREA','',''));
	EXEC SP_INSERT_LOG_D @@COUNTER, 'Updated', 'MWP003', 'Info',  @@MSG_SUCCESS;
	
	IF(@@STATUS = 0)
	BEGIN
		UPDATE A SET STATUS = 0 FROM TB_M_LOCATION AS A INNER JOIN TB_M_AREA AS B ON A.ID_TB_M_AREA = B.ID_TB_M_AREA WHERE B.AREA_ST = 2
		DECLARE @@MSG_SUCCESS_LOC VARCHAR(MAX) = 'MWP003 : '+ (SELECT dbo.GenerateMessage('MWP003','Location','',''));
		EXEC SP_INSERT_LOG_D @@COUNTER, 'Updated Foreigner', 'MWP003', 'Info',  @@MSG_SUCCESS_LOC;
	END

	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	DECLARE @@MSG_ERROR VARCHAR(MAX) = ERROR_MESSAGE();
	EXEC SP_INSERT_LOG_D @@COUNTER, 'ERROR', 'Error', 'ERROR',  @@MSG_ERROR;

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE TB_M_AREA:' +@AREA_CODE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS

DECLARE @@MSG_END VARCHAR(MAX) = 'LOG007 : '+ (SELECT dbo.GenerateMessage('LOG007','','',''));
EXEC SP_INSERT_LOG_D @@COUNTER, 'END', 'LOG007', 'Info',  @@MSG_END;

EXEC SP_INSERT_UPDATE_LOG_H 
@USERNAME,'','WP01002','1',1,'CREATE',@@COUNTER;