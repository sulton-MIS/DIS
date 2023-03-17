--create by  : Septareo sagita
--created date : 28 Feb 2017



INSERT INTO dbo.TB_R_BATCH_QUEUE
(
		PROJECT_CODE
	,	BATCH_ID
	,	REQUEST_ID
	,	REQUEST_DATE
	,	REQUEST_BY
	,	SUPPORT_ID
	,	PARAMETER
)
SELECT 
		'AD021'
	,	@FuncBatchID
	,	@FuncScreenID
	,	GETDATE()
	,	@Username
	,	NULL
	,	@FuncBatchID +'#:#' + @Username + '#:#' + @ProcessId + '#:#' + @Parameter