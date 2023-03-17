DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY dmc_type ASC) ROW_NUM,
	dmc_type as ID, 
	*
	FROM  ad_dis_pc_master_chokoritsu	
	WHERE 1=1	
';

IF(@DMC_TYPE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dmc_type LIKE ''%'+RTRIM(@DMC_TYPE)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

