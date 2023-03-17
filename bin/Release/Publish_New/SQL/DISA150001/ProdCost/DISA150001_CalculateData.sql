SELECT
	MAS_CUST.dmc_type as DATA_ID,
	MAS_CUST.dmc_type as dmc_type, 
	customer as customer,
	XITEM.tp_type as touch_panel_type,
	XITEM.tp_rank as rank,
	touch_panel_size as touch_panel_dimension,	
	CONV_TBL.sizeproduct as touch_panel_size,
	wis_version as versi_wis,	
	lot_size as lot_size,
	MAS_CUST.in_direct as indirect,
	MAS_CUST.sga as sga,
	CAV_F.cavity as cavity_film, 
	CAV_G.cavity as cavity_glass,
	CAV_T.cavity as cavity_tail
FROM
	ad_dis_pc_master_type_cust as MAS_CUST	
	INNER JOIN
		[192.168.0.4].[TxDTIPRD].[dbo].[XITEM] as XITEM
		ON MAS_CUST.dmc_type = XITEM.code
	INNER JOIN 
		[192.168.0.4].[TxDTIPRD].[dbo].[Y_ConvertionTablePacking] as CONV_TBL
		ON MAS_CUST.dmc_type = CONV_TBL.itemcode
	INNER JOIN 
		[192.168.0.3].[RTJN_PRD].[dbo].[Z_CAVITY] as CAV_F
		ON MAS_CUST.dmc_type = CAV_F.dmc_code 
		AND CAV_F.PART LIKE '-F'
	INNER JOIN 
		[192.168.0.3].[RTJN_PRD].[dbo].[Z_CAVITY] as CAV_G
		ON MAS_CUST.dmc_type = CAV_G.dmc_code 
		AND CAV_G.PART LIKE '-G'
	INNER JOIN 
		[192.168.0.3].[RTJN_PRD].[dbo].[Z_CAVITY] as CAV_T
		ON MAS_CUST.dmc_type = CAV_T.dmc_code 
		AND CAV_T.PART LIKE '-T'
--WHERE
--	MAS_CUST.dmc_type = 'TP-4600S1F1'
