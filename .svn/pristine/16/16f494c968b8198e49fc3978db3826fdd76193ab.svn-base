IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[TB_M_TELE_PRINTER] WHERE [PLANT_CD]+[LOGICAL_TERMINAL]+[BC_TYPE]+STATUS_LIVE = @Code))
BEGIN
	SELECT TOP 1 
	Result = CAST(0 as bit),
	Message = 'MPISSTD049E',
	Param = @Code
END
ELSE
BEGIN
	SELECT TOP 1 
	Result = CAST(1 as bit),
	Message = null,
	Param = ''
END