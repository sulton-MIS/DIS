﻿SELECT [SYS_VAL]
  FROM [TPRO].[dbo].[TB_M_SYSTEM]
  WHERE [SYS_CAT] = @SYS_CAT
      AND [SYS_SUB_CAT] = @SYS_SUB_CAT
      AND [SYS_CD] = @SYS_CD