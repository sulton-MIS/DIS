﻿SELECT TS.[TRAINING_SCH_ID]
      ,TS.[TRAINER_ID]
	  ,HR.[NAME]
	  ,HR.[CLASS]
	  ,HR.[POSITION]
	  ,HR.[DIVISION]
	  ,HR.[DEPARTEMENT]
	  ,HR.[EMAIL]
      ,TS.[TRAINING_DAY]
	  ,DATEADD(D, TS.[TRAINING_DAY] - 1, TH.[TRAINING_SCH_FR]) AS 'TRAINING_DATE'
	  ,CASE 
		WHEN DATENAME(WEEKDAY,TH.[TRAINING_SCH_FR]) = 'Sunday'
			THEN 'Minggu'
		WHEN DATENAME(WEEKDAY,TH.[TRAINING_SCH_FR]) = 'Monday'
			THEN 'Senin'
		WHEN DATENAME(WEEKDAY,TH.[TRAINING_SCH_FR]) = 'Tuesday'
			THEN 'Selasa'
		WHEN DATENAME(WEEKDAY,TH.[TRAINING_SCH_FR]) = 'Wednesday'
			THEN 'Rabu'
		WHEN DATENAME(WEEKDAY,TH.[TRAINING_SCH_FR]) = 'Thursday'
			THEN 'Kamis'
		WHEN DATENAME(WEEKDAY,TH.[TRAINING_SCH_FR]) = 'Friday'
			THEN 'Jumat'
		WHEN DATENAME(WEEKDAY,TH.[TRAINING_SCH_FR]) = 'Saturday'
			THEN 'Sabtu'
	   END AS 'TRAINING_DAY_NAME'
      ,TS.[TRAINING_TIME]
      ,TS.[TRAINER_BU_STS]
      ,TS.[TRAINER_SEQ]
      ,TS.[APPROVED_DT]
      ,TS.[APPROVED_BY]
      ,TS.[REJECTED_DT]
      ,TS.[REJECTED_BY]
  FROM [dbo].[TB_M_TRAINING_SCHED_D] TS
  JOIN [dbo].[HRWEB] HR ON TS.[TRAINER_ID] = HR.[NOREG]
  JOIN [dbo].[TB_M_TRAINING_SCHED_H] TH ON TS.[TRAINING_SCH_ID] = TH.[TRAINING_SCH_ID]
  WHERE TS.[TRAINING_SCH_ID] = @TRAINING_SCH_ID AND TS.[TRAINER_BU_STS] = '6'