DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*,
	TB.ID, 
	TB.id_tb_m_audit,
	TB.status as status_kondisi,
	TB.keterangan as keterangan
	
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY dt_audit.created_date ASC) ROW_NUM,
	no_audit as ID, 
	*
	FROM [ad_dis_ma_audit_asset] as dt_audit
	WHERE 1=1	
';

IF(@NO_AUDIT <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_audit LIKE ''%'+RTRIM(@NO_AUDIT)+'%'' ';
	END

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
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
		SET @@QUERY = @@QUERY + 'AND tahun LIKE ''%'+RTRIM(@TAHUN)+'%'' ';
	END


SET @@QUERY = @@QUERY +') as TB
	LEFT JOIN [ad_dis_ma_master_asset] as master_asset ON TB.no_asset = master_asset.no_asset
	LEFT JOIN [ad_dis_ma_lokasi_asset] lokasi_asset ON master_asset.kd_lokasi = lokasi_asset.kd_lokasi
';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)