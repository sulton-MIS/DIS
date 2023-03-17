-- CountData
SELECT COUNT(StyleCode) 
  FROM (
			SELECT 
				StyleCode		= STYLE_CD, 
				StyleName		= STYLE_NM, 
				CreatedBy		= CREATED_BY, 
				CreatedDate		= CREATED_DT, 
				ChangedBy		= CHANGED_BY, 
				ChangedDate		= CHANGED_DT 
			FROM [dbo].[TB_M_STYLE]
		  ) AS DATA
  WHERE 
	StyleCode LIKE '%' + ISNULL(@StyleCode, '%') + '%' 
  AND
	StyleName LIKE '%' + ISNULL(@StyleName, '%') + '%' 
