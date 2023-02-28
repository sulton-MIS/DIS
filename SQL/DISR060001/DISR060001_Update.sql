DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE Y_TRUSER SET
	    i_user= @i_user,
		c_pwd= @c_pwd,
		i_user_long= @i_user_long,
		dept= @dept,
		authority= @authority,
		e_mail= @e_mail,
		EmailSender= @EmailSender,
		section= @section,
		IdLevel= @IdLevel,
		IdAccesable= @IdAccesable
	WHERE i_user = @i_user

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE TB_M_EMPLOYEE: ' + @i_user +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
