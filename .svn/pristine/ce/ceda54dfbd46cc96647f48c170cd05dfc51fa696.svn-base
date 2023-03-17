SELECT * FROM ( 
		SELECT ROW_NUMBER() OVER (ORDER BY a.PLANT_CD,a.LOGICAL_TERMINAL ASC) AS Number
	  ,	PlantCode			= a.PLANT_CD
	  ,	PlantName			= c.PLANT_NM 
	  ,	BCTypeKey			= a.BC_TYPE
	  ,	BCTypeValue			= d.MODEL
	  ,	PrinterNameKey		= a.LOGICAL_TERMINAL
	  ,	PrinterNameValue	= a.LOGICAL_TERMINAL
	  ,	StatusKey			= a.STATUS_LIVE
	  ,	StatusValue			= (select top 1 e.SYSTEM_VALUE_TEXT from TB_M_SYSTEM e where e.SYSTEM_ID = 'STATUS_LIVE' and e.SYSTEM_TYPE = a.STATUS_LIVE) 
	  , SeqNoFlag			= a.SEQ_NO_FLAG
	  , SeqNoPriority		= a.SEQ_NO_PRIORITY
	  , BodyNoFlag			= a.BODY_NO_FLAG
	  , BodyNoPriority		= a.BODY_NO_PRIORITY
	  , ModelFlag			= a.MODEL_FLAG
	  , ModelPriority		= a.MODEL_PRIORITY
	  , SpecNoFlag			= a.SPEC_NO_FLAG
	  , SpecNoPriority		= a.SPEC_NO_PRIORITY
	  , PartNoFlag			= a.PART_NO_FLAG
	  , PartNoPriority		= a.PART_NO_PRIORITY
	  ,	CreatedBy			= a.CREATED_BY
      ,	CreatedDate			= a.CREATED_DT
	  ,	ChangedBy			= a.CHANGED_BY
      ,	ChangedDate			= a.CHANGED_DT
  FROM  TB_M_TELE_PRINTER a LEFT JOIN TB_M_PRINTER_MAPPING b
  ON a.LOGICAL_TERMINAL = b.LOGICAL_TERMINAL
  LEFT JOIN TB_M_USER_PLANT c on a.PLANT_CD = c.PLANT_CD
  LEFT JOIN TB_M_BC_TYPE d on a.BC_TYPE = d.BC_TYPE
    WHERE 
	a.PLANT_CD LIKE '%' + ISNULL(@PlantCode, '%') + '%' 
  AND
	a.BC_TYPE LIKE '%' + ISNULL(@BcType, '%') + '%' 
  AND
	a.LOGICAL_TERMINAL LIKE '%' + ISNULL(@PrinterId, '%') + '%' 
  AND
	a.STATUS_LIVE LIKE '%' + ISNULL(@Status, '%') + '%' 
  ) AS DATA

WHERE Number BETWEEN @FromNumber AND @ToNumber
ORDER BY Number
