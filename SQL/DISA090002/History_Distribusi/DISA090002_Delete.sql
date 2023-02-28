




BEGIN
	DELETE ad_dis_dd_master_denki WHERE nama_mesin = @NAMA_MESIN;
	SELECT 'True' AS MSG;
	
END



