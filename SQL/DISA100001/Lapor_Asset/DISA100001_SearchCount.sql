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

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

