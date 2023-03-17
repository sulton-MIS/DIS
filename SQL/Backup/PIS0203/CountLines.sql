-- CountLines
SELECT COUNT(Code) 
  FROM (
			SELECT 
				Code		= LINE_CD, 
				Name		= LINE_NM, 
				CreatedBy	= CREATED_BY, 
				CreatedDate = CREATED_DT, 
				ChangedBy	= CHANGED_BY, 
				ChangedDate	= CHANGED_DT 
			FROM [dbo].[TB_M_LINE]
		  ) AS DATA
  WHERE	Code LIKE '%'+ ISNULL('','') +'%' 
