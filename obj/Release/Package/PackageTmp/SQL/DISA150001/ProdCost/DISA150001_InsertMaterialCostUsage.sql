DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
	

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_pc_production_cost_material_usage WHERE dmc_code = @DMC_CODE and dmc_code_parts = @DMC_CODE_PARTS and kode_proses = @KODE_PROSES);	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_pc_production_cost_material_usage
		(	
			[dmc_code]
			,[part]
			,[dmc_code_parts]
			,[kode_proses]
			,[nama_proses]
			,[setting_time]
			,[cycle_time]
			,[lot_size]
			,[total_time]
			,[prod_yield]
			,[chinritsu]
			,[cavity]
			,[urutan_proses]
			,[price_per_sheet]
			,[price_per_pcs]
		)
		VALUES
		(		
			@DMC_CODE,
			@PART,
			@DMC_CODE_PARTS,
			@KODE_PROSES,
			@NAMA_PROSES,
			@SETTING_TIME,
			@CYCLE_TIME,
			@LOT_SIZE,
			@TOTAL_TIME,
			@PROD_YIELD,
			@CHINRITSU,
			@CAVITY,
			@URUTAN_PROSES,
			@PRICE_PER_SHEET,
			@PRICE_PER_PCS
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_pc_production_cost_usage:' + @DMC_CODE_PARTS +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
