DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_dd_master_denki SET
	      nama_mesin = @NAMA_MESIN,      
	      path_mesin = @PATH_MESIN,      
          updated_by = @USERNAME,
		  updated_date = @UPDATED_DATE
	WHERE id_tb_m_denki = @ID

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_dd_master_denki: ' + @ID +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
