SELECT 
    ROW_NUMBER() OVER (order by 
	CASE when part = 'FILM' then 1 
	when part = 'GLASS' then 2
	when part = 'TAIL' then 3
	when part = 'ASSEMBLY' then 4
	when part = 'PACKING' then 5
	END ASC) ROW_NUM
	,[dmc_code] as ID 
	,[dmc_code]
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
    ,[price_per_sheet]
    ,[price_per_pcs]
FROM [TxDTIPRD].[dbo].[ad_dis_pc_production_cost_material_usage]
	WHERE dmc_code = @ID
 order by 
	CASE when part = 'FILM' then 1 
	when part = 'GLASS' then 2
	when part = 'TAIL' then 3
	when part = 'ASSEMBLY' then 4
	when part = 'PACKING' then 5
	END ASC