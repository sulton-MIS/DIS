DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;



SET @@QUERY = '';
SET @@QUERY = '
	SELECT 
		COUNT(jenis_asset) as QTY,
		--SUM(master_asset.harga_satuan) as AMOUNT
		SUBSTRING(format(SUM(master_asset.harga_satuan), ''C'',''id-ID''), 3, 100) as AMOUNT
	FROM 
		(
		SELECT ROW_NUMBER() OVER (ORDER BY dt_audit.created_date ASC) ROW_NUM,
		no_audit as ID, 
		*
		FROM [ad_dis_ma_audit_asset] as dt_audit
	WHERE 
		1=1	
';

SET @@QUERY = @@QUERY+ ') AS TB 
		LEFT JOIN [ad_dis_ma_master_asset] as master_asset ON TB.no_asset = master_asset.no_asset
		LEFT JOIN [ad_dis_ma_lokasi_asset] lokasi_asset ON master_asset.kd_lokasi = lokasi_asset.kd_lokasi
	WHERE 1=1';

IF(@JENIS_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND master_asset.jenis_asset LIKE ''%'+RTRIM(@JENIS_ASSET)+'%'' ';
	END

	IF(@NO_AUDIT <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.no_audit LIKE ''%'+RTRIM(@NO_AUDIT)+'%'' ';
	END

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
	END

IF(@JENIS_AUDIT <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.jenis_audit LIKE ''%'+RTRIM(@JENIS_AUDIT)+'%'' ';
	END
	
IF(@JENIS_AUDIT = 'BULANAN')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.periode_bulan LIKE ''%'+RTRIM(@PERIODE)+'%'' ';
	END ELSE
IF(@JENIS_AUDIT = 'SEMESTER')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.periode_semester LIKE ''%'+RTRIM(@PERIODE)+'%'' ';
	END

IF(@STATUS <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.status LIKE ''%'+RTRIM(@STATUS)+'%'' ';
	END
	
IF(@TAHUN <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.tahun LIKE ''%'+RTRIM(@TAHUN)+'%'' ';
	END

IF(@NAMA_USER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND master_asset.nama_user LIKE ''%'+RTRIM(@NAMA_USER)+'%'' ';
	END

IF(@DEPARTMENT_USER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND master_asset.dept_user LIKE ''%'+RTRIM(@DEPARTMENT_USER)+'%'' ';
	END

EXEC(@@QUERY);




