
SELECT
	M.part,
	R.CODE as [DMC_CODE_PARTS],
	R.KBAN as [URUTAN_PROSES],
	R.KBAN2 as [KODE_PROSES],
	R.CONT as [NAMA_PROSES],
	W.DTIME_PS as [SETTING_TIME],
	W.STIME_PS as [CYCLE_TIME],
	C.FACTORY as [FACTORY],
	C.CHINRITSU as [CHINRITSU],
	M.CAVITY
FROM
	Z_KOUT R
	LEFT OUTER JOIN Z_JIKA W ON R.CODE = W.CODE and R.KBAN = W.KBAN	
	LEFT OUTER JOIN [192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_pc_production_cost_material] M ON R.CODE = M.DMC_CODE_PARTS
	LEFT OUTER JOIN [192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_pc_master_chinritsu] C ON R.KBAN2 = C.id_kotei AND M.PART  = C.PART
WHERE 
	R.CODE = @DMC_CODE_PARTS
	and R.CONT not like '%1/2%'
	--and M.part like 'F'
	--and R.Z_RT_INPUT_FLG = 'Y'
group by 
	R.CODE,
	R.KBAN,
	R.KBAN2,
	R.CONT,
	W.DTIME_PS,
	W.STIME_PS,
	C.FACTORY,
	C.CHINRITSU,
	M.CAVITY,
	M.PART

UNION ALL

SELECT 
	  'H' as part
	  ,[dmc_code_parts] as [DMC_CODE_PARTS]
	  ,[urutan_proses] as [URUTAN_PROSES]
      ,[kode_proses] as [KODE_PROSES]
      ,[nama_proses] as [NAMA_PROSES]
      ,[setting_time] as [SETTING_TIME]
      ,[cycle_time] as [CYCLE_TIME]
      ,C.FACTORY as [FACTORY]
	  ,C.CHINRITSU as [CHINRITSU]
      ,[cavity]      
FROM [192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_pc_master_material_usage_others]
LEFT OUTER JOIN [192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_pc_master_chinritsu] C ON kode_proses = C.id_kotei