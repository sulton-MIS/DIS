DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY no_lapor ASC) ROW_NUM,
	no_lapor as ID, 
	*
	FROM [ad_dis_ma_lapor_asset]		
	WHERE 1=1	
';

SET @@QUERY = @@QUERY+ ') AS TB
	LEFT JOIN [ad_dis_ma_lokasi_asset] lokasi_asset ON TB.kd_lokasi = lokasi_asset.kd_lokasi
	LEFT JOIN [ad_dis_ma_master_asset] as master_asset ON TB.no_asset = master_asset.no_asset
	LEFT JOIN [ad_dis_ma_lapor_pindah_asset] as dt_lapor_pindah ON TB.no_lapor = dt_lapor_pindah.no_lapor
	LEFT JOIN [ad_dis_ma_lapor_modifikasi_asset] as dt_lapor_modifikasi ON TB.no_lapor = dt_lapor_modifikasi.no_lapor
	WHERE 1=1';

IF(@NO_LAPOR <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.no_lapor LIKE ''%'+RTRIM(@NO_LAPOR)+'%'' ';
	END

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
	END

IF(@KONDISI_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND TB.status LIKE ''%'+RTRIM(@KONDISI_ASSET)+'%'' ';
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

