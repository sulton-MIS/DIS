
BEGIN
	--DELETE [Z_RT_master_tool] WHERE id_tool = @ID;
	UPDATE [Z_RT_master_tool] SET status_delete='1', STATUS='TIDAK AKTIF' WHERE id_tool = @ID;
	SELECT 'True' AS MSG;
	
END



