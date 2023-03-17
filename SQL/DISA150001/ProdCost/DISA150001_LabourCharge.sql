SELECT
	MAX([SC].LABOUR_CHARGE_PRINTING) LABOUR_CHARGE_PRINTING,
	MAX([SC].LABOUR_CHARGE_ASSEMBLY) LABOUR_CHARGE_ASSEMBLY,
	MAX([SC].LABOUR_CHARGE_ETCHING) LABOUR_CHARGE_ETCHING,
	MAX([SC].LABOUR_CHARGE_PRESS) LABOUR_CHARGE_PRESS,
	MAX([SC].LABOUR_CHARGE_NON_PRINTING) LABOUR_CHARGE_NON_PRINTING,
	MAX([SC].LABOUR_CHARGE_KOMPO) LABOUR_CHARGE_KOMPO
FROM
	(select  
	  case when factory = 'printing' then MAX(chinritsu) end as LABOUR_CHARGE_PRINTING,
	  case when factory = 'assembly' then MAX(chinritsu) end as LABOUR_CHARGE_ASSEMBLY, 
	  case when factory = 'etching' then MAX(chinritsu) end as LABOUR_CHARGE_ETCHING,
	  case when factory = 'press' then MAX(chinritsu) end as LABOUR_CHARGE_PRESS,
	  case when factory = 'non printing' then MAX(chinritsu) end as LABOUR_CHARGE_NON_PRINTING,
	  case when factory = 'kompo' then MAX(chinritsu) end as LABOUR_CHARGE_KOMPO
	from
	  ad_dis_pc_master_chinritsu 	
	group by 
	  factory
	) as [SC]