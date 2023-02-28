DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
	

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_pc_production_cost_material WHERE dmc_code = @DMC_CODE and dmc_code_parts = @DMC_CODE_PARTS and material_kode = @MATERIAL_KODE);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_pc_production_cost_material
		(
			 [dmc_code]
			,[part]
			,[dmc_code_parts]
			,[material_kode]
			,[material_name]
			,[unit_price]
			,[unit]
			,[wide_size]
			,[long_size]
			,[material_size]
			,[cut_size]
			,[cavity]
			,[qty]
			,[price_per_sheet]
			,[price_per_pcs]
		)
		VALUES
		(
			@DMC_CODE,
			@PART,
			@DMC_CODE_PARTS,
			@MATERIAL_KODE,
			@MATERIAL_NAME,
			@UNIT_PRICE,
			@UNIT,
			@WIDE_SIZE,
			@LONG_SIZE,
			@MATERIAL_SIZE,
			@CUT_SIZE,
			@CAVITY,
			@QTY,
			@PRICE_PER_SHEET,
			@PRICE_PER_PCS
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_pc_production_cost:' + @DMC_CODE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
