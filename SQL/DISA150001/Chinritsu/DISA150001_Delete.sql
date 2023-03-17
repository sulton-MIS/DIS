
BEGIN
	DELETE [ad_dis_pc_master_chinritsu] WHERE id_trans = @ID;
	SELECT 'True' AS MSG;
	
END



