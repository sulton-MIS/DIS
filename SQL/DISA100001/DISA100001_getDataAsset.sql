SELECT 
	id_tb_m_asset as id, 
	*,
	dt_lokasi.nama_lokasi
	--dt_asset.no_asset as no_asset, 
	--nama_asset as nama_asset 
FROM 
	ad_dis_ma_master_asset as dt_asset
LEFT JOIN ad_dis_ma_lokasi_asset as dt_lokasi ON dt_asset.kd_lokasi = dt_lokasi.kd_lokasi

WHERE
	no_asset = RTRIM(@NO_ASSET)
	AND dt_asset.flg_dispose_asset <> 1