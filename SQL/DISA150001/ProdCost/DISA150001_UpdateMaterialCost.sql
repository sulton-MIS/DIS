DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_pc_production_cost_material SET
			dmc_code = @DMC_CODE,
			part = @PART,
			dmc_code_parts = @DMC_CODE_PARTS,
			material_kode = @MATERIAL_KODE,
			material_name = @MATERIAL_NAME,
			unit_price = @UNIT_PRICE,
			unit = @UNIT,
			wide_size = @WIDE_SIZE,
			long_size = @LONG_SIZE,
			material_size = @MATERIAL_SIZE,
			cut_size = @CUT_SIZE,
			cavity = @CAVITY,
			qty = @QTY,
			price_per_sheet = @PRICE_PER_SHEET,
			price_per_pcs = @PRICE_PER_PCS
	WHERE dmc_code = @DMC_CODE and dmc_code_parts = @DMC_CODE_PARTS and material_kode = @MATERIAL_KODE 

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_pc_production_cost_material: ' + @DMC_CODE + 
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
