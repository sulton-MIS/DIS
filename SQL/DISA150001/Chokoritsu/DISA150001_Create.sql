DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_pc_master_chokoritsu WHERE dmc_type = @DMC_TYPE);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_pc_master_chokoritsu
		(			 
			[dmc_type]
            ,[yield_printing_film]
            ,[yield_printing_glass]
            ,[yield_printing_tail]
            ,[yield_printing_overlay]
            ,[yield_scribe]
            ,[yield_film_midle_inspection]
            ,[yield_film_kabu_midle_inspection]
            ,[yield_glass_midle_inspection]
            ,[yield_overlay_midle_inspection]
            ,[yield_tail_electrical]
            ,[yield_tail_cosmetic]
            ,[yield_assembly]
            ,[yield_final_assembly]
            ,[yield_electrical_inspection]
            ,[yield_final_inspection]
            ,[yield_denki_film]
            ,[yield_denki_glass]
			
		)
		VALUES
		(
			@DMC_TYPE,
            @YIELD_PRINTING_FILM,
            @YIELD_PRINTING_GLASS,
            @YIELD_PRINTING_TAIL,
            @YIELD_PRINTING_OVERLAY,
            @YIELD_SCRIBE,
            @YIELD_FILM_MIDLE_INSPECTION,
            @YIELD_FILM_KABU_MIDLE_INSPECTION,
            @YIELD_GLASS_MIDLE_INSPECTION,
            @YIELD_OVERLAY_MIDLE_INSPECTION,
            @YIELD_TAIL_ELECTRICAL,
            @YIELD_TAIL_COSMETIC,
            @YIELD_ASSEMBLY,
            @YIELD_FINAL_ASSEMBLY,
            @YIELD_ELECTRICAL_INSPECTION,
            @YIELD_FINAL_INSPECTION,
            @YIELD_DENKI_FILM,
            @YIELD_DENKI_GLASS
			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_pc_master_chokoritsu:' +@DMC_TYPE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
