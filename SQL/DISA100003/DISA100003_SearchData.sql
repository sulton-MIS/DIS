DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;



SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY id_konpo ASC) ROW_NUM,
	id_konpo as ID, 
	*
	FROM ad_dis_pc_master_list_konpo		
	WHERE 1=1	
';

IF(@ITEM_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND item_code LIKE ''%'+RTRIM(@ITEM_CODE)+'%'' ';
	END

IF(@JENIS_PACKING <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND jenis_packing LIKE ''%'+RTRIM(@JENIS_PACKING)+'%'' ';
	END

IF(@HARGA <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND harga LIKE ''%'+RTRIM(@HARGA)+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)