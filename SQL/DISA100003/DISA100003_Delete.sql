
BEGIN
	DELETE ad_dis_pc_master_list_konpo WHERE id_konpo = @ID;
	SELECT 'True' AS MSG;
	
END



