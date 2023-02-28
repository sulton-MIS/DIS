SELECT 
	ROW_NUMBER() OVER (ORDER BY no_asset ASC) ROW_NUM,
	no_asset as ID, 
	*, 
	CASE WHEN nama_foto is null THEN '' ELSE nama_foto END as [nama_foto],
	SUBSTRING(format(harga_satuan, 'C','id-ID'), 3, 100) as harga_satuan,
	SUBSTRING(format(total, 'C','id-ID'), 3, 100) as total,
	CASE WHEN FLG_LABEL_ASSET = 1 then 'Sudah label' ELSE 'Belum Label' END as FLG_LABEL_ASSET,
	CASE WHEN FLG_DISPOSE_ASSET = 1 then 'Dispose' WHEN FLG_DISPOSE_ASSET = 0 then 'Non-Dispose'  ELSE 'Non-Dispose' END as FLG_DISPOSE_ASSET,
	LEFT(CONVERT(VARCHAR, tgl_dokumen, 120), 10) as tgl_dokumen,
	LEFT(CONVERT(VARCHAR, tgl_register, 120), 10) as tgl_register,
	LEFT(CONVERT(VARCHAR, tgl_dispose_asset, 120), 20) as tgl_dispose
FROM ad_dis_ma_master_asset			
LEFT JOIN ad_dis_ma_lokasi_asset
ON ad_dis_ma_master_asset.kd_lokasi = ad_dis_ma_lokasi_asset.kd_lokasi
WHERE 
no_asset = @ID
