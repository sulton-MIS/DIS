﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY id_ng ASC) ROW_NUM,
	id_ng as ID, 
	*
	FROM  Z_RT_master_NG	
	WHERE 1=1	
';

IF(@ID_NG <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND id_ng LIKE ''%'+RTRIM(@ID_NG)+'%'' ';
	END
IF(@NAME_NG <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND name_ng LIKE ''%'+RTRIM(@NAME_NG)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

