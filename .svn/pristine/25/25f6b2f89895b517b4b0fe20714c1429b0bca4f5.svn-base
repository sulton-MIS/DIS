IF(NOT EXISTS(
		SELECT TOP 1 1 FROM [dbo].[TB_R_PAGE_H] 
			WHERE [PLANT_CD]	= @PlantCode
			AND [TEMPLATE_NM]	= @TemplateName
			AND [BC_TYPE]		= @BcType
			AND [LOGICAL_TERMINAL]	= @LogicalTerminal)
	)
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