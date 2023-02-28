SELECT
	ROW_NUMBER() OVER (ORDER BY dt_dispose.no_dispose ASC) ROW_NUM,
	--dt_dispose.no_dispose,
	dt_dispose_detail.no_asset,
	dt_asset.nama_asset,
	dt_asset.merek,
	dt_asset.tipe,
	--dt_asset.nama_user,
	--dt_asset.dept_user,
	dt_dispose_detail.keterangan
FROM
	ad_dis_ma_dispose_asset as dt_dispose
LEFT JOIN
	ad_dis_ma_dispose_asset_detail as dt_dispose_detail ON dt_dispose.NO_DISPOSE = dt_dispose_detail.NO_DISPOSE
LEFT JOIN
	ad_dis_ma_master_asset as dt_asset ON dt_dispose_detail.NO_ASSET = dt_asset.NO_ASSET
WHERE
	dt_dispose.no_dispose LIKE '%' + RTRIM(@NO_DISPOSE) + '%'
