--SELECT 
--	ROW_NUMBER() OVER (ORDER BY no_asset ASC) ROW_NUM,
--	--no_asset as ID, 
--	*
--FROM 
--	[ad_dis_ma_history_asset]			
--WHERE 
--	no_asset = @ID 
--ORDER BY 
--	created_date DESC

SELECT 
	ROW_NUMBER() OVER (ORDER BY dt_hist.no_asset ASC) ROW_NUM,
	--no_asset as ID, 
	dt_hist.no_asset,
	dt_master.nama_asset,
	CASE WHEN dt_master.id_pr is null THEN '' ELSE dt_master.id_pr end as id_pr,
	dt_hist.keterangan,
	dt_hist.status,
	dt_hist.nama_fitur,
	dt_hist.created_by,
	dt_hist.created_date
FROM 
	[ad_dis_ma_history_asset] as dt_hist
LEFT JOIN ad_dis_ma_master_asset as dt_master ON dt_hist.no_asset = dt_master.no_asset	
WHERE 
	dt_hist.no_asset = @ID 
ORDER BY 
	dt_hist.created_date DESC