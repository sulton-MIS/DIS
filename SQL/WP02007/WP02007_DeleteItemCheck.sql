﻿
DECLARE @@COUNTER INT= (SELECT (CASE WHEN (SELECT COUNT(PROCESS_ID) FROM TB_R_LOG_H) = 0 THEN 1 ELSE (SELECT TOP 1 PROCESS_ID FROM TB_R_LOG_H ORDER BY PROCESS_ID DESC) + 1 END));
EXEC SP_INSERT_UPDATE_LOG_H @USERNAME,'','WP02007',1,'1','DELETE',@@COUNTER;

DECLARE @@MSG_START VARCHAR(MAX) = 'LOG001 : '+ (SELECT dbo.GenerateMessage('LOG001','','',''));
EXEC SP_INSERT_LOG_D @@COUNTER, 'Start', 'LOG001', 'Info',  @@MSG_START;

BEGIN TRY
	DECLARE @@MSG_CHECK VARCHAR(MAX) = 'LOG002 : '+ (SELECT dbo.GenerateMessage('LOG002','','',''));
	EXEC SP_INSERT_LOG_D @@COUNTER, 'Check', 'LOG002', 'Info',  @@MSG_CHECK;

	DELETE TB_R_WP_DETAIL_ITEM_CHECK WHERE ID = @ID

	DECLARE @@MSG_SUCCESS VARCHAR(MAX) = 'MWP002 : '+ (SELECT dbo.GenerateMessage('MWP002','SYSTEM MASTER','',''));
	EXEC SP_INSERT_LOG_D @@COUNTER, 'Deleted', 'MWP002', 'Info',  @@MSG_SUCCESS;

END TRY
BEGIN CATCH
	DECLARE @@MSG_ERROR VARCHAR(MAX) = ERROR_MESSAGE();
	EXEC SP_INSERT_LOG_D @@COUNTER, 'ERROR', 'Error', 'ERROR',  @@MSG_ERROR;

END CATCH

DECLARE @@MSG_END VARCHAR(MAX) = 'LOG007 : '+ (SELECT dbo.GenerateMessage('LOG007','','',''));
EXEC SP_INSERT_LOG_D @@COUNTER, 'END', 'LOG007', 'Info',  @@MSG_END;

EXEC SP_INSERT_UPDATE_LOG_H 
@USERNAME,'','WP02007','1',1,'DELETE',@@COUNTER;