
DECLARE @@QUERY VARCHAR(MAX);

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT 
		ROW_NUMBER() OVER (order by
	        case when jenis_transportation like ''air_cif_sales_price'' then 1
	        when jenis_transportation like ''sea_jpn_sales_price'' then 2
	        when jenis_transportation like ''fob_sales_price'' then 3 end
        asc
            ) ROW_NUM	
		,DMC_TYPE as ID
        ,[dmc_type]
        ,[customer]
        ,[touch_panel_type]
        ,[touch_panel_size]
        ,[versi_wis]
        ,[total_yield_film]
        ,[jenis_transportation]
        ,[lot_10]
        ,[lot_20]
        ,[lot_50]
        ,[lot_100]
        ,[lot_200]
        ,[lot_300]
        ,[lot_400]
        ,[lot_500]
        ,[lot_1000]
        ,[lot_5000]
    FROM [ad_dis_pc_price_list]
	WHERE 1=1	
';

IF(@DMC_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND DMC_TYPE LIKE ''%'+RTRIM(@DMC_CODE)+'%'' ';
	END



SET @@QUERY = @@QUERY +') as TB';


EXEC(@@QUERY)



