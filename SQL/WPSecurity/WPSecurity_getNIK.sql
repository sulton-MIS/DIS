﻿SELECT 
TOP 1
(
SELECT 
	(SELECT TOP 1 IDENTITY_NO FROM TB_M_EMPLOYEE WHERE ANZEN_SERTIFICATE_NO = TB_M_EMPLOYEE.ANZEN_SERTIFICATE_NO AND PIC_STATUS = 'PMP') 
FROM TB_M_EMPLOYEE WHERE ID_TB_M_EMPLOYEE = C.TB_M_EMPLOYEE_ID
) AS IDENTITY_NO
FROM TB_R_WP_PROJECT_JOB AS A INNER JOIN TB_R_WP_DAILY AS B ON B.TB_R_WP_PROJECT_JOB_ID = A.ID
INNER JOIN TB_R_WP_DAILY_WORKER_LIST AS C ON C.TB_R_WP_DAILY_ID = B.ID
WHERE A.WP_IMPB_NO = @ID