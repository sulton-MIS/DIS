﻿SELECT 
	A.USERNAME
FROM 
TB_M_EMPLOYEE AS A
WHERE A.IS_DELETED = 0 AND A.USERNAME NOT IN (SELECT USERNAME FROM TB_M_USER_MAPPING) AND A.USERNAME != '' AND A.IDENTITY_NO != ''
