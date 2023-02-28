DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY item_code DESC) ROW_NUM,
	C.item_code as ID,	
	C.item_code as ITEM_CODE,
	M.name as NAME_ITEM,	
	c.unit_price as UNIT_PRICE
	FROM [ad_dis_pc_master_unit_price] C		
	LEFT OUTER JOIN [192.168.0.4].[TxDTIPRD].[DBO].[XHEAD] M ON C.item_code = M.code
	WHERE 1=1	
';

IF(@ITEM_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND C.item_code LIKE ''%'+RTRIM(@ITEM_CODE)+'%'' ';
	END

IF(@NAME_ITEM <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND M.name LIKE ''%'+RTRIM(@NAME_ITEM)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

