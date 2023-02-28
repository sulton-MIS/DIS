	select 
		id, tahun, bulan, halte, halte_initial, total_day, amount_day, 
		average_price, setting_cokoritsu, target_daily, target_hourly, man_power
	from 
		ad_dis_rtjn_master_dashboard_target
	where
		tahun = @parm_tahun
		and bulan = @parm_bulan
		and halte_initial = @parm_halte_initial;