DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE Z_RT_master_tool SET
			id_tool = @ID_TOOL,
			name_tool = @NAME_TOOL,
			factory = @FACTORY,
			lifetime = @LIFETIME,			
			limit = @LIMIT,
			status = 'AKTIF',
			time_koshin = getdate()			
	WHERE id_tool = @ID

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE [mster_tool]: ' + @ID_TOOL +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
