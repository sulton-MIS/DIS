
BEGIN
	DELETE [ad_dis_pc_master_unit_price] WHERE item_code = @ID;
	SELECT 'True' AS MSG;
	
END



