IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[TB_R_PAGE_H] WHERE [PLANT_CD]+[TEMPLATE_NM]+[BC_TYPE]+LOGICAL_TERMINAL = @Code))

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