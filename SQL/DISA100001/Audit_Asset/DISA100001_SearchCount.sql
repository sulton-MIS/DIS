DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
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
		SET @@QUERY = @@QUERY + 'AND periode_bulan LIKE ''%'+RTRIM(@PERIODE)+'%'' ';
	END ELSE
IF(@JENIS_AUDIT = 'SEMESTER')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND periode_semester LIKE ''%'+RTRIM(@PERIODE)+'%'' ';
	END


IF(@STATUS <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND status LIKE ''%'+RTRIM(@STATUS)+'%'' ';
	END
	
IF(@TAHUN <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND tahun LIKE ''%'+RTRIM(@TAHUN)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

