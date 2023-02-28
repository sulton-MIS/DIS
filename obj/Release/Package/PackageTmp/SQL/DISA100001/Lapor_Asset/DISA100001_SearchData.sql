DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY dt_lapor.no_lapor ASC) ROW_NUM,
	--*,
		dt_lapor.id_tb_m_lapor as ID_TB_M_LAPOR, 
		dt_lapor.no_lapor as ID, 
		dt_lapor.no_lapor as no_lapor, 
		master_asset.id_pr,
		dt_lapor.no_asset,
		dt_lapor.status,
		dt_lapor.keterangan,
		dt_lapor.created_by as pic_lapor,
		dt_lapor.created_date as tgl_lapor,
		dt_lapor.nama_foto_laporan,
		dt_lapor.updated_by, 
		dt_lapor.updated_date, 
		dt_lapor.flg_approval_lapor as FLG_APPROVAL,
		dt_lapor.approval_by, 
		dt_lapor.approval_date, 
		dt_lapor.reject_by, 
		dt_lapor.reject_date,
		master_asset.nama_asset,
		master_asset.jenis_asset,
		master_asset.kategori_asset,
		master_asset.nama_user,
		master_asset.dept_user,
		--master_asset.harga_satuan,
		SUBSTRING(format(master_asset.harga_satuan, ''C'',''id-ID''), 3, 100) as harga_satuan,
		master_asset.cost_upgrade,
		master_asset.spesifikasi,
		lokasi_asset.id_tb_m_lokasi,
		lokasi_asset.kd_lokasi,
		lokasi_asset.nama_lokasi,
		lokasi_asset.area,
		dt_lapor_pindah.kd_lokasi_baru, 
		dt_lapor_pindah.sub_lokasi_baru, 
		dt_lapor_pindah.nama_user_baru, 
		dt_lapor_pindah.dept_user_baru, 
		dt_lapor_pindah.halte_baru, 
		dt_lapor_modifikasi.harga_baru, 
		dt_lapor_modifikasi.cost_upgrade_baru, 
		dt_lapor_modifikasi.spesifikasi_baru
	FROM 
		[ad_dis_ma_lapor_asset] as dt_lapor
	LEFT JOIN [ad_dis_ma_lokasi_asset] lokasi_asset ON dt_lapor.kd_lokasi = lokasi_asset.kd_lokasi
	LEFT JOIN [ad_dis_ma_master_asset] as master_asset ON dt_lapor.no_asset = master_asset.no_asset
	LEFT JOIN [ad_dis_ma_lapor_pindah_asset] as dt_lapor_pindah ON dt_lapor.no_lapor = dt_lapor_pindah.no_lapor
	LEFT JOIN [ad_dis_ma_lapor_modifikasi_asset] as dt_lapor_modifikasi ON dt_lapor.no_lapor = dt_lapor_modifikasi.no_lapor
	WHERE 1=1	
';

IF(@NO_LAPOR <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dt_lapor.no_lapor LIKE ''%'+RTRIM(@NO_LAPOR)+'%'' ';
	END

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dt_lapor.no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
	END

IF(@KONDISI_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dt_lapor.status LIKE ''%'+RTRIM(@KONDISI_ASSET)+'%'' ';
	END

IF(@NAMA_USER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND master_asset.nama_user LIKE ''%'+RTRIM(@NAMA_USER)+'%'' ';
	END

IF(@DEPARTMENT_USER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND master_asset.dept_user LIKE ''%'+RTRIM(@DEPARTMENT_USER)+'%'' ';
	END


SET @@QUERY = @@QUERY +') as TB';



IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)