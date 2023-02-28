DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY no_audit ASC) ROW_NUM,
		dt_audit.no_audit as ID, 
		dt_audit.no_audit as no_audit, 
		dt_audit.no_asset, 
		dt_audit.id_tb_m_audit,
		dt_audit.status as status_kondisi,
		dt_audit.keterangan as keterangan,
		dt_audit.jenis_audit as jenis_audit,
		dt_audit.periode_bulan,
		dt_audit.periode_semester,
		dt_audit.tahun as tahun,
		dt_audit.nama_foto_audit,
		dt_audit.created_by,
		dt_audit.created_date,
		dt_audit.updated_by,
		dt_audit.updated_date,
		master_asset.id_pr,
		master_asset.nama_asset,
		master_asset.jenis_asset,
		master_asset.kategori_asset,
		master_asset.nama_user,
		master_asset.dept_user,
		master_asset.harga_satuan,
		master_asset.cost_upgrade,
		master_asset.spesifikasi,
		lokasi_asset.id_tb_m_lokasi,
		lokasi_asset.kd_lokasi,
		lokasi_asset.nama_lokasi,
		lokasi_asset.area
	FROM [ad_dis_ma_audit_asset] as dt_audit
	LEFT JOIN [ad_dis_ma_master_asset] as master_asset ON dt_audit.no_asset = master_asset.no_asset
	LEFT JOIN [ad_dis_ma_lokasi_asset] lokasi_asset ON master_asset.kd_lokasi = lokasi_asset.kd_lokasi
	WHERE 1=1	
';

IF(@NO_AUDIT <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_audit LIKE ''%'+RTRIM(@NO_AUDIT)+'%'' ';
	END

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dt_audit.no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
	END

IF(@JENIS_AUDIT <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND jenis_audit LIKE ''%'+RTRIM(@JENIS_AUDIT)+'%'' ';
	END

IF(@JENIS_AUDIT = 'BULANAN')
	BEGIN
		IF (@PERIODE <> '')
		BEGIN
			SET @@QUERY = @@QUERY + 'AND periode_bulan LIKE ''%'+RTRIM(@PERIODE)+'%'' ';
		END
	END ELSE
IF(@JENIS_AUDIT = 'SEMESTER')
	BEGIN
		IF (@PERIODE <> '')
		BEGIN
			SET @@QUERY = @@QUERY + 'AND periode_semester LIKE ''%'+RTRIM(@PERIODE)+'%'' ';
		END
	END
	
IF(@STATUS <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND status LIKE ''%'+RTRIM(@STATUS)+'%'' ';
	END

IF(@TAHUN <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dt_audit.tahun LIKE ''%'+RTRIM(@TAHUN)+'%'' ';
	END
	
IF(@KETERANGAN <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND keterangan LIKE ''%'+RTRIM(@KETERANGAN)+'%'' ';
	END
	
IF(@NAMA_USER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND master_asset.nama_user LIKE ''%'+RTRIM(@NAMA_USER)+'%'' ';
	END

IF(@DEPARTMENT_USER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND master_asset.dept_user LIKE ''%'+RTRIM(@DEPARTMENT_USER)+'%'' ';
	END




SET @@QUERY = @@QUERY+ ') AS TB ';


EXEC(@@QUERY);

