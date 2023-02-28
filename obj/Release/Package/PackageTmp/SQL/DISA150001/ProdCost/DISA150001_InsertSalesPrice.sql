DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
	

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM [ad_dis_pc_sales_price] WHERE [dmc_type] = @DMC_CODE);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO [ad_dis_pc_sales_price]
		(
			 [dmc_type]
			,[air_jpn]
			,[sea_tokyo]
			,[air_sha]
			,[sea_sha]
			,[air_hkg]
			,[sea_hkg]
			,[total_direct_labour]
			,[indirect_labour]
			,[labour_sga]
			,[total_cost_air_jpn]
			,[total_cost_sea_tokyo]
			,[total_cost_air_sha]
			,[total_cost_sea_sha]
			,[total_cost_air_hkg]
			,[total_cost_sea_hkg]
			,[total_cost_fob]
			,[sea_jpn_sales_price]
			,[air_sha_sales_price]
			,[sea_sha_sales_price]
			,[air_hkg_sales_price]
			,[sea_hkg_sales_price]
			,[air_cif_sales_price]
			,[air_cif_material_cost]
			,[air_cif_labour_cost]
			,[air_cif_indirect]
			,[air_cif_sga]
			,[air_cif_transportation_cost]
			,[air_cif_grand_total]
			,[air_cif_marginal_profit_ratio]
			,[air_cif_profit_ratio]
			,[fob_sales_price]
			,[fob_material_cost]
			,[fob_labour_cost]
			,[fob_indirect]
			,[fob_sga]
			,[fob_transportation_cost]
			,[fob_grand_total]
			,[fob_marginal_profit_ratio]
			,[fob_profit_ratio]
			,[labour_cost_printing]
			,[labour_cost_assembly]
			,[labour_cost_etching]
			,[labour_cost_press]
			,[labour_cost_non_printing]
			,[labour_cost_kompo]
			,[material_cost_after_gaikan]
			,[labour_cost_printing_after_gaikan]
			,[labour_cost_assembly_after_gaikan]
			,[labour_cost_etching_after_gaikan]
			,[labour_cost_press_after_gaiakan]
			,[labour_cost_non_printing_after_gaikan]			
		)
		VALUES
		(
			@DMC_CODE,
			@AIR_JPN,
            @SEA_TOKYO,
            @AIR_SHA,
            @SEA_SHA,
            @AIR_HKG,
            @SEA_HKG,
			@TOTAL_DIRECT_LABOUR,
            @INDIRECT_LABOUR,
            @LABOUR_SGA,
            @TOTAL_COST_AIR_JPN,
            @TOTAL_COST_SEA_TOKYO,
            @TOTAL_COST_AIR_SHA,
            @TOTAL_COST_SEA_SHA,
            @TOTAL_COST_AIR_HKG,
            @TOTAL_COST_SEA_HKG,
            @TOTAL_COST_FOB,
			@SEA_JPN_SALES_PRICE,
            @AIR_SHA_SALES_PRICE,
            @SEA_SHA_SALES_PRICE,
            @AIR_HKG_SALES_PRICE,
            @SEA_HKG_SALES_PRICE,
            @AIR_CIF_SALES_PRICE,
            @AIR_CIF_MATERIAL_COST,
            @AIR_CIF_LABOUR_COST,
            @AIR_CIF_INDIRECT,
            @AIR_CIF_SGA,
            @AIR_CIF_TRANSPORTATION,
            @AIR_CIF_GRAND_TOTAL,
            @AIR_CIF_MARGINAL_PROFIT_RATIO,
            @AIR_CIF_PROFIT_RATIO,
			@FOB_SALES_PRICE,
            @FOB_MATERIAL_COST,
            @FOB_LABOUR_COST,
            @FOB_INDIRECT,
            @FOB_SGA,
            @FOB_TRANSPORTATION,
            @FOB_GRAND_TOTAL,
            @FOB_MARGINAL_PROFIT_RATIO,
            @FOB_PROFIT_RATIO,
			@LABOUR_COST_PRINTING,
            @LABOUR_COST_ASSEMBLY,
            @LABOUR_COST_ETCHING,
            @LABOUR_COST_PRESS,
            @LABOUR_COST_NON_PRINTING,
            @LABOUR_COST_KOMPO,
            @MATERIAL_COST_AFTER_GAIKAN,
            @LABOUR_COST_PRINTING_AFTER_GAIKAN,
            @LABOUR_COST_ASSEMBLY_AFTER_GAIKAN,
            @LABOUR_COST_ETCHING_AFTER_GAIKAN,
            @LABOUR_COST_PRESS_AFTER_GAIKAN,
            @LABOUR_COST_NON_PRINTING_AFTER_GAIKAN
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [ad_dis_pc_sales_price]:' + @DMC_CODE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
