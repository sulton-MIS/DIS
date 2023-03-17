SELECT * FROM ( 
		SELECT ROW_NUMBER() OVER (ORDER BY STYLE_CD, STYLE_NM ASC) AS Number
	  ,	StyleCode			= STYLE_CD
	  ,	StyleName			= STYLE_NM 
	  ,	CreatedBy			= CREATED_BY
      ,	CreatedDate			= CREATED_DT
	  ,	ChangedBy			= CHANGED_BY
      ,	ChangedDate			= CHANGED_DT
  FROM  TB_M_STYLE 
    WHERE 
	STYLE_CD LIKE '%' + ISNULL(@StyleCode, '%') + '%' 
  AND
	STYLE_NM LIKE '%' + ISNULL(@StyleName, '%') + '%' 
) AS DATA
WHERE Number BETWEEN @FromNumber AND @ToNumber
ORDER BY Number
