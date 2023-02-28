DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
BEGIN TRY
	UPDATE TB_M_LEARN_MODULE_TRAINING SET 
							TITLE = @Title
							,[DESCRIPTION] = @Description
							,CONTENT_TRAINING = @Content
							,[FILE_PATH] = @File_Modul
							,[FILE_NAME] = @File_Name
							,UPDATED_BY = @Username
							,UPDATED_DT = GETDATE()
					WHERE ID_TB_M_LEARN_MOD_TRAINING = @Id
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE TB_M_LEARN_MODULE_TRAINING:' +@Title+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS