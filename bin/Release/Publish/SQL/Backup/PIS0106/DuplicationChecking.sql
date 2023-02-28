﻿IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[TB_M_STYLE] WHERE [STYLE_CD] = @StyleCode))
BEGIN
	SELECT TOP 1 
	Result = CAST(0 as bit),
	Message = 'MPISSTD049E',
	Param = @StyleCode
END
ELSE
BEGIN
	SELECT TOP 1 
	Result = CAST(1 as bit),
	Message = null,
	Param = ''
END