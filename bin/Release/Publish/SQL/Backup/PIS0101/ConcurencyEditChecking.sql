Declare @@datetime varchar(50)= ''
SELECT @@datetime = replace(convert(varchar(8), CHANGED_DT, 112)+convert(varchar(8), CHANGED_DT, 114), ':','') FROM [dbo].[TB_R_PAGE_H] 
		WHERE	[PLANT_CD]			= @PlantCode
			AND [TEMPLATE_NM]		= @TemplateName
			AND [BC_TYPE]			= @BcType
			AND [TEMPLATE_NM]		= @TemplateName
			
IF(@@datetime <> replace(convert(varchar(8), @ChangedDate, 112)+convert(varchar(8), @ChangedDate, 114), ':',''))
BEGIN
	SELECT TOP 1 
	Result = CAST(0 as bit),
	Message = 'MPISSTD050E',
	Param = ''
END
ELSE
BEGIN
	SELECT TOP 1 
	Result = CAST(1 as bit),
	Message = null,
	Param = ''
END