﻿SELECT 
	ID_TB_M_EMPLOYEE AS ID
	,REG_NO
FROM
	TB_M_EMPLOYEE
WHERE
	PIC_STATUS ='MEMBER'
ORDER BY 
	REG_NO ASC