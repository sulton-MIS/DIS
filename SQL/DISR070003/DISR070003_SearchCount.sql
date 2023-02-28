DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY id_kotei ASC) ROW_NUM,
	id_kotei as ID, 
	*
	FROM  Z_RT_master_kotei	
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

SET @@QUERY = @@QUERY+ ') AS TB
		JOIN Z_RT_master_koteishubetsu
		ON TB.id_koteishubetsu= Z_RT_master_koteishubetsu.id_koteishubetsu
';


EXEC(@@QUERY);

