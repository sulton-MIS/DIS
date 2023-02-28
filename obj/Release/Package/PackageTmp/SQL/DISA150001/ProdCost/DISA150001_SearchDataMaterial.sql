SELECT 
    ROW_NUMBER() OVER (order by 
	CASE when part = 'F' then 1 
	when part = 'G' then 2
	when part = 'T' then 3
	when part = 'A' then 4
	when part = 'P' then 5
	END ASC) ROW_NUM
	,[dmc_code] as ID 
	,[dmc_code]    
    ,[part]
    ,[dmc_code_parts]
    ,[material_kode]
    ,[material_name]    
    ,[unit_price]
    ,[unit]
    ,[wide_size]
    ,[long_size]
    ,[material_size]
    ,[cut_size]
    ,[qty]
    ,[cavity]
    ,[price_per_sheet]
    ,[price_per_pcs]
FROM [TxDTIPRD].[dbo].[ad_dis_pc_production_cost_material]
	WHERE dmc_code = @ID and (ISNUMERIC(material_kode) != 0 or material_kode like '%ACS%') and price_per_pcs != 0
 order by 
	CASE when part = 'F' then 1 
	when part = 'G' then 2
	when part = 'T' then 3
	when part = 'A' then 4
	when part = 'P' then 5
	END ASC
