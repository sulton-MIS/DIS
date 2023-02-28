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
			cavity_tail = @CAVITY_TAIL,
			yield_printing_film = @YIELD_PRINTING_FILM,
            yield_printing_glass = @YIELD_PRINTING_GLASS,
            yield_printing_tail = @YIELD_PRINTING_TAIL,
            yield_film_midle_inspection = @YIELD_FILM_MIDLE_INSPECTION,
            yield_glass_midle_inspection = @YIELD_GLASS_MIDLE_INSPECTION,
            yield_tail_electrical = @YIELD_TAIL_ELECTRICAL,
            yield_tail_cosmetic = @YIELD_TAIL_COSMETIC,
            yield_assembly = @YIELD_ASSEMBLY,
            yield_final_assembly = @YIELD_FINAL_ASSEMBLY,
            yield_electrical_inspection = @YIELD_ELECTRICAL_INSPECTION,
            yield_final_inspection = @YIELD_FINAL_INSPECTION,
			yield_total_film = @YIELD_TOTAL_FILM,
			yield_total_glass = @YIELD_TOTAL_GLASS,
			yield_total_tail = @YIELD_TOTAL_TAIL,
			lot_size_film = @LOT_SIZE_FILM,
            max_lot_size_film = @MAX_LOT_SIZE_FILM,
            lot_size_glass = @LOT_SIZE_GLASS,
            max_lot_size_glass = @MAX_LOT_SIZE_GLASS,
            lot_size_tail = @LOT_SIZE_TAIL,
            max_lot_size_tail = @MAX_LOT_SIZE_TAIL,
			labour_charge_printing = @LABOUR_CHARGE_PRINTING,
            labour_charge_assembly = @LABOUR_CHARGE_ASSEMBLY,
            labour_charge_etching = @LABOUR_CHARGE_ETCHING,
            labour_charge_press = @LABOUR_CHARGE_PRESS,
            labour_charge_non_printing = @LABOUR_CHARGE_NON_PRINTING,
            labour_charge_kompo = @LABOUR_CHARGE_KOMPO

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
