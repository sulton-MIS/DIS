SELECT
	[code_trans]
	,[transportation] as jenis_transportation
FROM
	ad_dis_pc_master_transportation_code
WHERE
	transportation not like '%FOB%' 
ORDER BY
	[code_trans] asc
