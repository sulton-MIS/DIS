DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY id_tb_m_denki ASC) ROW_NUM,
	id_tb_m_denki as ID, 
	*
	FROM ad_dis_dd_master_denki		
	WHERE 1=1	
';

IF(@NAMA_MESIN <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND nama_mesin LIKE ''%'+RTRIM(@NAMA_MESIN)+'%'' ';
	END


SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

