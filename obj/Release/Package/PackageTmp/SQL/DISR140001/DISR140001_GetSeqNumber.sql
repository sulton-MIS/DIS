SELECT TOP(1) 
CONVERT(INT, RIGHT(id_trans, 3)) AS SEQ_NUMBER 
FROM Z_REX_Data_InOut_FG_Detail 
WHERE YEAR(trans_date) = @YEAR_TRX 
AND MONTH(trans_date) = @MONTH_TRX 
AND DAY(trans_date) = @DAY_TRX 
ORDER BY trans_date DESC
