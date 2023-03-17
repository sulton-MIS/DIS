DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_pc_price_list SET
			dmc_type = @DMC_TYPE,
			customer = @CUSTOMER,
			touch_panel_type = @TOUCH_PANEL_TYPE,			
			touch_panel_size = @TOUCH_PANEL_SIZE,
			versi_wis = @VERSI_WIS,			
			total_yield_film = @TOTAL_YIELD_FILM,
			jenis_transportation = @JENIS_TRANSPORTATION,
			lot_10 = @LOT_10,
			lot_20 = @LOT_20,
			lot_50 = @LOT_50,
			lot_100 = @LOT_100,
			lot_200 = @LOT_200,
			lot_300 = @LOT_300,
			lot_400 = @LOT_400,
			lot_500 = @LOT_500,
			lot_1000 = @LOT_1000,
			lot_5000 = @LOT_5000
	WHERE dmc_type = @DMC_TYPE and customer = @CUSTOMER and jenis_transportation = @JENIS_TRANSPORTATION

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_pc_price_list: ' + @DMC_TYPE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
