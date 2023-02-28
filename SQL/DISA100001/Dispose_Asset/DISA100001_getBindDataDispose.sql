	SELECT 
		no_dispose as NO_DISPOSE,
		dt_dispose_detail.no_asset as NO_ASSET,
		dt_dispose_detail.keterangan as KETERANGAN,
		dt_asset.nama_asset as NAMA_ASSET,
		dt_asset.dept_user as DEPT_USER,
		dt_asset.nama_user as NAMA_USER,
		dt_asset.status as STATUS_KONDISI
	FROM
		ad_dis_ma_dispose_asset_detail as dt_dispose_detail
	LEFT JOIN
		ad_dis_ma_master_asset dt_asset ON dt_dispose_detail.no_asset = dt_asset.no_asset 
	WHERE 
		dt_dispose_detail.no_dispose = @NO_DISPOSE