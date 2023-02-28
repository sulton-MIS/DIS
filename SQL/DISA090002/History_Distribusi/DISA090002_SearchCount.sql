DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY id_tb_history_distribusi DESC) ROW_NUM,
	id_tb_history_distribusi as ID, 
	*
	FROM ad_dis_dd_history_distribusi		
	WHERE 1=1	
';

IF(@NAMA_MESIN <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND nama_mesin LIKE ''%' + RTRIM(@NAMA_MESIN) + '%'' ';
END;
IF(@STATUS <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND status LIKE ''%' + RTRIM(@STATUS) + '%'' ';
END;
IF(@CREATED_BY <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND created_by LIKE ''%' + RTRIM(@CREATED_BY) + '%'' ';
END;
IF(@CREATED_DATE_FROM <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND created_date >= ''' + RTRIM(@CREATED_DATE_FROM) + ' 00:00:00'' ';
END;

IF(@CREATED_DATE_TO <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND created_date < ''' + RTRIM(@CREATED_DATE_TO) + ' 23:59:59'' ';
END;

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

