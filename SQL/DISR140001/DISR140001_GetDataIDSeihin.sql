SELECT	
	id_seihin
FROM
	[Z_RT_data_K_seisanID]
WHERE 
	id_seisan = @id_seisan
	and id_seisan not like ''