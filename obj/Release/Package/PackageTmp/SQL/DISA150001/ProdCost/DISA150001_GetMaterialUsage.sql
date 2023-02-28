select 
	dmc_code, 
	dmc_code_parts, 
	part
	--cavity,
	--material_kode,
	--material_name
from 
	ad_dis_pc_production_cost_material
where 
	dmc_code = @DMC_CODE
group by 
	dmc_code, dmc_code_parts, part
	--, part, cavity, material_kode, material_name