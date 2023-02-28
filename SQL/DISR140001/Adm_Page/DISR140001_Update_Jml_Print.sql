DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
BEGIN TRY
	UPDATE Z_REX_Data_InOut_FG_New 
	SET 
		[kali_print] = kali_print + 1
	WHERE 
		id_trans = @ID_BUNDLE

	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE Z_REX_Data_InOut_FG_New:' +@ID_BUNDLE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS