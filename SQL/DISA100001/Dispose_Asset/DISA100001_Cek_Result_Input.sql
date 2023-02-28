SELECT 
		*
	from 
		[ad_dis_ma_dispose_asset] as dt_dispose
	WHERE
		dt_dispose.no_dispose LIKE '%'+@NO_DISPOSE+'%' ;