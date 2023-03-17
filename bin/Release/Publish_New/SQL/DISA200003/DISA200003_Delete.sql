




BEGIN
	UPDATE [ad_dis_ma_master_asset] SET FLG_DISPOSE_ASSET=''  WHERE no_asset = @NO_ASSET;
	SELECT 'True' AS MSG;
	
END



