DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY id_konpo ASC) ROW_NUM,
	id_konpo as ID, 
	*
	FROM  ad_dis_pc_master_list_konpo	
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

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

