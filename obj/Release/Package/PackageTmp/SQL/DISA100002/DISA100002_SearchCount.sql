DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY kd_lokasi ASC) ROW_NUM,
	kd_lokasi as ID, 
	*
	FROM  ad_dis_ma_lokasi_asset	
	WHERE 1=1	
';

IF(@KD_LOKASI <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND kd_lokasi LIKE ''%'+RTRIM(@KD_LOKASI)+'%'' ';
	END
IF(@NAMA_LOKASI <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND nama_lokasi LIKE ''%'+RTRIM(@NAMA_LOKASI)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

