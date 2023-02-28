DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY no_asset ASC) ROW_NUM,
	no_asset as ID, 
	*
	FROM  ad_dis_ma_master_asset	
	WHERE 1=1	
';

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
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

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

