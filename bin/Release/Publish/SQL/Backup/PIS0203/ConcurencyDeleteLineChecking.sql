IF(NOT EXISTS(SELECT TOP 1 1 FROM [dbo].[TB_M_LINE] WHERE [SID] = @SID))
BEGIN
	SELECT TOP 1 
	Result = CAST(0 as bit),
	Message = 'MPISSTD005E',
	Param = ''
END
ELSE
BEGIN
	SELECT TOP 1 
	Result = CAST(1 as bit),
	Message = null,
	Param = ''
END