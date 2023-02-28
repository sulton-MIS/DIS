DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY id_kotei ASC) ROW_NUM,
	id_kotei as ID, 
	*
	FROM Z_RT_master_kotei
	WHERE 1=1	
';

IF(@id_kotei <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND id_kotei LIKE ''%'+RTRIM(@id_kotei)+'%'' ';
	END
IF(@name_kotei <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND name_kotei LIKE ''%'+RTRIM(@name_kotei)+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB
		JOIN Z_RT_master_koteishubetsu
		ON TB.id_koteishubetsu= Z_RT_master_koteishubetsu.id_koteishubetsu
';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)