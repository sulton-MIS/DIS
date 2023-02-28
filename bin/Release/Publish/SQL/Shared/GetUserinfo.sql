﻿SELECT	TOP 1 
		B.REG_NO AS NOREG,
		A.USERNAME	AS USERNAME,
		B.EMAIL,
		B.FIRST_NAME,
		B.LAST_NAME,
		B.PHONE,
		B.GENDER,
		B.BIRTH_DATE,
		B.IDENTITY_TYPE,
		B.IDENTITY_NO,
		B.PIC_STATUS,
		(SELECT TOP 1 COMPANY_CODE FROM TB_M_COMPANY  WHERE ID_TB_M_COMPANY = B.ID_TB_M_COMPANY ) AS COMPANY_CODE,
		B.SECTION,
		(SELECT TOP 1 AREA_NAME FROM TB_M_AREA  WHERE ID_TB_M_AREA = A.ID_TB_M_AREA ) AS AREA_NAME,
		(SELECT TOP 1 LOC_NAME FROM TB_M_LOCATION  WHERE ID_TB_M_LOCATION = A.ID_TB_M_LOCATION ) AS LOCATIONNAME,
		'PLANT 3' AS PlantName,
		A.ID_TB_M_AREA AS AREA,
		(SELECT TOP 1 COMPANY_NAME FROM TB_M_COMPANY  WHERE ID_TB_M_COMPANY = B.ID_TB_M_COMPANY ) AS COMPANY
FROM	dbo.TB_M_USER_MAPPING AS A
LEFT JOIN TB_M_EMPLOYEE AS B ON A.USERNAME = B.USERNAME
WHERE	A.USERNAME = (CASE WHEN ISNUMERIC(@Username) = 1 THEN ''+@Username+'' ELSE @Username END )