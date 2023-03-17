﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
BEGIN TRY
	UPDATE TB_R_LEARN_EXAM_SUBJECT SET 
							TITLE = @TITLE
							,PASSING_SCORE_REQUIREMENT = @PASSING_SCORE_REQUIREMENT
							,EXAM_DURATION = @EXAM_DURATION
							,DATE_EXAM_PERIOD_START = @DATE_EXAM_PERIOD_START
							,DATE_EXAM_PERIOD_END = @DATE_EXAM_PERIOD_END
							,REMEDIAL = @REMEDIAL
							,EXAM_TYPE = @EXAM_TYPE
							,TOTAL_PUBLISHED = @TOTAL_PUBLISHED
							,IS_PUBLISHED = @IS_PUBLISHED
							,EXAM_FOR = @Exam_For
							,UPDATED_BY = @USERNAME
							,UPDATED_DT = GETDATE()
					WHERE ID_TB_R_LEARN_EXAM_SUBJECT = @ID
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ID_TB_R_LEARN_EXAM_SUBJECT:' +@TITLE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS