
BEGIN
	DELETE [ad_dis_pc_master_type_cust] WHERE Dmc_Type = @ID;
	SELECT 'True' AS MSG;
	
END



