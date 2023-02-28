
  --===============================================
  --PRICE LIST
  --===============================================

  select
	dmc_type,	
	customer,
	touch_panel_type,
	touch_panel_size,
	versi_wis,
	total_yield_film,	
	jenis_transportation,
	max(lot_10) as lot_10,
	max(lot_20) as lot_20,
	max(lot_50) as lot_50,
	max(lot_100) as lot_100,
	max(lot_200) as lot_200,
	max(lot_300) as lot_300,
	max(lot_400) as lot_400,
	max(lot_500) as lot_500,
	max(lot_1000) as lot_1000,
	max(lot_5000) as lot_5000	
from
(
	select 
		dmc_type,
		customer,
		touch_panel_type,
		touch_panel_size,
		versi_wis,
		total_yield_film,		
		jenis_transportation,
		case when lot_size = 10 then price else 0 end lot_10,
		case when lot_size = 20 then price else 0 end lot_20,
		case when lot_size = 50 then price else 0 end lot_50,
		case when lot_size = 100 then price else 0 end lot_100,
		case when lot_size = 200 then price else 0 end lot_200,
		case when lot_size = 300 then price else 0 end lot_300,
		case when lot_size = 400 then price else 0 end lot_400,
		case when lot_size = 500 then price else 0 end lot_500,
		case when lot_size = 1000 then price else 0 end lot_1000,
		case when lot_size = 5000 then price else 0 end lot_5000		
	from 
		[ad_dis_pc_price_list_temp]
	unpivot
		(
		  price
		  for jenis_transportation in (air_cif_sales_price, sea_jpn_sales_price, fob_sales_price)
		) unpiv
	
) as price_list
group by
	dmc_type,	
	customer,
	touch_panel_type,
	touch_panel_size,
	versi_wis,
	total_yield_film,
	jenis_transportation,
	customer,
	touch_panel_type,
	touch_panel_size,
	versi_wis,
	total_yield_film
order by
	case when jenis_transportation like 'air_cif_sales_price' then 1
	when jenis_transportation like 'sea_jpn_sales_price' then 2
	when jenis_transportation like 'fob_sales_price' then 3 end
asc

--  SELECT	
--	dmc_type,
--	customer,
--	touch_panel_type,
--	touch_panel_size,
--	versi_wis,
--	yield_total_film,
--	jenis_transportation,
--	--lot_size,
--	MAX(lot_10) as lot_10,
--	MAX(lot_20) as lot_20,
--	MAX(lot_50) as lot_50,
--	MAX(lot_100) as lot_100,
--	MAX(lot_200) as lot_200,
--	MAX(lot_300) as lot_300,
--	MAX(lot_400) as lot_400,
--	MAX(lot_500) as lot_500,
--	MAX(lot_1000) as lot_1000,
--	MAX(lot_5000) as lot_5000
--  FROM
--  (
--	  SELECT
--			SP.dmc_type,
--			PC.customer,
--			PC.touch_panel_type,
--			PC.touch_panel_size,
--			PC.versi_wis,
--			PC.yield_total_film,
--			MT.jenis_transportation,
--			LZ.lot_size,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 10 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 10 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 10 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_10,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 20 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 20 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 20 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_20,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 50 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 50 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 50 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_50,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 10 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 10 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 10 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_100,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 200 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 200 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 200 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_200,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 300 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 300 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 300 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_300,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 400 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 400 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 400 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_400,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 500 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 500 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 500 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_500,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 1000 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 1000 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 1000 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_1000,
--			CASE 
--				WHEN jenis_transportation = 'Trans Cost Air JPN' and LZ.lot_size = 5000 THEN ROUND(SP.total_cost_air_jpn / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Trans Cost Sea Tokyo' and LZ.lot_size = 5000 THEN ROUND(SP.total_cost_sea_tokyo / (1-SP.air_cif_profit_ratio),0)
--				WHEN jenis_transportation = 'Fob' and LZ.lot_size = 5000 THEN ROUND(SP.total_cost_fob / (1-SP.air_cif_profit_ratio),0)
--			END as lot_5000
		
--		FROM
--			ad_dis_pc_sales_price SP
--		LEFT OUTER JOIN
--			ad_dis_pc_master_transportation MT ON SP.dmc_type = MT.item_code AND
--			MT.jenis_transportation = 'Trans Cost Air JPN' OR
--			MT.jenis_transportation = 'Trans Cost Sea Tokyo' OR
--			MT.jenis_transportation = 'Fob'
--		LEFT OUTER JOIN 
--			ad_dis_pc_production_cost PC ON SP.dmc_type = PC.dmc_type
--		LEFT OUTER JOIN
--			ad_dis_pc_master_lot_size LZ ON SP.dmc_type = LZ.dmc_type
		
--		GROUP BY
--			SP.dmc_type,
--			PC.customer,
--			PC.touch_panel_type,
--			PC.touch_panel_size,
--			PC.versi_wis,
--			PC.yield_total_film,
--			MT.jenis_transportation,
--			LZ.lot_size,
--			SP.air_cif_profit_ratio,
--			SP.total_cost_air_jpn,
--			SP.total_cost_sea_tokyo,
--			SP.total_cost_air_sha,
--			SP.total_cost_sea_sha,
--			SP.total_cost_air_hkg,
--			SP.total_cost_sea_hkg,
--			SP.total_cost_fob
--) as PL

--GROUP BY
--	dmc_type,	
--	customer,
--	touch_panel_type,
--	touch_panel_size,
--	versi_wis,
--	yield_total_film,
--	jenis_transportation
--	--lot_size,
--	--lot_10
--	--lot_20,
--	--lot_50,
--	--lot_100,
--	--lot_200,
--	--lot_300,
--	--lot_400,
--	--lot_500,
--	--lot_1000,
--	--lot_5000
--ORDER BY
--CASE 
--	WHEN PL.jenis_transportation = 'Trans Cost Air JPN' THEN 1
--	WHEN PL.jenis_transportation = 'Trans Cost Sea Tokyo' THEN 2
--	WHEN PL.jenis_transportation = 'Fob' THEN 3
--END

