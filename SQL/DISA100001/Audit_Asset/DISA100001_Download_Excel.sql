SELECT
	ROW_NUMBER() OVER (ORDER BY dt_audit.no_audit ASC) ROW_NUM,
	dt_audit.no_audit,
	dt_audit.jenis_audit,
	dt_audit.no_asset,
	master_asset.nama_asset,
	master_asset.jenis_asset,
	master_asset.kategori_asset,
	dt_lokasi.nama_lokasi,
	dt_lokasi.area,
	(SELECT CASE WHEN dt_audit.jenis_audit = 'BULANAN' THEN dt_audit.periode_bulan ELSE dt_audit.periode_semester END as periode) periode,
	dt_audit.tahun,
	dt_audit.status,
	dt_audit.keterangan,
	dt_audit.created_by,
	--dt_audit.created_date
	FORMAT (dt_audit.created_date, 'dd-MMMM-yyyy, hh:mm:ss tt') as created_date
FROM
	ad_dis_ma_audit_asset as dt_audit
	LEFT JOIN ad_dis_ma_master_asset as master_asset ON dt_audit.no_asset = master_asset.no_asset
	LEFT JOIN ad_dis_ma_lokasi_asset as dt_lokasi ON master_asset.kd_lokasi = dt_lokasi.kd_lokasi
WHERE
	dt_audit.no_audit LIKE '%' + RTRIM(@NO_AUDIT) + '%'
	AND dt_audit.no_asset LIKE '%' + RTRIM(@NO_ASSET) + '%'
	AND dt_audit.jenis_audit LIKE '%' + RTRIM(@JENIS_AUDIT) + '%'
	AND dt_audit.tahun LIKE '%' + RTRIM(@TAHUN) + '%'
	AND (dt_audit.periode_bulan in(select dt_audit.periode_bulan where dt_audit.periode_bulan LIKE '%' + RTRIM(@PERIODE) + '%') 
		OR 
		dt_audit.periode_semester in (select dt_audit.periode_semester where dt_audit.periode_semester LIKE '%' + RTRIM(@PERIODE) + '%')
		)