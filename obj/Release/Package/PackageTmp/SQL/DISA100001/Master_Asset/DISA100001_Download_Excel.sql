SET @FLG_DISPOSE_ASSET = CASE @FLG_DISPOSE_ASSET 
						 WHEN '1' THEN '1'
						 WHEN '' THEN '0'
						 ELSE 0
						 END 

SELECT 
	ROW_NUMBER() OVER (ORDER BY dt_asset.no_asset ASC) ROW_NUM,
	dt_asset.no_asset,
	dt_asset.nama_asset,
	dt_asset.nama_asset_invoice,
	dt_asset.item_code,
	dt_asset.merek,
	dt_asset.tipe,
	dt_asset.supplier,
	LEFT(CONVERT(VARCHAR, dt_asset.tgl_register, 120), 10) as tgl_register,
	dt_asset.jenis_dokumen,
	dt_asset.no_aju,
	LEFT(CONVERT(VARCHAR, dt_asset.tgl_dokumen, 120), 10) as tgl_dokumen,
	dt_asset.pic_request,
	dt_asset.dept_request,
	CAST(dt_asset.harga_satuan as decimal(18,2)) as harga_satuan,
	--dt_asset.harga_satuan,
	dt_asset.jenis_asset,
	dt_asset.kategori_asset,
	dt_asset.nama_user,
	dt_asset.dept_user,
	dt_asset.kd_lokasi,
	dt_lokasi.nama_lokasi,
	dt_asset.halte,
	dt_asset.umur,
	CASE
		WHEN (select YEAR(getdate()) - YEAR(dt_asset.tahun)) < dt_asset.umur 
		THEN CAST((select YEAR(getdate()) - YEAR(dt_asset.tahun)) as decimal(18,0))
	ELSE
		0
	END as UMUR_AKTUAL,
	cast((0.25 * dt_asset.harga_satuan) as decimal(18,2)) as depresiasi,
	--(0.25 * dt_asset.harga_satuan) as depresiasi,
	CASE 
		WHEN (select YEAR(getdate()) - YEAR(dt_asset.tahun)) < dt_asset.umur 
		THEN cast(((select YEAR(getdate()) - YEAR(dt_asset.tahun)) * (0.25 * dt_asset.harga_satuan)) as decimal(18,2))
		--THEN ((select YEAR(getdate()) - YEAR(dt_asset.tahun)) * (0.25 * dt_asset.harga_satuan))
	ELSE
		0
	END as total_depresiasi,
	CASE 
		WHEN (select YEAR(getdate()) - YEAR(dt_asset.tahun)) < dt_asset.umur 
		THEN CAST(((dt_asset.harga_satuan) - (select YEAR(getdate()) - YEAR(dt_asset.tahun)) * (0.25 * dt_asset.harga_satuan)) as decimal(18,2))
		--THEN ((dt_asset.harga_satuan) - (select YEAR(getdate()) - YEAR(dt_asset.tahun)) * (0.25 * dt_asset.harga_satuan)) 
	ELSE
		0
	END as value_of_asset,
	dt_asset.status,
	CASE 
		WHEN dt_asset.status_penggunaan is NULL THEN 'TIDAK PAKAI'
		ELSE 'PAKAI'
	END as status_penggunaan,
	CASE
		WHEN dt_asset.flg_label_asset = 1 THEN 'SUDAH LABEL'
	ELSE
		'BELUM LABEL'
	END as label_asset,
	CASE
		WHEN dt_asset.flg_dispose_asset = 1 THEN 'DISPOSE'
	ELSE
		'NON-DISPOSE'
	END as dispose_asset,
	dt_asset.tgl_dispose_asset
FROM
	ad_dis_ma_master_asset as dt_asset
	LEFT JOIN ad_dis_ma_lokasi_asset as dt_lokasi ON dt_asset.kd_lokasi = dt_lokasi.kd_lokasi
WHERE
	dt_asset.no_asset LIKE '%' +RTRIM(@NO_ASSET)+ '%'
	AND dt_asset.nama_asset LIKE '%' +RTRIM(@NAMA_ASSET)+ '%'
	AND dt_asset.merek LIKE '%' +RTRIM(@MEREK)+ '%'
	AND dt_asset.supplier LIKE '%' +RTRIM(@SUPPLIER)+ '%'
	AND flg_dispose_asset = @FLG_DISPOSE_ASSET
	AND dt_asset.dept_user LIKE '%' +RTRIM(@DEPARTMENT_USER)+ '%' 
	--AND dt_asset.item_code LIKE '%' +RTRIM(@ITEM_CODE)+ '%'
	AND (dt_asset.item_code LIKE '%' +RTRIM(@ITEM_CODE)+ '%' OR dt_asset.item_code is null)
	AND dt_asset.status LIKE '%' +RTRIM(@STATUS_KONDISI)+ '%' 