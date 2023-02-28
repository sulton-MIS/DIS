DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (
				  SELECT 
					COUNT(1) 
				  FROM 
					TB_R_LEARN_REG_PROJ_EMPLOYEE 
				  WHERE
					ID_TB_M_EMPLOYEE = @Worker 
					AND ID_TB_R_WP_PROJECT = @Project
					AND ID_TB_M_COMPANY = @Company
				);
	
	
	IF(@@CNT > 0)
	BEGIN
		SELECT 
			@@MSG_TEXT = MSG_TEXT,
			@@MSG_TYPE = MSG_TYPE
		FROM dbo.FN_GENERATE_MSG('MPISSTD049E', 'REGISTER WORKER IN PROJECT : ' +@Worker , NULL, NULL, NULL);
		SET @@CHK = 'FALSE';
		SET @@ERR = @@MSG_TEXT;
		
	END ELSE
	BEGIN
		
		INSERT INTO TB_R_LEARN_REG_PROJ_EMPLOYEE
		(
			   ID_TB_M_EMPLOYEE
			  ,ID_TB_R_WP_PROJECT
			  ,ID_TB_M_COMPANY
			  ,DATE_JOIN_PROJECT
			  ,COMPANY_FROM
			  ,COMPANY_TO

			  ,CREATED_BY
			  ,CREATED_DT
			  ,UPDATED_BY
			  ,UPDATED_DT
		)
		VALUES
		(
			@Worker
			, @Project
			, @Company
			, @JoinDate
			, @Company_from
			, @Company_to
            
			,@Username
			,GETDATE()
			,@Username
			,GETDATE()
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR REGISTER WORKER IN PROJECT :' +@Worker+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
