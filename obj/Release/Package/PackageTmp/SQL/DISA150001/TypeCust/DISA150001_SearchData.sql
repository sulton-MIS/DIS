﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;



SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY dmc_type ASC) ROW_NUM,
	dmc_type as ID, 
	*
	FROM ad_dis_pc_master_type_cust		
	WHERE 1=1	
';

IF(@Dmc_Type <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dmc_type LIKE ''%'+RTRIM(@Dmc_Type)+'%'' ';
	END

IF(@Customer <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND customer LIKE ''%'+RTRIM(@Customer)+'%'' ';
	END

IF(@Lot_Size <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND lot_size LIKE ''%'+RTRIM(@Lot_Size)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)