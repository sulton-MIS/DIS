SELECT 
	id_tb_m_asset as id, 
	dt_asset.no_asset as no_asset, 
	nama_asset as nama_asset 
FROM 
	ad_dis_ma_master_asset dt_asset
WHERE
	no_asset not in (SELECT dt_asset.no_asset 
					FROM ad_dis_ma_master_asset dt_asset 
					LEFT JOIN ad_dis_ma_lapor_asset dt_lapor 
					ON dt_asset.no_asset = dt_lapor.no_asset  
					WHERE (dt_lapor.flg_approval_lapor = 0))
	AND (flg_dispose_asset IS NULL OR flg_dispose_asset = 0) 
--UNION
--SELECT 
--	id_tb_m_asset as id, 
--	dt_asset.no_asset as no_asset, 
--	nama_asset as nama_asset 
--FROM 
--	ad_dis_ma_lapor_asset  dt_lapor
--LEFT JOIN
--	ad_dis_ma_master_asset dt_asset  ON dt_lapor.no_asset = dt_asset.no_asset
--WHERE 
--	(dt_lapor.flg_approval_lapor = 1)