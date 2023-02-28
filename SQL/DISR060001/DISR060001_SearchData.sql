DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY i_user ASC) ROW_NUM,
	i_user as ID, 
	*
	FROM Y_TRUSER		
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

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)