DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_pc_price_list_temp SET
			dmc_type = @DMC_TYPE,
			customer = @CUSTOMER,
			touch_panel_type = @TOUCH_PANEL_TYPE,			
			touch_panel_size = @TOUCH_PANEL_SIZE,
			versi_wis = @VERSI_WIS,			
			total_yield_film = @TOTAL_YIELD_FILM,
			lot_size = @ORIGINAL_LOT_SIZE,
			air_cif_sales_price = @AIR_CIF_SALES_PRICE,
            sea_jpn_sales_price = @SEA_JPN_SALES_PRICE,
            fob_sales_price = @FOB_SALES_PRICE
	WHERE dmc_type = @DMC_TYPE and lot_size = @ORIGINAL_LOT_SIZE

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_pc_price_list: ' + @DMC_TYPE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
