DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_pc_master_chokoritsu SET
			dmc_type = @DMC_TYPE,
			yield_printing_film = @YIELD_PRINTING_FILM,
            yield_printing_glass = @YIELD_PRINTING_GLASS,
            yield_printing_tail = @YIELD_PRINTING_TAIL,
			yield_printing_overlay = @YIELD_PRINTING_OVERLAY,
			yield_scribe = @YIELD_SCRIBE,
            yield_film_midle_inspection = @YIELD_FILM_MIDLE_INSPECTION,
			yield_film_kabu_midle_inspection = @YIELD_FILM_KABU_MIDLE_INSPECTION,
            yield_glass_midle_inspection = @YIELD_GLASS_MIDLE_INSPECTION,
			yield_overlay_midle_inspection = @YIELD_OVERLAY_MIDLE_INSPECTION,
            yield_tail_electrical = @YIELD_TAIL_ELECTRICAL,
            yield_tail_cosmetic = @YIELD_TAIL_COSMETIC,
            yield_assembly = @YIELD_ASSEMBLY,
            yield_final_assembly = @YIELD_FINAL_ASSEMBLY,
            yield_electrical_inspection = @YIELD_ELECTRICAL_INSPECTION,
            yield_final_inspection = @YIELD_FINAL_INSPECTION,	
			yield_denki_film = @YIELD_DENKI_FILM,
			yield_denki_glass = @YIELD_DENKI_GLASS
	WHERE dmc_type = @DMC_TYPE

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_pc_master_chokoritsu: ' + @DMC_TYPE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
