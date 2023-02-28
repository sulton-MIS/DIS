




BEGIN
	DELETE [ad_dis_ma_master_asset] WHERE no_asset = @NO_ASSET;
	SELECT 'True' AS MSG;
	
END



