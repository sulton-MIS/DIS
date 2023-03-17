﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
BEGIN TRY
	UPDATE TB_R_WP_DETAIL SET PROJECT_CODE = @PROJECT_CODE, JOBS = @JOBS, LOWLEVEL = @LOWLEVEL, MEDIUMLEVEL = @MEDIUMLEVEL, HIGHLEVEL = @HIGHLEVEL, DATE = @DATE, REMARKS = @REMARKS, 

		CAT_A = @CAT_A,
		CAT_B = @CAT_B,
		CAT_C = @CAT_C,
		CAT_D = @CAT_D,
		CAT_E = @CAT_E,
		CAT_F = @CAT_F
	WHERE ID = @ID
	SET @@CHK = 'TRUE';
	SET @@ERR ='Data has been successfully Updated';
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE WP_HEADER:' +@PROJECT_CODE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS