
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
