DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;



SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY id_trans DESC) ROW_NUM,
	C.id_trans as ID,	
	C.part as PART,
	C.id_kotei as ID_KOTEI,
	M.name_kotei as NAME_KOTEI,
	c.factory as FACTORY,
	c.chinritsu as CHINRITSU
	FROM [ad_dis_pc_master_chinritsu] C		
	LEFT OUTER JOIN [192.168.0.3].[RTJN_PRD].[DBO].[Z_RT_master_kotei] M ON C.id_kotei = M.id_kotei
	WHERE 1=1	
';

IF(@PART <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND C.part LIKE ''%'+RTRIM(@PART)+'%'' ';
	END

IF(@ID_KOTEI <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND C.id_kotei LIKE ''%'+RTRIM(@ID_KOTEI)+'%'' ';
	END

IF(@NAME_KOTEI <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND M.name_kotei LIKE ''%'+RTRIM(@NAME_KOTEI)+'%'' ';
	END

IF(@FACTORY <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND factory LIKE ''%'+RTRIM(@FACTORY)+'%'' ';
	END

IF(@CHINRITSU <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND chinritsu LIKE ''%'+RTRIM(@CHINRITSU)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)