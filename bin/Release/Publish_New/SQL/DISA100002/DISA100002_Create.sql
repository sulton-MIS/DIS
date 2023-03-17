DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_lokasi_asset WHERE kd_lokasi = @KD_LOKASI);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_ma_lokasi_asset
		(
			 [kd_lokasi]
			,[nama_lokasi]
			,[area]
		)
		VALUES
		(
			@KD_LOKASI
			,@NAMA_LOKASI
			,@AREA
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		
	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_ma_lokasi_asset:' +@KD_LOKASI+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
