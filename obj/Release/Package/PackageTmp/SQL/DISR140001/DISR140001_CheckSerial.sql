SELECT TOP 1
	CASE 
		WHEN serial_no IS NULL OR serial_no = '' THEN 0
	ELSE
		1
	END as checkSerial
FROM
	Z_REX_Data_InOut_FG_Detail 
WHERE 
	serial_no = @SERIAL_NO 
	AND dmc_code = @DMC_CODE