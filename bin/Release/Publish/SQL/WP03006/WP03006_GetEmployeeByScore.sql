﻿SELECT E.[ID_TB_M_EMPLOYEE] AS Id
    ,E.FIRST_NAME+' '+E.LAST_NAME AS [Name]
	,E.[ADDRESS] AS [Address]
	,C.COMPANY_NAME AS Company
    ,E.IDENTITY_NO AS IdentityNo
FROM [TB_M_EMPLOYEE] AS E
	LEFT JOIN TB_M_COMPANY AS C
		ON E.ID_TB_M_COMPANY = C.ID_TB_M_COMPANY
WHERE E.ID_TB_M_EMPLOYEE = (SELECT ID_TB_M_EMPLOYEE 
		FROM TB_R_LEARN_EXAM_SCORE WHERE ID_TB_R_LEARN_EXAM_SCORE = @ID)