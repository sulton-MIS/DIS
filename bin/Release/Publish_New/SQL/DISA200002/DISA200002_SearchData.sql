﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY XHEAD.NAME, XZAIK.HOKAN ASC) ROW_NUM,
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

IF(@JENIS_MAT = 'ALL')
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
ELSE 
	BEGIN
		SET @@QUERY = @@QUERY + 'AND xhead.code = '''+RTRIM(@JENIS_MAT)+''' ';
	END

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
		SET @@QUERY = @@QUERY + 'AND mainbumo = '''+RTRIM(@MAINBUMO)+''' ';
	END
IF(@HOKAN <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND xzaik.hokan = '''+RTRIM(@HOKAN)+''' ';
	END
IF(@ZAIK = '')
	BEGIN
		SET @@QUERY = @@QUERY + '';
	END
ELSE IF(@ZAIK = '0')
		BEGIN
		SET @@QUERY = @@QUERY + 'AND xzaik.zaik = 0 ';
	END
ELSE IF(@ZAIK = '+')
		BEGIN
		SET @@QUERY = @@QUERY + 'AND xzaik.zaik > 0 ';
	END
ELSE IF(@ZAIK = '-')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND xzaik.zaik < 0 ';
	END

SET @@QUERY = @@QUERY +') as TB
';

------------OLD (under 23/03/2022)------------------------
--SET @@QUERY = '';
--SET @@QUERY = 'SELECT 
--	*
-- FROM 
--(
--	SELECT ROW_NUMBER() OVER (ORDER BY XHEAD.NAME, XZAIK.HOKAN ASC) ROW_NUM,
--	XHEAD.code as ID, 
--	XHEAD.code as CODE,
--	XHEAD.name as NAME,
--	XHEAD.mainbumo as MAINBUMO,
--	XHEAD.tani1 as UOM,
--	cast(XZAIK.ZAIK as float) as ZAIK,
--	XZAIK.HOKAN,
--	XHEAD.BIKOU as BIKOU
--	FROM [XHEAD] JOIN XZAIK ON XHEAD.code = XZAIK.code	
--	WHERE 1=1 
--';

--IF(@JENIS_MAT = 'ALL')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND name NOT LIKE ''(%DoN%'' AND name NOT LIKE ''(%DO NOT USE)%'' ';
--	END
--ELSE IF(@JENIS_MAT = '1')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND (xhead.code like ''1%'' or xhead.code like ''2%'') AND xhead.name NOT LIKE ''(%DoN%'' AND xhead.name NOT LIKE ''(%DO NOT USE)%'' ';
--	END
--ELSE IF(@JENIS_MAT = '2')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND xhead.code not like ''1%'' and xhead.code not like ''2%'' AND xhead.name NOT LIKE ''(%DoN%'' AND xhead.name NOT LIKE ''(%DO NOT USE)%'' ';
--	END
--ELSE 
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND xhead.code = '''+RTRIM(@JENIS_MAT)+''' ';
--	END

--IF(@CODE <> '')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND xhead.code LIKE ''%'+RTRIM(@CODE)+'%'' ';
--	END
--IF(@NAME <> '')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND name LIKE ''%'+RTRIM(@NAME)+'%'' ';
--	END
--IF(@MAINBUMO <> '')
--	BEGIN
--		--SET @@QUERY = @@QUERY + 'AND mainbumo LIKE ''%'+RTRIM(@MAINBUMO)+'%'' ';
--		SET @@QUERY = @@QUERY + 'AND mainbumo = '''+RTRIM(@MAINBUMO)+''' ';
--	END
--IF(@HOKAN <> '')
--	BEGIN
--		--SET @@QUERY = @@QUERY + 'AND mainbumo LIKE ''%'+RTRIM(@MAINBUMO)+'%'' ';
--		SET @@QUERY = @@QUERY + 'AND xzaik.hokan = '''+RTRIM(@HOKAN)+''' ';
--	END
--IF(@ZAIK <> '')
--	BEGIN
--		--SET @@QUERY = @@QUERY + 'AND mainbumo LIKE ''%'+RTRIM(@MAINBUMO)+'%'' ';
--		SET @@QUERY = @@QUERY + 'AND xzaik.zaik = '''+RTRIM(@ZAIK)+''' ';
--	END

--SET @@QUERY = @@QUERY +') as TB
--';



IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)