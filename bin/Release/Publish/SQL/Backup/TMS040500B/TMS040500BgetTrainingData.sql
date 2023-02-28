﻿SELECT H.TRAINING_SCH_ID
	, H.REG_PERIOD_ID
	, T.TRAINING_TYPE_ID
	, T.TRAINING_TOPIC_SEQ
	, T.TRAINING_TOPIC_CD
	, T.TRAINING_TOPIC_NM
	, H.TRAINING_SCH_FR
	, H.TRAINING_SCH_TO
	, H.TRAINING_SHIFT
	, (SELECT SYS_VAL FROM TB_M_SYSTEM WHERE SYS_CAT = 'MASTER' AND SYS_SUB_CAT = 'TRAINING_SHIFT' AND SYS_CD = H.TRAINING_SHIFT) AS TRAINING_SHIFT_NAME
	, T.PASSING_POSTSCORE
	, T.PASSING_ATTENDANCE
	, H.LOCATION
	, H.ROOM
	, (SELECT SYS_VAL FROM TB_M_SYSTEM WHERE SYS_CAT = 'PARAMETER' AND SYS_SUB_CAT = 'MONTH' AND SYS_CD = DATEPART(MM, H.TRAINING_SCH_FR)) AS KANBAN_MONTH
	, H.TRAINING_ADMIN
	, H.TRAINING_SCH_STS
FROM TB_M_TRAINING_TOPIC T
JOIN TB_M_TRAINING_SCHED_H H
ON T.TRAINING_TOPIC_CD=H.TRAINING_TOPIC_CD
JOIN (SELECT * FROM TB_M_SYSTEM WHERE SYS_CAT='MASTER' AND SYS_SUB_CAT='TRAINING_SHIFT') A
ON A.SYS_CD=H.TRAINING_SHIFT
WHERE H.TRAINING_SCH_ID=@TRAINING_SCH_ID AND H.TRAINING_TOPIC_CD=@TRAINING_TOPIC_CD