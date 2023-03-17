




BEGIN
	DELETE Z_RT_master_kotei WHERE id_kotei = @ID;
	SELECT 'True' AS MSG;
	
END



