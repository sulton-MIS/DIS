-- PIS0202 - GetData
SELECT	
		LogicalTerminal = a.LOGICAL_TERMINAL
	,	VinNo = a.VIN_NO
	,	BodyNo = a.BODY_NO
	,	IdNo = a.ID_NO
	,	BcType = a.BC_TYPE
	,	PlantCode = a.PLANT_CD
	,	BcStatus = a.BC_STS
	,	SeqNo = a.SEQ_NO
	,	ObjectArgument = a.OBJECT_ARGUMENT
	,	Suffix = a.SUFFIX
	,	KoDate = a.KO_DT
	,	ModelCode = a.MODEL_CD
	,	ColorCode = a.COLOR_CD
	,	HarigamiStatus = a.HARIGAMI_STS
	,	StatusLive = a.STATUS_LIVE
	,	EHarigamiStatusHd = a.eHARIGAMI_STS_HD
	,	PrinterTypeId = a.PRINTER_TYPE_ID
	,	CreatedBy = a.CREATED_BY
	,	CreatedDate = a.CREATED_DT
	,	ChangedBy = a.CHANGED_BY
	,	ChangedDate = a.CHANGED_DT
FROM	dbo.TB_R_HARIGAMI_H a
INNER JOIN dbo.TB_S_HARIGAMI_H b
	ON	b.LOGICAL_TERMINAL = a.LOGICAL_TERMINAL
	AND	b.VIN_NO = a.VIN_NO
	AND b.BODY_NO = a.BODY_NO
	AND b.ID_NO = a.ID_NO
	AND b.BC_TYPE = a.BC_TYPE
	AND b.PLANT_CD = a.PLANT_CD
WHERE	b.SEQ_NO = @SeqNo
