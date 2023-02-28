SELECT 
	CASE WHEN
		no_register_asset <> '' THEN (SELECT MAX(no_register_asset) FROM ad_dis_ma_master_asset)
	ELSE
		1
	END no_register_asset
FROM
	ad_dis_ma_master_asset
WHERE 
	no_register_asset in (SELECT TOP 1 (SELECT MAX(no_register_asset) FROM ad_dis_ma_master_asset))

 -- SELECT 
 -- CASE WHEN 
	--LEN(no_asset) < 11 THEN CAST(SUBSTRING (no_asset, 10, 12) as int)
 -- ELSE 
	--CAST(SUBSTRING (no_asset, 11, 12) as int) 
 -- END as no_urut
 -- FROM [ad_dis_ma_master_asset]
 -- WHERE 
	--id_tb_m_asset in (select top 1 (id_tb_m_asset) from [ad_dis_ma_master_asset] order by id_tb_m_asset desc)

