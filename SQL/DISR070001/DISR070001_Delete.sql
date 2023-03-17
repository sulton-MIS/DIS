




BEGIN
	DELETE Z_RT_master_sagyosha WHERE id_sagyosha = @ID;
	SELECT 'True' AS MSG;
	
END



