DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM TB_R_WP_DETAIL WHERE Project_CD = @PROJECT_CODE);
	IF(@@CNT > 0)
	BEGIN
		SELECT 
			@@MSG_TEXT = MSG_TEXT,
			@@MSG_TYPE = MSG_TYPE
		FROM dbo.FN_GENERATE_MSG('MPISSTD049E', 'PROJECT CODE : ' + @PROJECT_CODE, NULL, NULL, NULL);
		SET @@CHK = 'FALSE';
		SET @@ERR = @@MSG_TEXT;
		
	END ELSE
	BEGIN
		
		INSERT INTO TB_R_WP_DETAIL
		(
			 [Project_CD]
			,[Location]
			,[Pekerjaan]
			,[HighLevel]
			,[MediumLevel]
			,[LowLevel]
			,[Tanggal_Pekerjaan]
			,[Category]
			,[remarks]
			,[Status]
			,[CREATE_BY]
			,[CREATE_DT]
			,[UPDATE_BY]
			,[UPDATE_DT]
			
		)
		VALUES
		(
			@PROJECT_CODE,
			@LOCATION,
			@JOBS,
			CASE WHEN @DANGERLEVEL = 3 THEN
				1
				ELSE
				0
			END,
			CASE WHEN @DANGERLEVEL = 2 THEN
				1
				ELSE
				0
			END,
			CASE WHEN @DANGERLEVEL = 1 THEN
				1
				ELSE
				0
			END,
			@DATE,
			@CATEGORY,
			@REMARKS,
			0,
			@USERNAME,
			GETDATE(),
			@USERNAME,
			GETDATE()
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT WP_HEADER:' +@PROJECT_CODE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS