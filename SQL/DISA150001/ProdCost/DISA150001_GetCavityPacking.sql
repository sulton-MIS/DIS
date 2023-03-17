select 
	dmc_code,
	max(cav_inner) C_INNER,
	max(cav_foampad) C_FOAM,
	max(cav_master) C_MASTER
from
(
select 
	dmc_code, 	
	case when material_kode = 21200577 then cavity end as cav_inner,
	case when material_kode = 21204181 then cavity end as cav_foampad,
	case when material_kode = 22200903 then cavity end as cav_master
from 
	ad_dis_pc_production_cost_material
where
	part like 'P'
	and material_kode in (21200577, 21204181, 22200903)
group by 
	dmc_code, material_kode, cavity
) as CAVITY
where 
	dmc_code = @DMC_CODE
group by
	dmc_code