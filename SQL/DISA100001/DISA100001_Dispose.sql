BEGIN
DECLARE @@DATE_ASSET VARCHAR(MAX)= CONVERT(date, GETDATE());
DECLARE @@TIME_ASSET VARCHAR(MAX)= CAST(GETDATE() AS TIME);

	UPDATE [ad_dis_ma_master_asset] 
	SET flg_dispose_asset= '1', 
		tgl_dispose_asset= @@DATE_ASSET + ' ' + @@TIME_ASSET
		--tgl_dispose_asset= CONVERT(date, GETDATE()) 
		--tgl_dispose_asset= CONVERT(date, GETDATE()) + CONVERT(time, GETDATE())   
	WHERE no_asset = @NO_ASSET;
	SELECT 'True' AS MSG;
	
END



