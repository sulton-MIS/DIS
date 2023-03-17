﻿SELECT TOP 1 
	ID_TB_R_LEARN_EXAM_SCORE AS Id
    ,ID_TB_M_EMPLOYEE AS EmployeeId
    ,ID_TB_R_LEARN_EXAM_SUBJECT AS SubjectId
    ,ID_TB_M_COMPANY AS CompanyId
    ,ANSWER AS Answer
    ,CORRECT_AMOUNT AS CorrectAmount
    ,WRONG_AMOUNT AS WrongAmount
    ,NOT_ANSWERED_AMOUNT AS NotAnswerAmount
    ,REMEDIAL AS Remedial
    ,SCORE AS Score
    ,PASS_GRADUATED AS PassGraduate
    ,TIMER AS Timer
    ,SUBMIT_DATE AS SubmitDate
    ,IS_STATUS AS [Status]
FROM 
	TB_R_LEARN_EXAM_SCORE
WHERE 
	ID_TB_M_EMPLOYEE = @EmployeeId
ORDER BY 
	ID_TB_R_LEARN_EXAM_SCORE DESC