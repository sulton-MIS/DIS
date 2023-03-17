




BEGIN
	DELETE ad_dis_ma_lokasi_asset WHERE kd_lokasi = @ID;
	SELECT 'True' AS MSG;
	
END



