DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50)= @START;
DECLARE @@DISPLAY VARCHAR(50)= @DISPLAY;
SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY id_tb_m_denki ASC) ROW_NUM,
	id_tb_m_denki as ID, 
	*
	FROM ad_dis_dd_master_denki		
	WHERE 1=1	
';
IF(@NAMA_MESIN <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND nama_mesin LIKE ''%' + RTRIM(@NAMA_MESIN) + '%'' ';
END;
SET @@QUERY = @@QUERY + ') as TB';
IF(@@START > 0
   AND @@DISPLAY > 0)
    BEGIN
        SET @@QUERY = @@QUERY + ' WHERE ROW_NUM BETWEEN ' + @@START + ' AND ''' + @@DISPLAY + ''' ';
END;
EXEC (@@QUERY);