DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM Z_RT_master_NG WHERE id_ng = @ID_NG);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO Z_RT_master_NG
		(
			 [id_ng]
			,[name_ng]
			,[time_koshin]
			,[NgStatus]
			,[flg_count]
		)
		VALUES
		(
			@ID_NG,
			@NAME_NG,
			GETDATE(),
			@NGSTATUS,
			'1'
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		
	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT Z_RT_master_NG:' +@ID_NG+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
