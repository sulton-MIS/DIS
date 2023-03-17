DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY i_user ASC) ROW_NUM,
	i_user as ID, 
	*
	FROM  Y_TRUSER	
	WHERE 1=1	
';

IF(@i_user<> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND i_user LIKE ''%'+RTRIM(@i_user)+'%'' ';
	END

IF(@dept<> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dept LIKE ''%'+RTRIM(@dept)+'%'' ';
	END

IF(@e_mail <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND e_mail LIKE ''%'+RTRIM(@e_mail)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

