DECLARE @@QUERY VARCHAR(MAX);

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY XHEAD.CODE ASC) ROW_NUM,
	XHEAD.code as ID, 
	XHEAD.code as CODE,
	XHEAD.name as NAME,
	XHEAD.mainbumo as MAINBUMO,
	XHEAD.tani1 as UOM,
	cast(XZAIK.ZAIK as float) as ZAIK,
	XZAIK.HOKAN,
	XHEAD.BIKOU as BIKOU
	FROM [XHEAD] JOIN XZAIK ON XHEAD.code = XZAIK.code	
	WHERE 1=1 
';

IF(@JENIS_MAT = '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND name NOT LIKE ''(%DoN%'' AND name NOT LIKE ''(%DO NOT USE)%'' ';
	END
ELSE IF(@JENIS_MAT = '1')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND (xhead.code like ''1%'' or xhead.code like ''2%'') AND xhead.name NOT LIKE ''(%DoN%'' AND xhead.name NOT LIKE ''(%DO NOT USE)%'' ';
	END
ELSE IF(@JENIS_MAT = '2')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND xhead.code not like ''1%'' and xhead.code not like ''2%'' AND xhead.name NOT LIKE ''(%DoN%'' AND xhead.name NOT LIKE ''(%DO NOT USE)%'' ';
	END
--ELSE 
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND xhead.code = '''+RTRIM(@JENIS_MAT)+''' ';
--	END

IF(@CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND xhead.code LIKE ''%'+RTRIM(@CODE)+'%'' ';
	END
IF(@NAME <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND name LIKE ''%'+RTRIM(@NAME)+'%'' ';
	END
IF(@MAINBUMO <> '')
	BEGIN
		--SET @@QUERY = @@QUERY + 'AND mainbumo LIKE ''%'+RTRIM(@MAINBUMO)+'%'' ';
		SET @@QUERY = @@QUERY + 'AND mainbumo = '''+RTRIM(@MAINBUMO)+''' ';
	END

SET @@QUERY = @@QUERY +') as TB
';

EXEC(@@QUERY)