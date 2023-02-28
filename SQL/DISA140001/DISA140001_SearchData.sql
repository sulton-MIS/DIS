DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY create_date ASC) ROW_NUM,
	id_produksi as ID, 
	*
	FROM  [ad_dis_rt_label_gaikan]		
	WHERE 1=1 
';


IF(@ID_PRODUKSI <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND id_produksi LIKE ''%'+RTRIM(@ID_PRODUKSI)+'%'' ';
	END

IF(@TIPE <> '')
BEGIN
	SET @@QUERY = @@QUERY + 'AND tipe LIKE ''%'+RTRIM(@TIPE)+'%'' ';
END

IF(@NIK <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND nik LIKE ''%'+RTRIM(@NIK)+'%'' ';
	END

IF(@NAMA <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND nama LIKE ''%'+RTRIM(@NAMA)+'%'' ';
	END

IF(@SERIAL_NO <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND serial_no LIKE ''%'+RTRIM(@SERIAL_NO)+'%'' ';
	END

IF(@SHIFT <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND shift LIKE ''%'+RTRIM(@SHIFT)+'%'' ';
	END


SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)