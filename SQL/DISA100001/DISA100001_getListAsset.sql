--------------- Cek Data Asset Yang Tersedia ---------------------------
SELECT 
	id_tb_m_asset as id, 
	dt_asset.no_asset as no_asset, 
	nama_asset as nama_asset 
FROM 
	ad_dis_ma_master_asset as dt_asset
WHERE
	no_asset not in (SELECT dt_asset.no_asset 
					FROM ad_dis_ma_master_asset dt_asset 
					LEFT JOIN ad_dis_ma_lapor_asset dt_lapor 
					ON dt_asset.no_asset = dt_lapor.no_asset  
					WHERE (dt_lapor.flg_approval_lapor = null))
	
	AND no_asset not in(SELECT dt_asset.no_asset 
					FROM ad_dis_ma_master_asset as dt_asset
					LEFT JOIN  ad_dis_ma_dispose_asset as dt_dispose 
					ON dt_asset.no_asset = dt_dispose.no_asset
					WHERE created_by_sign <> '' AND status_approval not like 'Rejected%' )
	
	AND no_asset not in(SELECT dt_asset.no_asset 
					FROM ad_dis_ma_master_asset dt_asset 
					LEFT JOIN ad_dis_ma_audit_asset dt_audit
					ON dt_asset.no_asset = dt_audit.no_asset  
					WHERE dt_audit.created_date between (getdate() - 2) AND (getdate() + 2))

	AND dept_user LIKE '%' + RTRIM(@NAMA_DEPT) + '%'
	AND dt_asset.flg_dispose_asset <> 1
ORDER BY 
	no_asset desc


------------2022/09/25--------------------
--SELECT 
--	id_tb_m_asset as id, 
--	dt_asset.no_asset as no_asset, 
--	nama_asset as nama_asset 
--FROM 
--	ad_dis_ma_master_asset as dt_asset

--WHERE
--	no_asset not in (SELECT dt_asset.no_asset 
--					FROM ad_dis_ma_master_asset dt_asset 
--					LEFT JOIN ad_dis_ma_lapor_asset dt_lapor 
--					ON dt_asset.no_asset = dt_lapor.no_asset  
--					WHERE (dt_lapor.flg_approval_lapor = null))
--	AND no_asset not in(SELECT dt_asset.no_asset 
--					FROM ad_dis_ma_master_asset as dt_asset
--					LEFT JOIN  ad_dis_ma_dispose_asset as dt_dispose 
--					ON dt_asset.no_asset = dt_dispose.no_asset
--					WHERE created_by_sign <> '' AND status_approval not like 'Rejected%' )

-------------2022/08/01--------------------
--SELECT 
--	id_tb_m_asset as id, 
--	dt_asset.no_asset as no_asset, 
--	nama_asset as nama_asset 
--FROM 
--	ad_dis_ma_master_asset dt_asset
--WHERE
--	no_asset not in (SELECT dt_asset.no_asset 
--					FROM ad_dis_ma_master_asset dt_asset 
--					LEFT JOIN ad_dis_ma_lapor_asset dt_lapor 
--					ON dt_asset.no_asset = dt_lapor.no_asset  
--					WHERE (dt_lapor.flg_approval_lapor = null))
--	AND (flg_dispose_asset IS NULL OR flg_dispose_asset = 0) 


---------------OLD------------
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