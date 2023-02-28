SELECT * FROM ( 
		SELECT ROW_NUMBER() OVER (ORDER BY a.PLANT_CD ASC) AS Number
	  ,	PlantCode			= a.PLANT_CD
	  ,	PlantName			= c.PLANT_NM 
	  ,	TemplateName		= a.TEMPLATE_NM
      ,	BCTypeKey			= a.BC_TYPE
	  ,	BCTypeValue			= d.MODEL
	  ,	PrinterNameKey		= a.LOGICAL_TERMINAL
	  ,	PrinterNameValue	= a.LOGICAL_TERMINAL
	  ,	PageTypeKey			= a.PAGE_TYPE
	  ,	PageTypeValue		= a.PAGE_TYPE
	  ,	StatusKey			= a.STATUS_LIVE
	  ,	StatusValue			= (select top 1 e.SYSTEM_VALUE_TEXT from TB_M_SYSTEM e where e.SYSTEM_ID = 'STATUS_LIVE' and e.SYSTEM_TYPE = a.STATUS_LIVE) 
	  ,	OrientationKey		= a.ORIENTATION
	  ,	OrientationValue	= (select top 1 f.SYSTEM_VALUE_TEXT from TB_M_SYSTEM f where f.SYSTEM_ID = 'ORIENTATION_PAPER' and f.SYSTEM_TYPE = a.[HARIGAMI_STS])
	  ,	HarigamiStatusKey	= a.HARIGAMI_STS
	  ,	HarigamiStatusValue	= (select top 1 g.SYSTEM_VALUE_TEXT from TB_M_SYSTEM g where g.SYSTEM_ID = 'HARIGAMI_STATUS' and g.SYSTEM_TYPE = a.[HARIGAMI_STS])
	  , JsonPages			= e.OBJECT_ARGUMENT
	  ,	CreatedBy			= a.CREATED_BY
      ,	CreatedDate			= a.CREATED_DT
	  ,	ChangedBy			= a.CHANGED_BY
      ,	ChangedDate			= a.CHANGED_DT
  FROM  dbo.TB_R_PAGE_H a 
  LEFT OUTER JOIN dbo.TB_R_PAGE_D e 
  ON	e.PLANT_CD = a.PLANT_CD
  AND e.TEMPLATE_NM = a.TEMPLATE_NM
  AND e.BC_TYPE = a.BC_TYPE
  AND e.LOGICAL_TERMINAL = a.LOGICAL_TERMINAL
  LEFT OUTER JOIN TB_M_PRINTER_MAPPING b
  ON a.LOGICAL_TERMINAL = b.LOGICAL_TERMINAL
  LEFT OUTER JOIN TB_M_USER_PLANT c on a.PLANT_CD = c.PLANT_CD
  LEFT OUTER JOIN TB_M_BC_TYPE d on a.BC_TYPE = d.BC_TYPE
    WHERE 
	a.PLANT_CD LIKE '%' + ISNULL(@PlantCode, '%') + '%' 
  AND
	a.TEMPLATE_NM LIKE '%' + ISNULL(@TemplateName, '%') + '%' 
  AND
	a.BC_TYPE LIKE '%' + ISNULL(@BcType, '%') + '%' 
  AND
	a.LOGICAL_TERMINAL LIKE '%' + ISNULL(@LogicalTerminal, '%') + '%'   
  ) AS DATA

WHERE Number BETWEEN @FromNumber AND @ToNumber
ORDER BY Number
