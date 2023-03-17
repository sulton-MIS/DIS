DECLARE @@QUERY VARCHAR(MAX);


SET @@QUERY = '';
SET @@QUERY = '
SELECT 
	ROW_NUMBER() OVER (ORDER BY [Dmc_Type] ASC) ROW_NUM
	,[dmc_type] as ID 
	,[dmc_type]
    ,[customer]
    ,[touch_panel_type]
    ,[rank]
    ,[touch_panel_dimension]
    ,[touch_panel_size]
    ,[versi_wis]
    ,[lot_size]
    ,[indirect]
    ,[sga]
    ,[cavity_film]
    ,[cavity_glass]
    ,[cavity_tail]
    ,[yield_printing_film]
    ,[yield_printing_glass]
    ,[yield_printing_tail]
    ,[yield_film_midle_inspection]
    ,[yield_glass_midle_inspection]
    ,[yield_tail_electrical]
    ,[yield_tail_cosmetic]
    ,[yield_assembly]
    ,[yield_final_assembly]
    ,[yield_electrical_inspection]
    ,[yield_final_inspection]
    ,[yield_total_film]
    ,[yield_total_glass]
    ,[yield_total_tail]
    ,[lot_size_film]
    ,[max_lot_size_film]
    ,[lot_size_glass]
    ,[max_lot_size_glass]
    ,[lot_size_tail]
    ,[max_lot_size_tail]
    ,[labour_charge_printing]
    ,[labour_charge_assembly]
    ,[labour_charge_etching]
    ,[labour_charge_press]
    ,[labour_charge_non_printing]
    ,[labour_charge_kompo]
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
    ,[material_cost_after_gaikan_printing]
    ,[material_cost_after_gaikan_assembly]
    ,[material_cost_after_gaikan_etching]
    ,[material_cost_after_gaikan_press]
    ,[material_cost_after_gaikan_non_printing]    
FROM 
	ad_dis_pc_production_cost 
WHERE
	1=1	
';

IF(@DMC_TYPE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dmc_type LIKE ''%'+RTRIM(@DMC_TYPE)+'%'' ';
	END

EXEC(@@QUERY)


