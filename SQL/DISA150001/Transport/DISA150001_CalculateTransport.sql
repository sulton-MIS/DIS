DECLARE 
@@col_acj NVARCHAR(MAX), 
@@col_scj NVARCHAR(MAX), 
@@col_acs NVARCHAR(MAX), 
@@col_scs NVARCHAR(MAX), 
@@col_ach NVARCHAR(MAX),
@@col_sch NVARCHAR(MAX),
@@sql NVARCHAR(MAX);   

SET @@col_acj = (SELECT ', ' + QUOTENAME(code_dokumen_fee) FROM ad_dis_pc_master_transportation_dok_fee WHERE code_dokumen_fee like 'DOKFEETACJ%' FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)');
SET @@col_scj = (SELECT ', ' + QUOTENAME(code_dokumen_fee) FROM ad_dis_pc_master_transportation_dok_fee WHERE code_dokumen_fee like 'DOKFEETSCJ%' FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)');
SET @@col_acs = (SELECT ', ' + QUOTENAME(code_dokumen_fee) FROM ad_dis_pc_master_transportation_dok_fee WHERE code_dokumen_fee like 'DOKFEETACS%' FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)');
SET @@col_scs = (SELECT ', ' + QUOTENAME(code_dokumen_fee) FROM ad_dis_pc_master_transportation_dok_fee WHERE code_dokumen_fee like 'DOKFEETSCS%' FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)');
SET @@col_ach = (SELECT ', ' + QUOTENAME(code_dokumen_fee) FROM ad_dis_pc_master_transportation_dok_fee WHERE code_dokumen_fee like 'DOKFEETACH%' FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)');
SET @@col_sch = (SELECT ', ' + QUOTENAME(code_dokumen_fee) FROM ad_dis_pc_master_transportation_dok_fee WHERE code_dokumen_fee like 'DOKFEETSCH%' FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)');

SET @@sql = 
'
--=====================================================================================================
--[AIR CIF JPN]
--=====================================================================================================
SELECT 
*
FROM
(
	SELECT 
		dmc_code
		,code_trans
		,lot_size
		,master_type
		,master_qty
		,qty_box
		,master_weight
		--,total_weight
		--,transportation_cost
		--,total_dok_fee = ' + REPLACE(@@col_acj, ', [', ' + [') + '
		--,' + STUFF(@@col_acj, 1, 2, '') + '
		,ROUND((transportation_cost + ' + REPLACE(@@col_acj, ', [', ' + [') + ') / lot_size,2) as total_cost
	FROM
	(
	  SELECT 
			transport.dmc_code
			,transport.code_trans
			,type_cust.lot_size
			,ConvPack.mastertype as master_type
			,ConvPack.masterqty as master_qty
			,CASE WHEN transport.code_trans like ''TA%'' THEN ROUND((type_cust.lot_size / (ConvPack.masterqty)),2) else ConvPack.qty_box END as qty_box
			,ConvPack.masterweight as master_weight
			,w.total_weight 
			,CASE 
				WHEN w.total_weight > 0 and w.total_weight <= 5 then freight.rate_0_sd_5_kg
				WHEN w.total_weight > 5 and w.total_weight <= 45 then w.total_weight * freight.rate_6_sd_45_kg
				WHEN w.total_weight > 45 and w.total_weight <= 100 then w.total_weight * freight.rate_46_sd_100_kg
				WHEN w.total_weight > 100 and w.total_weight <= 300 then w.total_weight * freight.rate_101_sd_300_kg
				WHEN w.total_weight > 300 and w.total_weight <= 500 then w.total_weight * freight.rate_301_sd_500_kg
				WHEN w.total_weight > 500 and w.total_weight <= 1000 then w.total_weight * freight.rate_501_sd_1000_kg
				WHEN w.total_weight > 1000 then w.total_weight * freight.rate_1000_up_kg
			END as transportation_cost
			,code_dokumen_fee  
			,CASE 
				WHEN code_dokumen_fee = ''DOKFEETACJ001'' THEN (CASE WHEN w.total_weight <= 50 THEN 0 else ((w.total_weight - 50) * unit_price) END)
			else unit_price 
			END as unit_price 
	  FROM 
			ad_dis_pc_master_transportation_dok_fee as dok_fee
	  INNER JOIN
			ad_dis_pc_master_transportation_dmc_code as transport
			ON dok_fee.code_trans = transport.code_trans
	  INNER JOIN
			ad_dis_pc_master_type_cust as type_cust 
			ON transport.dmc_code = type_cust.dmc_type
	  INNER JOIN
			[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking as ConvPack
			ON transport.dmc_code = ConvPack.itemcode
	  INNER JOIN
			ad_dis_pc_master_transportation_freight as freight
			ON transport.code_trans = freight.code_trans
	  INNER JOIN
			(SELECT 
				type_cust.dmc_type
				,(ROUND((type_cust.lot_size / (ConvPack.masterqty)),2)) * ConvPack.masterweight as total_weight
			FROM 
				ad_dis_pc_master_type_cust type_cust 
			INNER JOIN 
				[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking ConvPack
				ON type_cust.dmc_type = ConvPack.itemcode) as w
	  ON transport.dmc_code = w.dmc_type
	  WHERE 
			transport.code_trans like ''TACJ%''
	) AS j
	PIVOT
	(SUM(j.unit_price) FOR code_dokumen_fee IN ('+ STUFF(REPLACE(@@col_acj, ', [', ',['), 1, 1, '') + ')) AS p

	--=====================================================================================================
	--[SEA CIF JPN]
	UNION ALL 
	--=====================================================================================================

	SELECT 
		dmc_code
		,code_trans
		,lot_size
		,master_type
		,master_qty
		,qty_box
		,master_weight
		,(' + REPLACE(@@col_scj, ', [', ' + [') + ') / lot_size as total_cost
	FROM
	(
		  SELECT 
				transport.dmc_code
				,transport.code_trans
				,type_cust.lot_size
				,ConvPack.mastertype as master_type
				,ConvPack.masterqty as master_qty
				,CASE WHEN transport.code_trans like ''TA%'' THEN ROUND((type_cust.lot_size / ConvPack.masterqty),2) else ConvPack.qty_box END as qty_box
				,ConvPack.masterweight as master_weight
				,w.qty_per_m3
				,w.pallet_qty
				,code_dokumen_fee  
				,CASE 
					WHEN code_dokumen_fee = ''DOKFEETSCJ002'' or code_dokumen_fee = ''DOKFEETSCJ005'' THEN (unit_price * w.pallet_qty) 
					else unit_price 
				END as unit_price
		  FROM 
				ad_dis_pc_master_transportation_dok_fee as dok_fee
		  INNER JOIN
				ad_dis_pc_master_transportation_dmc_code as transport
				ON dok_fee.code_trans = transport.code_trans
		  INNER JOIN
				ad_dis_pc_master_type_cust as type_cust 
				ON transport.dmc_code = type_cust.dmc_type
		  INNER JOIN
				[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking as ConvPack
				ON transport.dmc_code = ConvPack.itemcode
		   INNER JOIN
				(SELECT 
					type_cust.dmc_type
					,ConvPack.qty_box * ConvPack.masterqty as qty_per_m3
					,type_cust.lot_size / (ConvPack.qty_box * ConvPack.masterqty) as pallet_qty
				FROM 
					ad_dis_pc_master_type_cust type_cust 
				INNER JOIN 
					[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking ConvPack
					ON type_cust.dmc_type = ConvPack.itemcode) as w
		  ON transport.dmc_code = w.dmc_type
	WHERE transport.code_trans like ''TSCJ%''
	) AS j
	PIVOT
	(SUM(j.unit_price) FOR code_dokumen_fee IN ('+ STUFF(REPLACE(@@col_scj, ', [', ',['), 1, 1, '') + ')) AS p

	--=====================================================================================================
	--[AIR CIF SANGHAY]
	UNION ALL 
	--=====================================================================================================

	SELECT 
		dmc_code
		,code_trans
		,lot_size
		,master_type
		,master_qty
		,qty_box
		,master_weight
		,(transportation_cost + ' + REPLACE(@@col_acs, ', [', ' + [') + ') / lot_size as total_cost
	FROM
	(
		  SELECT 
				transport.dmc_code
				,transport.code_trans
				,type_cust.lot_size
				,ConvPack.mastertype as master_type
				,ConvPack.masterqty as master_qty
				,CASE WHEN transport.code_trans like ''TA%'' THEN ROUND((type_cust.lot_size / ConvPack.masterqty),2) else ConvPack.qty_box END as qty_box
				,ConvPack.masterweight as master_weight
				,w.total_weight 
				,CASE 
					WHEN w.total_weight > 0 and w.total_weight <= 5 then freight.rate_0_sd_5_kg
					WHEN w.total_weight > 5 and w.total_weight <= 45 then w.total_weight * freight.rate_6_sd_45_kg
					WHEN w.total_weight > 45 and w.total_weight <= 100 then w.total_weight * freight.rate_46_sd_100_kg
					WHEN w.total_weight > 100 and w.total_weight <= 300 then w.total_weight * freight.rate_101_sd_300_kg
					WHEN w.total_weight > 300 and w.total_weight <= 500 then w.total_weight * freight.rate_301_sd_500_kg
					WHEN w.total_weight > 500 and w.total_weight <= 1000 then w.total_weight * freight.rate_501_sd_1000_kg
					WHEN w.total_weight > 1000 then w.total_weight * freight.rate_1000_up_kg
				END as transportation_cost
				,code_dokumen_fee  
				,CASE 
					WHEN code_dokumen_fee = ''DOKFEETACS001'' or code_dokumen_fee = ''DOKFEETACS002'' THEN (CASE WHEN w.total_weight <= 50 THEN 0 else ((w.total_weight - 50) * unit_price) END)
				else unit_price 
				END as unit_price 

		  FROM 
				ad_dis_pc_master_transportation_dok_fee as dok_fee
		  INNER JOIN
				ad_dis_pc_master_transportation_dmc_code as transport
				ON dok_fee.code_trans = transport.code_trans
		  INNER JOIN
				ad_dis_pc_master_type_cust as type_cust 
				ON transport.dmc_code = type_cust.dmc_type
		  INNER JOIN
				[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking as ConvPack
				ON transport.dmc_code = ConvPack.itemcode
		  INNER JOIN
				ad_dis_pc_master_transportation_freight as freight
				ON transport.code_trans = freight.code_trans
		  INNER JOIN
				(SELECT 
					type_cust.dmc_type
					,(ROUND((type_cust.lot_size / ConvPack.masterqty),2)) * ConvPack.masterweight as total_weight
				FROM 
					ad_dis_pc_master_type_cust type_cust 
				INNER JOIN 
					[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking ConvPack
					ON type_cust.dmc_type = ConvPack.itemcode) as w
		  ON transport.dmc_code = w.dmc_type
		WHERE transport.code_trans like ''TACS%''
	) AS j
	PIVOT
	(SUM(j.unit_price) FOR code_dokumen_fee IN ('+ STUFF(REPLACE(@@col_acs, ', [', ',['), 1, 1, '') + ')) AS p

	--=====================================================================================================
	--[SEA CIF SANGHAY]
	UNION ALL 
	--=====================================================================================================

	SELECT 
		dmc_code
		,code_trans
		,lot_size
		,master_type
		,master_qty
		,qty_box
		,master_weight
		--,qty_per_m3
		--,pallet_qty
		--,total_dok_fee = ' + REPLACE(@@col_scs, ', [', ' + [') + '
		--,trucking
		--,' + STUFF(@@col_scs, 1, 2, '') + '
		,(' + REPLACE(@@col_scs, ', [', ' + [') + ' + trucking) / lot_size as total_cost
	FROM
	(
		  SELECT 
				transport.dmc_code
				,transport.code_trans
				,type_cust.lot_size
				,ConvPack.mastertype as master_type
				,ConvPack.masterqty as master_qty
				,CASE WHEN transport.code_trans like ''TA%'' THEN ROUND((type_cust.lot_size / ConvPack.masterqty),2) else ConvPack.qty_box END as qty_box
				,ConvPack.masterweight as master_weight
				,w.qty_per_m3
				,w.pallet_qty
				,code_dokumen_fee  
				,CASE 
					WHEN ConvPack.qty_box > 0 and ConvPack.qty_box <= 4 then 864000
					WHEN ConvPack.qty_box > 4 and ConvPack.qty_box <= 11 then 1008000
					WHEN ConvPack.qty_box > 11 and ConvPack.qty_box <= 20 then 1800000
				else
					1800000
				END as trucking
				,CASE 
					WHEN code_dokumen_fee = ''DOKFEETSCS001'' or code_dokumen_fee = ''DOKFEETSCS005'' THEN (unit_price * w.pallet_qty) 
					WHEN code_dokumen_fee = ''DOKFEETSCS008'' THEN (CASE WHEN ConvPack.qty_box > 3 THEN (unit_price) else 0 END)
				else unit_price 
				END as unit_price 
		  FROM 
				ad_dis_pc_master_transportation_dok_fee as dok_fee
		  INNER JOIN
				ad_dis_pc_master_transportation_dmc_code as transport
				ON dok_fee.code_trans = transport.code_trans
		  INNER JOIN
				ad_dis_pc_master_type_cust as type_cust 
				ON transport.dmc_code = type_cust.dmc_type
		  INNER JOIN
				[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking as ConvPack
				ON transport.dmc_code = ConvPack.itemcode
		   INNER JOIN
				(SELECT 
					type_cust.dmc_type
					,ConvPack.qty_box * ConvPack.masterqty as qty_per_m3
					,type_cust.lot_size / (ConvPack.qty_box * ConvPack.masterqty) as pallet_qty
				FROM 
					ad_dis_pc_master_type_cust type_cust 
				INNER JOIN 
					[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking ConvPack
					ON type_cust.dmc_type = ConvPack.itemcode) as w
		  ON transport.dmc_code = w.dmc_type
		WHERE transport.code_trans like ''TSCS%''
	) AS j
	PIVOT
	(SUM(j.unit_price) FOR code_dokumen_fee IN ('+ STUFF(REPLACE(@@col_scs, ', [', ',['), 1, 1, '') + ')) AS p

	--=====================================================================================================
	--[AIR CIF HONGKONG]
	UNION ALL 
	--=====================================================================================================

	SELECT 
		dmc_code
		,code_trans
		,lot_size
		,master_type
		,master_qty
		,qty_box
		,master_weight
		--,total_weight
		--,transportation_cost
		--,total_dok_fee = ' + REPLACE(@@col_ach, ', [', ' + [') + '
		--,' + STUFF(@@col_ach, 1, 2, '') + '
		,(transportation_cost + ' + REPLACE(@@col_ach, ', [', ' + [') + ') / lot_size as total_cost
	FROM
	(
		  SELECT 
				transport.dmc_code
				,transport.code_trans
				,type_cust.lot_size
				,ConvPack.mastertype as master_type
				,ConvPack.masterqty as master_qty
				,CASE WHEN transport.code_trans like ''TA%'' THEN ROUND((type_cust.lot_size / ConvPack.masterqty),2) else ConvPack.qty_box END as qty_box
				,ConvPack.masterweight as master_weight
				,w.total_weight 
				,CASE 
					WHEN w.total_weight > 0 and w.total_weight <= 36 then freight.rate_0_sd_5_kg
					WHEN w.total_weight > 36 and w.total_weight <= 45 then w.total_weight * freight.rate_6_sd_45_kg
					WHEN w.total_weight > 45 and w.total_weight <= 100 then w.total_weight * freight.rate_46_sd_100_kg
					WHEN w.total_weight > 100 and w.total_weight <= 250 then w.total_weight * freight.rate_101_sd_300_kg
					WHEN w.total_weight > 250 and w.total_weight <= 500 then w.total_weight * freight.rate_301_sd_500_kg
					WHEN w.total_weight > 500 and w.total_weight <= 1000 then w.total_weight * freight.rate_501_sd_1000_kg
					WHEN w.total_weight > 1000 then w.total_weight * freight.rate_1000_up_kg
				END as transportation_cost
				,code_dokumen_fee  
				,CASE 
					WHEN code_dokumen_fee = ''DOKFEETACH006'' or code_dokumen_fee = ''DOKFEETACH007'' THEN (CASE WHEN w.total_weight <= 50 THEN 0 else ((w.total_weight - 50) * unit_price) END)
				else unit_price 
				END as unit_price 
		  FROM 
				ad_dis_pc_master_transportation_dok_fee as dok_fee
		  INNER JOIN
				ad_dis_pc_master_transportation_dmc_code as transport
				ON dok_fee.code_trans = transport.code_trans
		  INNER JOIN
				ad_dis_pc_master_type_cust as type_cust 
				ON transport.dmc_code = type_cust.dmc_type
		  INNER JOIN
				[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking as ConvPack
				ON transport.dmc_code = ConvPack.itemcode
		  INNER JOIN
				ad_dis_pc_master_transportation_freight as freight
				ON transport.code_trans = freight.code_trans
		  INNER JOIN
				(SELECT 
					type_cust.dmc_type
					,(ROUND((type_cust.lot_size / ConvPack.masterqty),2)) * ConvPack.masterweight as total_weight
				FROM 
					ad_dis_pc_master_type_cust type_cust 
				INNER JOIN 
					[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking ConvPack
					ON type_cust.dmc_type = ConvPack.itemcode) as w
		  ON transport.dmc_code = w.dmc_type
		WHERE transport.code_trans like ''TACH%''
	) AS j 
	PIVOT
	(SUM(j.unit_price) FOR code_dokumen_fee IN ('+ STUFF(REPLACE(@@col_ach, ', [', ',['), 1, 1, '') + ')) AS p

	--=====================================================================================================
	--[Sea Cif Hongkong]
	UNION ALL 
	--=====================================================================================================

	SELECT 
		dmc_code
		,code_trans
		,lot_size
		,master_type
		,master_qty
		,qty_box
		,master_weight
		--,qty_per_m3
		--,pallet_qty
		--,total_dok_fee = ' + REPLACE(@@col_sch, ', [', ' + [') + '
		--,trucking
		--,' + STUFF(@@col_sch, 1, 2, '') + '
		,(' + REPLACE(@@col_sch, ', [', ' + [') + ' + trucking) / qty_per_m3 as total_cost
	FROM
	(
		  SELECT 
				transport.dmc_code
				,transport.code_trans
				,type_cust.lot_size
				,ConvPack.mastertype as master_type
				,ConvPack.masterqty as master_qty
				,CASE WHEN transport.code_trans like ''TA%'' THEN ROUND((type_cust.lot_size / ConvPack.masterqty),2) else ConvPack.qty_box END as qty_box
				,ConvPack.masterweight as master_weight
				,w.qty_per_m3
				,w.pallet_qty
				,code_dokumen_fee  
				,CASE 
					WHEN ConvPack.qty_box > 0 and ConvPack.qty_box <= 3 then 875000
					WHEN ConvPack.qty_box > 3 and ConvPack.qty_box <= 5 then 1000000
					WHEN ConvPack.qty_box > 5 and ConvPack.qty_box <= 8 then 1600000
					WHEN ConvPack.qty_box > 8 and ConvPack.qty_box <= 15 then 1750000
				else 
					1750000
				END as trucking
				,CASE 
					WHEN code_dokumen_fee = ''DOKFEETSCH006'' THEN (CASE WHEN ConvPack.qty_box > 3 THEN (unit_price) else 0 END)
				else unit_price 
				END as unit_price 
		  FROM 
				ad_dis_pc_master_transportation_dok_fee as dok_fee
		  INNER JOIN
				ad_dis_pc_master_transportation_dmc_code as transport
				ON dok_fee.code_trans = transport.code_trans
		  INNER JOIN
				ad_dis_pc_master_type_cust as type_cust 
				ON transport.dmc_code = type_cust.dmc_type
		  INNER JOIN
				[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking as ConvPack
				ON transport.dmc_code = ConvPack.itemcode
		   INNER JOIN
				(SELECT 
					type_cust.dmc_type
					,ConvPack.qty_box * ConvPack.masterqty as qty_per_m3
					,type_cust.lot_size / (ConvPack.qty_box * ConvPack.masterqty) as pallet_qty
				FROM 
					ad_dis_pc_master_type_cust type_cust 
				INNER JOIN 
					[192.168.0.4].[TxDTIPRD].[dbo].Y_ConvertionTablePacking ConvPack
					ON type_cust.dmc_type = ConvPack.itemcode) as w
		  ON transport.dmc_code = w.dmc_type
		WHERE 
			transport.code_trans like ''TSCH%''
	) AS j
	PIVOT
	(SUM(j.unit_price) FOR code_dokumen_fee IN ('+ STUFF(REPLACE(@@col_sch, ', [', ',['), 1, 1, '') + ')) AS p
) as TransportationCost
WHERE 
1=1
';
IF(@item_code <> '')
	BEGIN
		SET @@sql = @@sql + 'AND TransportationCost.dmc_code LIKE ''%'+RTRIM(@item_code)+'%'' ';
	END
EXEC (@@sql);

