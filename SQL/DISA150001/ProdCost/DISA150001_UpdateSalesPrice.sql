DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
	

BEGIN TRY
	UPDATE [ad_dis_pc_sales_price] SET
			dmc_type = @DMC_CODE,
            air_jpn = @AIR_JPN,
            sea_tokyo = @SEA_TOKYO,
            air_sha = @AIR_SHA,
            sea_sha = @SEA_SHA,            
            air_hkg = @AIR_HKG,
            sea_hkg = @SEA_HKG,
            total_direct_labour = @TOTAL_DIRECT_LABOUR,
            indirect_labour = @INDIRECT_LABOUR,
            labour_sga = @LABOUR_SGA,
            total_cost_air_jpn = @TOTAL_COST_AIR_JPN,
            total_cost_sea_tokyo = @TOTAL_COST_SEA_TOKYO,
            total_cost_air_sha = @TOTAL_COST_AIR_SHA,
            total_cost_sea_sha = @TOTAL_COST_SEA_SHA,
            total_cost_air_hkg = @TOTAL_COST_AIR_HKG,
            total_cost_sea_hkg = @TOTAL_COST_SEA_HKG,
            total_cost_fob = @TOTAL_COST_FOB,
            sea_jpn_sales_price = @SEA_JPN_SALES_PRICE,
            air_sha_sales_price = @AIR_SHA_SALES_PRICE,
            sea_sha_sales_price = @SEA_SHA_SALES_PRICE,
            air_hkg_sales_price = @AIR_HKG_SALES_PRICE,
            sea_hkg_sales_price = @SEA_HKG_SALES_PRICE,
            air_cif_sales_price = @AIR_CIF_SALES_PRICE,
            air_cif_material_cost = @AIR_CIF_MATERIAL_COST,
            air_cif_labour_cost = @AIR_CIF_LABOUR_COST,
            air_cif_indirect = @AIR_CIF_INDIRECT,
            air_cif_sga = @AIR_CIF_SGA,
            air_cif_transportation_cost = @AIR_CIF_TRANSPORTATION,
            air_cif_grand_total = @AIR_CIF_GRAND_TOTAL,
            air_cif_marginal_profit_ratio = @AIR_CIF_MARGINAL_PROFIT_RATIO,
            air_cif_profit_ratio = @AIR_CIF_PROFIT_RATIO,
			fob_sales_price = @FOB_SALES_PRICE,
            fob_material_cost = @FOB_MATERIAL_COST,
            fob_labour_cost = @FOB_LABOUR_COST,
            fob_indirect = @FOB_INDIRECT,
            fob_sga = @FOB_SGA,
            fob_transportation_cost = @FOB_TRANSPORTATION,
            fob_grand_total = @FOB_GRAND_TOTAL,
            fob_marginal_profit_ratio = @FOB_MARGINAL_PROFIT_RATIO,
            fob_profit_ratio = @FOB_PROFIT_RATIO,
            labour_cost_printing = @LABOUR_COST_PRINTING,
            labour_cost_assembly = @LABOUR_COST_ASSEMBLY,
            labour_cost_etching = @LABOUR_COST_ETCHING,
            labour_cost_press = @LABOUR_COST_PRESS,
            labour_cost_non_printing = @LABOUR_COST_NON_PRINTING,
            labour_cost_kompo = @LABOUR_COST_KOMPO,
            material_cost_after_gaikan = @MATERIAL_COST_AFTER_GAIKAN,
            labour_cost_printing_after_gaikan = @LABOUR_COST_PRINTING_AFTER_GAIKAN,
            labour_cost_assembly_after_gaikan = @LABOUR_COST_ASSEMBLY_AFTER_GAIKAN,
            labour_cost_etching_after_gaikan = @LABOUR_COST_ETCHING_AFTER_GAIKAN,
            labour_cost_press_after_gaiakan = @LABOUR_COST_PRESS_AFTER_GAIKAN,
            labour_cost_non_printing_after_gaikan = @LABOUR_COST_NON_PRINTING_AFTER_GAIKAN
	WHERE dmc_type = @DMC_CODE 

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE [ad_dis_pc_sales_price]: ' + @DMC_CODE + 
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
