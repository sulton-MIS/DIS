DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_ma_lokasi_asset 
	SET
	    kd_lokasi = @KD_LOKASI,
		nama_lokasi = @NAMA_LOKASI,
		area = @AREA
	WHERE kd_lokasi = @KD_LOKASI
		
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_ma_lokasi_asset: ' + @KD_LOKASI +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
