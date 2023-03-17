-- CountLines
SELECT COUNT(PlantCode) 
  FROM (
			SELECT 
					PlantCode			= PLANT_CD,
			  		BCTypeKey			= BC_TYPE,
			  		PrinterNameKey		= LOGICAL_TERMINAL,
					StatusKey			= STATUS_LIVE,
					CreatedBy			= CREATED_BY, 
					CreatedDate			= CREATED_DT, 
					ChangedBy			= CHANGED_BY, 
					ChangedDate			= CHANGED_DT 
			FROM [dbo].[TB_M_TELE_PRINTER]
		 WHERE	
			PLANT_CD LIKE '%' + ISNULL(@PlantCode, '%') + '%' 
		  AND
			BC_TYPE LIKE '%' + ISNULL(@BcType, '%') + '%' 
		  AND
			LOGICAL_TERMINAL LIKE '%' + ISNULL(@PrinterId, '%') + '%' 
		  AND
			STATUS_LIVE LIKE '%' + ISNULL(@Status, '%') + '%' 
		  ) AS DATA
 