
BEGIN
	DELETE ad_dis_pc_master_chokoritsu WHERE dmc_type = @ID;
	SELECT 'True' AS MSG;
	
END



