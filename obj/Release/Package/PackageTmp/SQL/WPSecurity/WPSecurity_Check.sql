﻿DECLARE @@GET_DATE DATE = CONVERT(date, getdate());
DECLARE @@CHK INT = 0;
DECLARE @@PIC_STATUS VARCHAR(10);
DECLARE @@ID_IMPB VARCHAR(10);
DECLARE @@CHK_PMP INT=0;
DECLARE @@GETSECURITY_ID VARCHAR(10);
SET @@CHK = (SELECT COUNT(1) FROM TB_M_EMPLOYEE AS A 
INNER JOIN TB_R_WP_SECURITY_CHECK AS B ON A.ID_TB_M_EMPLOYEE = B.ID_TB_M_EMPLOYEE
INNER JOIN TB_R_WP_PROJECT_JOB AS C ON B.ID_TB_R_WP_PROJECT_JOB_ID = C.ID
WHERE C.WP_IMPB_NO = @IMPB_NO AND A.ID_TB_M_EMPLOYEE = @ID
AND CONVERT(DATE, B.DATE) = CONVERT(DATE, GETDATE()));

SET @@PIC_STATUS = (SELECT TOP 1 PIC_STATUS  FROM TB_M_EMPLOYEE WHERE ID_TB_M_EMPLOYEE = @ID);
SET @@GETSECURITY_ID = (SELECT TOP 1 ID_TB_M_EMPLOYEE  FROM TB_M_EMPLOYEE WHERE USERNAME = @Username);
SET @@ID_IMPB = (SELECT TOP 1 ID FROM TB_R_WP_PROJECT_JOB WHERE WP_IMPB_NO = @IMPB_NO);
IF(@@CHK = 0)
BEGIN
	SET @@PIC_STATUS = (SELECT PIC_STATUS FROM TB_M_EMPLOYEE WHERE ID_TB_M_EMPLOYEE = @ID);

	IF(@@PIC_STATUS = 'PMP')
	BEGIN
		INSERT INTO TB_R_WP_SECURITY_CHECK
	(
		[ID_TB_R_WP_PROJECT_JOB_ID],
		[ID_TB_M_EMPLOYEE],
		[ID_SECURITY_EMPLOYEE_CHECK_IN],
		DATE,
		[CHECK_IN],
		[PIC_STATUS]
	) 
	VALUES(
		@@ID_IMPB,
		@ID,
		@@GETSECURITY_ID,
		GETDATE(),
		GETDATE(),
		@@PIC_STATUS
	);
	SELECT 'TRUE' AS LINE_STS, 'SCAN_1' AS STACK;
	END
	ELSE
	BEGIN
	SET @@CHK_PMP = (SELECT COUNT(1) FROM TB_R_WP_SECURITY_CHECK WHERE PIC_STATUS = 'PMP' AND ID_TB_R_WP_PROJECT_JOB_ID = @@ID_IMPB);

	IF(@@CHK_PMP > 0)
	BEGIN
		INSERT INTO TB_R_WP_SECURITY_CHECK
		(
			[ID_TB_R_WP_PROJECT_JOB_ID],
			[ID_TB_M_EMPLOYEE],
			[ID_SECURITY_EMPLOYEE_CHECK_IN],
			DATE,
			[CHECK_IN],
			[PIC_STATUS]
		) 
		VALUES(
			@@ID_IMPB,
			@ID,
			@@GETSECURITY_ID,
			GETDATE(),
			GETDATE(),
			@@PIC_STATUS
		);

		SELECT 'TRUE' AS LINE_STS, 'SCAN_2' AS STACK;
	END
	ELSE
	BEGIN
		SELECT 'FALSE' AS LINE_STS, 'SCAN' AS STACK;
	END
	END
END
ELSE
BEGIN
	UPDATE TB_R_WP_SECURITY_CHECK 
	SET CHECK_OUT = GETDATE(), 
	    ID_SECURITY_EMPLOYEE_CHECK_OUT = @@GETSECURITY_ID 
	WHERE ID_TB_M_EMPLOYEE = @ID AND ID_TB_R_WP_PROJECT_JOB_ID = @@ID_IMPB AND CONVERT(DATE, DATE) = CONVERT(DATE, GETDATE())
	SELECT 'TRUE' AS LINE_STS, 'SCAN_3' AS STACK;
END