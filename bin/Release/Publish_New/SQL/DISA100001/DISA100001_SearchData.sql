DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY no_asset ASC) ROW_NUM,
	no_asset as ID, 
	*
	FROM ad_dis_ma_master_asset		
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

SET @@QUERY = @@QUERY +') as TB
	JOIN ad_dis_ma_lokasi_asset
	ON TB.kd_lokasi = ad_dis_ma_lokasi_asset.kd_lokasi
';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)