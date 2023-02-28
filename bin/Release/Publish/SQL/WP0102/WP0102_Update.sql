DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
BEGIN TRY
	UPDATE TB_R_WP_DETAIL SET Project_CD = @PROJECT_CODE, Location = @LOCATION, Pekerjaan = @JOBS, LowLevel = @LOWLEVEL, MediumLevel = @MEDIUMLEVEL, HighLevel = @HIGHLEVEL, Tanggal_Pekerjaan = @DATE, remarks = @REMARKS, Category = @CATEGORY
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