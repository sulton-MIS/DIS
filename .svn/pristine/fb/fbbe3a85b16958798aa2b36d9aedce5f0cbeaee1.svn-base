INSERT INTO [dbo].[TB_S_HARIGAMI_H]
           ([LOGICAL_TERMINAL]
           ,[BC_TYPE]
           ,[VIN_NO]
           ,[BODY_NO]
           ,[ID_NO]
           ,[PLANT_CD]
           ,[SEQ_NO]
           ,[PROCESSED_BY]
           ,[PROCESSED_DT])
SELECT TOP 1
	LOGICAL_TERMINAL
	, BC_TYPE
	, VIN_NO
	, BODY_NO
	, ID_NO
	, PLANT_CD
	, @SeqNo
	, @UserName
	, GETDATE()
FROM TB_R_HARIGAMI_H
WHERE SEQ_NO = @SeqNo
	AND HARIGAMI_STS = '0'
ORDER BY CREATED_DT DESC

SELECT message = '0'