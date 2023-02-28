DECLARE @@QUERY VARCHAR(MAX);

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT
		dmc_type as DMC_TYPE
	FROM ad_dis_pc_master_type_cust		
	WHERE 1=1	
';

IF(@DMC_TYPE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dmc_type LIKE ''%'+RTRIM(@DMC_TYPE)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';

EXEC(@@QUERY)