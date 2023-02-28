DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE [ad_dis_pc_master_chinritsu] SET
			part = @PART,
			id_kotei = @ID_KOTEI,
            factory = @FACTORY,
            chinritsu = @CHINRITSU
	WHERE id_trans = @ID

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE [ad_dis_pc_master_chinritsu]: ' + @ID_KOTEI +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
