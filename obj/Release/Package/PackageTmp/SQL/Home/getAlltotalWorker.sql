﻿DECLARE @@DATE VARCHAR(MAX);
SET @@DATE = (SELECT TOP 1 DATE FROM TB_R_WP_SECURITY_CHECK WHERE (CHECK_OUT = '' OR CHECK_OUT IS NULL) ORDER BY DATE ASC);
--GET ALL TOTAL WORKERS
IF(@@DATE IS NOT NULL)
BEGIN
	SELECT COUNT(B.TB_M_EMPLOYEE_ID) FROM TB_R_WP_DAILY AS A 
	INNER JOIN TB_R_WP_DAILY_WORKER_LIST AS B ON A.ID = B.TB_R_WP_DAILY_ID
	INNER JOIN TB_R_WP_PROJECT AS C ON A.TB_R_WP_PROJECT_ID = C.ID
	INNER JOIN TB_R_WP_PROJECT_JOB AS D ON C.ID = D.WP_PROJECT_ID
	WHERE CONVERT(date, @@DATE) >= CONVERT(date, D.START_DATE) AND CONVERT(date, getdate()) <= CONVERT(date, D.END_DATE) 
	AND C.ID_TB_M_AREA = @AREA
END
ELSE
BEGIN
	SELECT COUNT(B.TB_M_EMPLOYEE_ID) FROM TB_R_WP_DAILY AS A 
	INNER JOIN TB_R_WP_DAILY_WORKER_LIST AS B ON A.ID = B.TB_R_WP_DAILY_ID
	INNER JOIN TB_R_WP_PROJECT AS C ON A.TB_R_WP_PROJECT_ID = C.ID
	INNER JOIN TB_R_WP_PROJECT_JOB AS D ON C.ID = D.WP_PROJECT_ID
	WHERE CONVERT(date, getdate()) >= CONVERT(date, D.START_DATE) AND CONVERT(date, getdate()) <= CONVERT(date, D.END_DATE) 
	AND C.ID_TB_M_AREA = @AREA
END