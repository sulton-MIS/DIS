DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	--*,
	ROW_NUM,
	TB.ID,
	TB.id_tb_m_lapor,
	TB.NO_LAPOR,
	TB.NO_ASSET,
	TB.status,
	TB.keterangan,
	TB.nama_foto_laporan,
	TB.kd_lokasi,
	lokasi_asset.nama_lokasi,
	master_asset.halte,
	TB.created_by as PIC_LAPOR,
	TB.created_date as TGL_LAPOR,
	master_asset.nama_user,
	master_asset.dept_user,
	TB.flg_approval_lapor as FLG_APPROVAL,
	TB.approval_by,
	TB.approval_date,
	TB.reject_by,
	TB.reject_date,
	dt_lapor_modifikasi.harga_baru,
	dt_lapor_modifikasi.cost_upgrade_baru,
	dt_lapor_modifikasi.spesifikasi_baru,
	dt_lapor_pindah.kd_lokasi_baru,
	dt_lapor_pindah.sub_lokasi_baru,
	dt_lapor_pindah.nama_user_baru,
	dt_lapor_pindah.dept_user_baru,
	dt_lapor_pindah.halte_baru
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY no_lapor ASC) ROW_NUM,
	no_lapor as ID, 
	*
	FROM [ad_dis_ma_lapor_asset]		
	WHERE 1=1	
';

IF(@NO_LAPOR <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_lapor LIKE ''%'+RTRIM(@NO_LAPOR)+'%'' ';
	END

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
	END

IF(@KONDISI_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND status LIKE ''%'+RTRIM(@KONDISI_ASSET)+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB
	LEFT JOIN [ad_dis_ma_lokasi_asset] lokasi_asset ON TB.kd_lokasi = lokasi_asset.kd_lokasi
	LEFT JOIN [ad_dis_ma_master_asset] as master_asset ON TB.no_asset = master_asset.no_asset
	LEFT JOIN [ad_dis_ma_lapor_pindah_asset] as dt_lapor_pindah ON TB.no_lapor = dt_lapor_pindah.no_lapor
	LEFT JOIN [ad_dis_ma_lapor_modifikasi_asset] as dt_lapor_modifikasi ON TB.no_lapor = dt_lapor_modifikasi.no_lapor
';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)