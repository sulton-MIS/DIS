SELECT DISTINCT 
	A.id_hinmoku,
	A.other_lotNo
FROM 
	dbo.Z_RT_data_K_seisanID A		
WHERE 1=1	
AND 
	A.id_seisan = RTRIM(@ID_SEISAN)