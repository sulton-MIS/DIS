
BEGIN
	DELETE Y_ConvertionTablePacking WHERE ItemCode = @ID;
	SELECT 'True' AS MSG;
	
END



