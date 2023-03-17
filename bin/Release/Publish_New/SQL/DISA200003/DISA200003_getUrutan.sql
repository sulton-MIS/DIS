  SELECT 
  CASE WHEN 
	LEN(no_asset) < 11 THEN CAST(SUBSTRING (no_asset, 10, 12) as int)
  ELSE 
	CAST(SUBSTRING (no_asset, 11, 12) as int) 
  END as no_urut
  FROM [ad_dis_ma_master_asset]
  WHERE 
	id_tb_m_asset in (select top 1 (id_tb_m_asset) from [ad_dis_ma_master_asset] order by id_tb_m_asset desc)

