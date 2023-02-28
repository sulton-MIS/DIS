DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
	


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_pc_price_list_temp WHERE dmc_type = @DMC_TYPE and customer = @CUSTOMER and lot_size = @ORIGINAL_LOT_SIZE);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_pc_price_list_temp
		(
			 [dmc_type]
			  ,[customer]			  
			  ,[touch_panel_type]
			  ,[touch_panel_size]
			  ,[versi_wis]
			  ,[total_yield_film]
			  ,[lot_size]			  
			  ,[air_cif_sales_price]
			  ,[sea_jpn_sales_price]
			  ,[fob_sales_price]
		)
		VALUES
		(
			@DMC_TYPE,
			@CUSTOMER,			
			@TOUCH_PANEL_TYPE,		
			@TOUCH_PANEL_SIZE,
			@VERSI_WIS,			
            @TOTAL_YIELD_FILM,
			@ORIGINAL_LOT_SIZE,
			@AIR_CIF_SALES_PRICE,
            @SEA_JPN_SALES_PRICE,
            @FOB_SALES_PRICE
			

		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_pc_price_list:' + @DMC_TYPE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
