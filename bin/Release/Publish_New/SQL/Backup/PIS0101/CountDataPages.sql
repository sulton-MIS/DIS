-- CountLines
SELECT COUNT(PlantCode) 
  FROM (
		SELECT 
			PlantCode			= a.PLANT_CD
		  ,	PlantName			= c.PLANT_NM 
		  ,	TemplateName		= a.TEMPLATE_NM
		  ,	BCTypeKey			= a.BC_TYPE
		  ,	BCTypeValue			= d.MODEL
		  ,	PrinterNameKey		= a.LOGICAL_TERMINAL
		  ,	PrinterNameValue	= b.LOGICAL_TERMINAL
		  ,	PageTypeKey			= a.PAGE_TYPE
		  ,	PageTypeValue		= a.PAGE_TYPE
		  , JsonPages			= e.OBJECT_ARGUMENT
		  ,	StatusKey			= a.STATUS_LIVE
		  ,	OrientationKey		= a.ORIENTATION
		  ,	OrientationValue	= a.ORIENTATION
		  ,	HarigamiStatusKey	= a.HARIGAMI_STS
	  FROM  TB_R_PAGE_H a 
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

