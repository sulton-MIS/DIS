DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY id_kikai ASC) ROW_NUM,
	id_kikai as ID, 
	*
	FROM  Z_RT_master_kikai	
	WHERE 1=1	
';

IF(@id_kikai <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND id_kikai LIKE ''%'+RTRIM(@id_kikai)+'%'' ';
	END
IF(@name_kikai <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND name_kikai LIKE ''%'+RTRIM(@name_kikai)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

