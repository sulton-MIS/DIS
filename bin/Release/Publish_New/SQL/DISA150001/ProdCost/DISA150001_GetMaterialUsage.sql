select 
	dmc_code, 
	dmc_code_parts, 
	part 
from 
	ad_dis_pc_production_cost_material
where 
	dmc_code = @DMC_CODE
group by 
	dmc_code, dmc_code_parts, part