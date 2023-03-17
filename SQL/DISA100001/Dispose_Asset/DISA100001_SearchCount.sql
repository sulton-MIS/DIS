DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY no_dispose ASC) ROW_NUM,
	no_dispose as ID, 
	*
	FROM [ad_dis_ma_dispose_asset]		
	WHERE 1=1	
';

IF(@NO_DISPOSE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_dispose LIKE ''%'+RTRIM(@NO_DISPOSE)+'%'' ';
	END

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

