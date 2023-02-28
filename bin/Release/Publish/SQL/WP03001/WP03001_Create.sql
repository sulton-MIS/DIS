﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM TB_M_LEARN_QUESTION WHERE CONVERT(VARCHAR, QUESTION) = @QUESTION);
	IF(@@CNT > 0)
	BEGIN
		SELECT @@MSG_TYPE = MSG_TYPE, @@MSG_TEXT  = MSG_TEXT FROM TB_M_MESSAGE WHERE MSG_ID = 'MWP004'
		
		SET @@CHK = 'FALSE';
		SET @@ERR = @@MSG_TEXT;
		
	END ELSE
	BEGIN
		
		INSERT INTO TB_M_LEARN_QUESTION
		(
			   [CATEGORY]
			  ,[QUESTION]
			  ,[ANSWER_CHOICE_A]
			  ,[ANSWER_CHOICE_B]
			  ,[ANSWER_CHOICE_C]
			  ,[ANSWER_CHOICE_D]
			  ,[ANSWER_CHOICE_E]
			  ,[ANSWER_KEY]
			  ,[IMAGE]
			  ,[CREATED_BY]
			  ,[CREATED_DT]
			  ,[UPDATED_BY]
			  ,[UPDATED_DT]

		)
		VALUES
		(
			@CATEGORY,
			@QUESTION,
			@ANSWER_CHOICE_A,
			@ANSWER_CHOICE_B,
			@ANSWER_CHOICE_C,
			@ANSWER_CHOICE_D,
			@ANSWER_CHOICE_E,
			@ANSWER_KEY,
			@IMAGE,
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
	SET @@ERR = 'ERROR QUESTION BANK :' +@QUESTION+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
