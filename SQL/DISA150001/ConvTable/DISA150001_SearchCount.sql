DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY ItemCode ASC) ROW_NUM,
	ItemCode as ID, 
	*
	FROM  Y_ConvertionTablePacking	
	WHERE 1=1	
';

IF(@ItemCode <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND ItemCode LIKE ''%'+RTRIM(@ItemCode)+'%'' ';
	END

IF(@Parts <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND Parts LIKE ''%'+RTRIM(@Parts)+'%'' ';
	END

IF(@type <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND Type LIKE ''%'+RTRIM(@type)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

