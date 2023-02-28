	SELECT 
		[Z_HEAD].code as CODE
		,[Z_HEAD].name as NAME_CODE
	FROM
		[Z_HEAD]
	WHERE
		[Z_HEAD].CODE like '' + @ITEM_CODE +'%'