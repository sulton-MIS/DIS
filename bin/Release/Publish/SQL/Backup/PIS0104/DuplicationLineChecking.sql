IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[TB_M_LINE] WHERE [LINE_CD] = @LineCode))
BEGIN
	SELECT TOP 1 
	Result = CAST(0 as bit),
	Message = 'MPISSTD049E',
	Param = @LineCode
END
ELSE
BEGIN
	SELECT TOP 1 
	Result = CAST(1 as bit),
	Message = null,
	Param = ''
END