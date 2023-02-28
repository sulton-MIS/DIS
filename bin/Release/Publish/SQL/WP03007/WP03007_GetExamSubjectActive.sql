﻿SELECT 
	ID_TB_R_LEARN_EXAM_SUBJECT AS Id
    ,TITLE AS Title
    ,PASSING_SCORE_REQUIREMENT AS PassingScore
    ,EXAM_DURATION AS ExamDuration
    ,DATE_EXAM_PERIOD_START AS ExamPeriodStart
    ,DATE_EXAM_PERIOD_END AS ExamPeriodEnd
    ,REMEDIAL AS MaxRemedial
    ,EXAM_TYPE AS ExamType
	,TOTAL_PUBLISHED
FROM 
	TB_R_LEARN_EXAM_SUBJECT
WHERE 
	IS_DELETED = 0 
	AND (ID_TB_R_LEARN_EXAM_SUBJECT = @ID OR @ID = 0)