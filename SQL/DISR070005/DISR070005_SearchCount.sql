DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY time_koshin DESC) ROW_NUM,
	id_tool as ID, 
	*
	FROM  [Z_RT_master_tool]
	WHERE 1=1 
';

IF(@ID_TOOL <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND id_tool LIKE ''%'+RTRIM(@ID_TOOL)+'%'' ';
	END

IF(@NAME_TOOL <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND name_tool LIKE ''%'+RTRIM(@NAME_TOOL)+'%'' ';
	END

IF(@FACTORY <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND factory LIKE ''%'+RTRIM(@FACTORY)+'%'' ';
	END


SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

