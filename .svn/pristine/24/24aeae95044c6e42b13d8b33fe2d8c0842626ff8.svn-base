SELECT *
FROM
(
	SELECT	Number = ROW_NUMBER() OVER (ORDER BY SEQ_NO) 
		  ,	SeqNo	= A.SEQ_NO
		  ,	Model	= '' --MODEL_CD
		  ,	Suffix	= A.SUFFIX
		  ,	BodyNo	= A.BODY_NO
		  ,	Color	= A.COLOR_CD
		  ,	CreatedBy	= A.CREATED_BY
		  ,	CreatedDate = A.CREATED_DT
		  ,	ChangedBy   = A.CHANGED_BY
		  ,	ChangedDate	= A.CHANGED_DT
FROM TB_R_ALC_DATA_H A
LEFT JOIN TB_R_PAGE_H B
	ON A.LOGICAL_TERMINAL = B.LOGICAL_TERMINAL
		AND A.PLANT_CD = B.PLANT_CD
		AND A.BC_TYPE = B.BC_TYPE
LEFT JOIN TB_R_JOB_PRINTER C
	ON A.LOGICAL_TERMINAL = C.LOGICAL_TERMINAL
WHERE (((ISNULL(@IsInitial, '') = '0' AND ISNULL(@HarigamiStatus, '') = '') AND HARIGAMI_STS = HARIGAMI_STS)
		OR ((ISNULL(@IsInitial, '') = '0' AND ISNULL(@HarigamiStatus, '') <> '') AND HARIGAMI_STS = @HarigamiStatus)
		OR (ISNULL(@IsInitial, '') = '1' AND HARIGAMI_STS IN (SELECT SYSTEM_TYPE FROM TB_M_SYSTEM WHERE SYSTEM_ID = 'E_HARIGAMI_STS_INITIAL'))
		)
	AND ((ISNULL(@SeqNo, '') = '' AND SEQ_NO = SEQ_NO) OR (ISNULL(@SeqNo, '') <> '') AND SEQ_NO = @SeqNo)
	--AND ((ISNULL(@Model, '') = '' AND MODEL_CD = MODEL_CD) OR (ISNULL(@Model, '') <> '') AND MODEL_CD = @Model)
	AND ((ISNULL(@Suffix, '') = '' AND SUFFIX = SUFFIX) OR (ISNULL(@Suffix, '') <> '') AND SUFFIX = @Suffix)
	AND ((ISNULL(@BodyNo, '') = '' AND BODY_NO = BODY_NO OR (ISNULL(@BodyNo, '') <> '') AND BODY_NO LIKE '%' + @BodyNo + '%'))
	AND (
			((ISNULL(@KODateFrom, '') = '' AND ISNULL(@KODateTo, '') = '') AND KO_DT = KO_DT)
			OR ((ISNULL(@KODateFrom, '') <> '' AND ISNULL(@KODateTo, '') = '') AND CAST(KO_DT AS DATE) > CAST(@KODateFrom AS DATE))
			OR ((ISNULL(@KODateFrom, '') = '' AND ISNULL(@KODateTo, '') <> '') AND CAST(KO_DT AS DATE) < CAST(@KODateTo AS DATE))
			OR ((ISNULL(@KODateFrom, '') <> '' AND ISNULL(@KODateTo, '') <> '') AND CAST(KO_DT AS DATE) BETWEEN CAST(@KODateFrom AS DATE) AND CAST(@KODateTo AS DATE))
		)
	AND C.PRINTER_TYPE_ID = (SELECT SYSTEM_TYPE FROM TB_M_SYSTEM WHERE SYSTEM_ID = 'PRINTER_ID_FOR_E_HARIGAMI')
) AS DATA
WHERE Number BETWEEN @Start AND @Length