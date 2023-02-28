DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;



SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY id_trans DESC) ROW_NUM,
	id_trans as ID, 
	*
	FROM ad_dis_pc_master_transportation		
	WHERE 1=1	
';

IF(@ITEM_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND item_code LIKE ''%'+RTRIM(@ITEM_CODE)+'%'' ';
	END

IF(@JENIS_TRANSPORTATION <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND jenis_transportation LIKE ''%'+RTRIM(@JENIS_TRANSPORTATION)+'%'' ';
	END

IF(@TRANSPORTATION_COST <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND transportation_cost LIKE ''%'+RTRIM(@TRANSPORTATION_COST)+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' order by id_trans DESC';
END

EXEC(@@QUERY)