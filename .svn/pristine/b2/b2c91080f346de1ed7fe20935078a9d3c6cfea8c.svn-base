IF(NOT EXISTS(SELECT TOP 1 1 FROM [dbo].[TB_M_TELE_PRINTER] 
		WHERE [PLANT_CD]			= @PlantCode
			AND [LOGICAL_TERMINAL]	= @LogicalTerminal
			AND [BC_TYPE]			= @BcType
			AND [STATUS_LIVE]		= @StatusLive
			
			))
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