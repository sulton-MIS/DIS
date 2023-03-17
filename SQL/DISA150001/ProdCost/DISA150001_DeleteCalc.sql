

DELETE [ad_dis_pc_production_cost] where dmc_type = @DMC_TYPE
DELETE [ad_dis_pc_production_cost_material] where dmc_code = @DMC_TYPE
DELETE [ad_dis_pc_production_cost_material_usage] where dmc_code = @DMC_TYPE
DELETE [ad_dis_pc_sales_price] where dmc_type = @DMC_TYPE
DELETE [ad_dis_pc_wip_cost] where dmc_type LIKE '%'+RTRIM(@DMC_TYPE)+'%'
DELETE [ad_dis_pc_price_list] where dmc_type = @DMC_TYPE
DELETE [ad_dis_pc_price_list_temp] where dmc_type = @DMC_TYPE

--truncate table ad_dis_pc_price_list
--truncate table ad_dis_pc_production_cost
--truncate table ad_dis_pc_production_cost_material
--truncate table ad_dis_pc_production_cost_material_usage
--truncate table ad_dis_pc_sales_price
--truncate table ad_dis_pc_wip_cost