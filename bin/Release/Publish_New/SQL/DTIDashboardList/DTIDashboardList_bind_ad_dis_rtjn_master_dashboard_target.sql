﻿	select 
		target_date
		,target_print_qty
		,target_qty_jam_ke_1
		,target_qty_jam_ke_2
		,target_qty_jam_ke_3
		,target_qty_jam_ke_4
		,target_qty_jam_ke_5
		,target_qty_jam_ke_6
		,target_qty_jam_ke_7
		,target_qty_jam_ke_8
		,target_qty_jam_ke_9
		,target_qty_jam_ke_10
		,target_qty_jam_ke_11
		,target_qty_jam_ke_12
		,target_qty_jam_ke_13
		,target_qty_jam_ke_14
		,target_qty_jam_ke_15_16_istirahat
		,target_qty_jam_ke_17
		,target_qty_jam_ke_18
		,target_qty_jam_ke_19
		,target_qty_jam_ke_20
		,target_qty_jam_ke_21
		,target_qty_jam_ke_22
		,target_qty_jam_ke_1	+ target_qty_jam_ke_2	+ target_qty_jam_ke_3	+ target_qty_jam_ke_4	+ target_qty_jam_ke_5	+ target_qty_jam_ke_6	+ target_qty_jam_ke_7	+ target_qty_jam_ke_8	+ target_qty_jam_ke_9	+ target_qty_jam_ke_10	+ target_qty_jam_ke_11	+ target_qty_jam_ke_12	+ target_qty_jam_ke_13	+ target_qty_jam_ke_14	+ target_qty_jam_ke_15_16_istirahat	+ target_qty_jam_ke_17	+ target_qty_jam_ke_18	+ target_qty_jam_ke_19	+ target_qty_jam_ke_20	+ target_qty_jam_ke_21	+ target_qty_jam_ke_22 as akumulasi_target
	from 
		ad_dis_rtjn_sum_qty_amount_target
	where
		target_date = @parm_target_date and halte = @parm_halte_initial