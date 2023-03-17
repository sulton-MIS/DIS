




BEGIN
	DELETE Y_TRUSER WHERE i_user = @ID;
	SELECT 'True' AS MSG;
	
END



