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
		  ,	PrinterNameValue	= a.LOGICAL_TERMINAL
		  ,	PageTypeKey			= a.PAGE_TYPE
		  ,	PageTypeValue		= a.PAGE_TYPE
		  ,	StatusKey			= a.STATUS_LIVE
		  ,	OrientationKey		= a.ORIENTATION
		  ,	OrientationValue	= a.ORIENTATION
		  ,	HarigamiStatusKey	= a.HARIGAMI_STS
	  FROM  TB_R_PAGE_H a LEFT JOIN TB_M_PRINTER_MAPPING b
  ON a.LOGICAL_TERMINAL = b.LOGICAL_TERMINAL
  LEFT JOIN TB_M_USER_PLANT c on a.PLANT_CD = c.PLANT_CD
  LEFT JOIN TB_M_BC_TYPE d on a.BC_TYPE = d.BC_TYPE
    WHERE 
	a.PLANT_CD LIKE '%' + ISNULL(@PlantCode, '%') + '%' 
  AND
	a.TEMPLATE_NM LIKE '%' + ISNULL(@TemplateName, '%') + '%' 
  AND
	a.BC_TYPE LIKE '%' + ISNULL(@BcType, '%') + '%' 
  AND
	a.LOGICAL_TERMINAL LIKE '%' + ISNULL(@LogicalTerminal, '%') + '%' 
  AND
	a.PAGE_TYPE LIKE '%' + ISNULL(@PageType, '%') + '%' 
  AND
	a.STATUS_LIVE LIKE '%' + ISNULL(@Status, '%') + '%' 
 ) AS DATA

