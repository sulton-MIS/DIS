DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE [ad_dis_rtjn_master_actual_masalah] SET
			halte = @HALTE,
			date = @DATE,
			time = @TIME,
			opmj = @OPMJ,
			masalah = @MASALAH,
			action = @ACTION
	WHERE no_id = @ID

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE [ad_dis_rtjn_master_actual_masalah]: ' + @HALTE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
