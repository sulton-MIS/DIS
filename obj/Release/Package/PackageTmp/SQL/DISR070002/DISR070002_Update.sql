DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE Z_RT_master_NG 
	SET
	    id_ng = @id_ng,
		name_ng = @name_ng,
		time_koshin = GETDATE(),
		NgStatus = @NgStatus,
		flg_count = '1'
	WHERE id_ng = @id_ng
		
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE Z_RT_master_NG: ' + @id_ng +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
