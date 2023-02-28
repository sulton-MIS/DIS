

BEGIN
	DELETE Z_RT_master_kikai WHERE id_kikai = @ID;
	SELECT 'True' AS MSG;
	
END



