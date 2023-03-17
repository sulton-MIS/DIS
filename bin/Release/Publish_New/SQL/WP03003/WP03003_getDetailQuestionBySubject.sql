﻿SELECT 
	A.ID_TB_M_LEARN_QUESTION AS ID
    ,QUESTION
    ,ANSWER_CHOICE_A
    ,ANSWER_CHOICE_B
    ,ANSWER_CHOICE_C
    ,ANSWER_CHOICE_D
    ,ANSWER_CHOICE_E
    ,ANSWER_KEY
FROM 
	TB_M_LEARN_QUESTION AS A
    INNER JOIN TB_R_LEARN_EXAM_QUESTION AS B
		ON A.ID_TB_M_LEARN_QUESTION = B.ID_TB_M_LEARN_QUESTION
		AND B.IS_DELETED = 0
WHERE
	B.ID_TB_R_LEARN_EXAM_SUBJECT = @ID
    AND (A.CATEGORY = @category OR @category = '')
    AND (A.QUESTION LIKE ('%' + @question + '%'))

