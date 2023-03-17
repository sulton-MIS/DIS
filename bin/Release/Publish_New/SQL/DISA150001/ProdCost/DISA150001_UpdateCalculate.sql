DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_pc_production_cost SET
			dmc_type = @DMC_TYPE,
			customer = @CUSTOMER,
			touch_panel_type = @TOUCH_PANEL_TYPE,
			rank = @RANK,
			touch_panel_dimension = @TOUCH_PANEL_DIMENSION,
			touch_panel_size = @TOUCH_PANEL_SIZE,
			versi_wis = @VERSI_WIS,
			lot_size = @LOT_SIZE,
			indirect = @INDIRECT,
			sga = @SGA,
			cavity_film = @CAVITY_FILM,
			cavity_glass = @CAVITY_GLASS,
			cavity_tail = @CAVITY_TAIL			

	WHERE dmc_type = @DMC_TYPE

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_pc_production_cost: ' + @DMC_TYPE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
