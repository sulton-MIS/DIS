DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM TB_R_WP_HEADER WHERE Project_CD = @PROJECT_CODE AND Project_Name = @PROJECT_NAME);
	IF(@@CNT > 0)
	BEGIN
		SELECT 
			@@MSG_TEXT = MSG_TEXT,
			@@MSG_TYPE = MSG_TYPE
		FROM dbo.FN_GENERATE_MSG('MPISSTD049E', 'NOREG : ' + @PROJECT_CODE, NULL, NULL, NULL);
		SET @@CHK = 'FALSE';
		SET @@ERR = @@MSG_TEXT;
		
	END ELSE
	BEGIN
		
		INSERT INTO TB_R_WP_HEADER
		(
			 [Project_CD]
			,[Project_Name]
			,[Location]
			,[Tanggal_Pelaksanaan]
			,[Jam_Pelaksanaan]
			,[Divisi_Dept]
			,[Status]
			,[Pelaksana]
			,[Nama_Kontraktor]
			,[Nama_Pimpinan]
			,[Nama_Pengawas]
			,[CREATE_BY]
			,[CREATE_DT]
			,[UPDATE_BY]
			,[UPDATE_DT]
			
		)
		VALUES
		(
			@PROJECT_CODE,
			@PROJECT_NAME,
			@LOCATION,
			@DATE,
			@TIME,
			@DIVISION,
			@STATUS,
			@EXECUTOR,
			@CONTRACTOR,
			@LEADER_NAME,
			@SUPERVISOR_NAME,
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