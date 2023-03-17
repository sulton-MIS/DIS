DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;



SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY ItemCode ASC) ROW_NUM,
	ItemCode as ID, 
	*
	FROM Y_ConvertionTablePacking		
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

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)