DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*, 
	RIGHT(no_asset, 5) as no_register,
	TB.nama_asset as NAMA_ASSET,
	SUBSTRING(format(harga_satuan, ''C'',''id-ID''), 3, 100) as harga_satuan,
	--CAST(harga_satuan as decimal(18,2)) as harga_satuan,
	CASE WHEN cost_upgrade IS NULL THEN ''0'' ELSE SUBSTRING(format(cost_upgrade, ''C'',''id-ID''), 3, 100) end as cost_upgrade,
	--CASE WHEN cost_upgrade IS NULL THEN 0 ELSE CAST(cost_upgrade as decimal(18,2)) END as cost_upgrade,
	SUBSTRING(format(total, ''C'',''id-ID''), 3, 100) as total,
	CASE WHEN FLG_LABEL_ASSET = 1 then ''SUDAH LABEL'' ELSE ''BELUM LABEL'' END as FLG_LABEL_ASSET,
	CASE WHEN FLG_DISPOSE_ASSET = 1 then ''DISPOSE'' WHEN FLG_DISPOSE_ASSET = 0 then ''NON-DISPOSE''  ELSE ''NON-DISPOSE'' END as FLG_DISPOSE_ASSET,
	LEFT(CONVERT(VARCHAR, tgl_dokumen, 120), 10) as tgl_dokumen,
	LEFT(CONVERT(VARCHAR, tgl_register, 120), 10) as tgl_register,
	LEFT(CONVERT(VARCHAR, tgl_dispose_asset, 120), 10) as tgl_dispose,
	TB.status as status_kondisi,
	TB.status_penggunaan as STATUS_PENGGUNAAN,
	req_asset.status as status_pengadaan,
	TB.umur as UMUR,
	CAST((select YEAR(getdate()) - TB.tahun) as decimal(18,0)) as UMUR_AKTUAL,
	--CASE
	--	WHEN (select YEAR(getdate()) - TB.tahun) <= TB.umur 
	--	THEN CAST((select YEAR(getdate()) - TB.tahun) as decimal(18,0))
	--ELSE
	--	0
	--END as UMUR_AKTUAL,
	SUBSTRING(format((0.25 * TB.harga_satuan), ''C'',''id-ID''), 3, 100) as DEPRESIASI,
	--CAST((0.25 * TB.harga_satuan) as decimal(18,2)) as DEPRESIASI,
	SUBSTRING(format(((select YEAR(getdate()) - TB.tahun) * (0.25 * TB.harga_satuan)), ''C'',''id-ID''), 3, 100) as TOTAL_DEPRESIASI,
	--CASE 
	--	WHEN (select YEAR(getdate()) - TB.tahun) <= TB.umur 
	--	THEN SUBSTRING(format(((select YEAR(getdate()) - TB.tahun) * (0.25 * TB.harga_satuan)), ''C'',''id-ID''), 3, 100)
	--	--THEN CAST(((select YEAR(getdate()) - TB.tahun) * (0.25 * TB.harga_satuan)) as decimal(18,2))
	--ELSE
	--	''0''
	--END as TOTAL_DEPRESIASI,
	SUBSTRING(format(((TB.harga_satuan) - (select YEAR(getdate()) - TB.tahun) * (0.25 * TB.harga_satuan)), ''C'',''id-ID''), 3, 100) as VALUE_OF_ASSET,
	--CASE 
	--	WHEN (select YEAR(getdate()) - TB.tahun) <= TB.umur 
	--	THEN SUBSTRING(format(((TB.harga_satuan) - (select YEAR(getdate()) - TB.tahun) * (0.25 * TB.harga_satuan)), ''C'',''id-ID''), 3, 100)
	--	--THEN CAST(((TB.harga_satuan) - (select YEAR(getdate()) - TB.tahun) * (0.25 * TB.harga_satuan)) as decimal(18,2))
	--ELSE
	--	''0''
	--END as VALUE_OF_ASSET,
	TB.keterangan as keterangan,
	TB.spesifikasi as spesifikasi


 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY no_asset DESC) ROW_NUM,
	no_asset as ID, 
	*
	FROM [ad_dis_ma_master_asset]		
	WHERE 1=1	
';

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
	END

IF(@FLG_DISPOSE_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND FLG_DISPOSE_ASSET = '''+RTRIM(@FLG_DISPOSE_ASSET)+''' ';
	END
ELSE
	BEGIN
		SET @@QUERY = @@QUERY + 'AND (FLG_DISPOSE_ASSET is null or flg_dispose_asset=0)';
	END

IF(@NAMA_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND nama_asset LIKE ''%'+RTRIM(@NAMA_ASSET)+'%'' ';
	END
IF(@MEREK <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND merek LIKE ''%'+RTRIM(@MEREK)+'%'' ';
	END
IF(@SUPPLIER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND supplier LIKE ''%'+RTRIM(@SUPPLIER)+'%'' ';
	END

IF(@DEPARTMENT <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dept_user LIKE ''%'+RTRIM(@DEPARTMENT)+'%'' ';
	END

IF(@ITEM_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND item_code LIKE ''%'+RTRIM(@ITEM_CODE)+'%'' ';
	END
	
IF(@STATUS_KONDISI <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND status LIKE ''%'+RTRIM(@STATUS_KONDISI)+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB
	LEFT JOIN ad_dis_ma_lokasi_asset
	ON TB.kd_lokasi = ad_dis_ma_lokasi_asset.kd_lokasi
	LEFT JOIN [ad_dis_ma_request_detail_asset] as req_asset
	ON TB.id_tb_m_req_asset = req_asset.id_tb_m_req_asset
';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)