DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM Y_TRUSER WHERE i_user = @i_user);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO Y_TRUSER
		(
			 [i_user]
			,[c_pwd]
			,[i_user_long]
			,[dept]
			,[authority]
			,[e_mail]
			,[EmailSender]
			,[section]
			,[IdLevel]
			,[IdAccesable]
			
		)
		VALUES
		(
			@i_user,
			@c_pwd,
			@i_user_long,
			@dept,
			@authority,
			@e_mail,
			@EmailSender,
			@section,
			@IdLevel,
			@IdAccesable
			--GETDATE(),
			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT Y_TRUSER:' +@i_user+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
