
BEGIN
	DELETE [ad_dis_rtjn_master_actual_masalah] WHERE no_id = @ID;
	SELECT 'True' AS MSG;
	
END



