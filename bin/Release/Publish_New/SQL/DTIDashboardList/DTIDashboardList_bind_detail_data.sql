DECLARE @@QUERY VARCHAR(MAX);
SET @@QUERY = '

SELECT 
	[TGT].HALTE, 
	[SC].SHIFT_DATE, 
	[SC].JAM, 
	[TGT].TARGET, 
	[SC].ACTUAL,
	CASE WHEN [SC].ACTUAL != 0 then sum([SC].ACTUAL) OVER (ORDER BY [SC].SHIFT_DATE, 		
		CASE when [SC].JAM = ''07:30-08:30'' then 1 			 
			 when [SC].JAM = ''08:30-09:30'' then 2
			 when [SC].JAM = ''09:30-10:40'' then 3
			 when [SC].JAM = ''10:40-12:30'' then 4			 
			 when [SC].JAM = ''12:30-13:30'' then 5
			 when [SC].JAM = ''13:30-14:30'' then 6
			 when [SC].JAM = ''14:30-16:00'' then 7
			 when [SC].JAM = ''16:00-17:00'' then 8			 
			 when [SC].JAM = ''17:00-18:30'' then 9
			 when [SC].JAM = ''18:30-19:30'' then 10
			 when [SC].JAM = ''19:30-20:30'' then 11
			 when [SC].JAM = ''20:30-21:30'' then 12
			 when [SC].JAM = ''21:30-22:30'' then 13
			 when [SC].JAM = ''22:30-23:30'' then 14
			 when [SC].JAM = ''23:30-00:30'' then 15
			 when [SC].JAM = ''00:30-01:30'' then 16
			 when [SC].JAM = ''01:30-02:30'' then 17
			 when [SC].JAM = ''02:30-03:30'' then 18
			 when [SC].JAM = ''03:30-05:30'' then 19
			 when [SC].JAM = ''05:30-06:30'' then 20
			 when [SC].JAM = ''06:30-07:30'' then 21
		END ASC) else 0 end as ACC,	
	[SC].MP, 
	SUM([ACT_TRBL].OPMJ) as OPMJ, 	
	[ACT_TRBL].MASALAH,
	[ACT_TRBL].ACTION
FROM (
		SELECT 			 
			[ACT].SHIFT_DATE, 
			[ACT].JAM, 			
			SUM([ACT].ACTUAL) ACTUAL,	
			SUM([ACT].MANPOWER) as MP		
		FROM (				
';

SET @@QUERY = @@QUERY + '	
					select 
						PROSES, SHIFT_DATE, JAM, sum(case when SHIFT_DATE = STUFF(STUFF('''+@parm_tgl_shift_date+''',7,0,''-''),5,0,''-'') then qty_ok else 0 end) [ACTUAL], SUM(case when SHIFT_DATE = STUFF(STUFF('''+@parm_tgl_shift_date+''',7,0,''-''),5,0,''-'') then manpower else 0 end) [MANPOWER]
					from
					( 					
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 08:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 08:29:59'' then id_sagyosha1 end) AS manpower, ''07:30-08:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 					
						group by shift_date, id_kotei					
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 08:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 09:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 08:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 09:29:59'' then id_sagyosha1 end) AS manpower, ''08:30-09:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 09:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 10:39:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 09:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 10:39:59'' then id_sagyosha1 end) AS manpower, ''09:30-10:40'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 10:40:00'' and '''+@parm_tgl_shift_1_2+''' + '' 12:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 10:40:00'' and '''+@parm_tgl_shift_1_2+''' + '' 12:29:59'' then id_sagyosha1 end) AS manpower, ''10:40-12:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei				
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 12:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 13:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 12:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 13:29:59'' then id_sagyosha1 end) AS manpower, ''12:30-13:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 13:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 14:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 13:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 14:29:59'' then id_sagyosha1 end) AS manpower, ''13:30-14:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 14:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 15:59:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 14:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 15:59:59'' then id_sagyosha1 end) AS manpower, ''14:30-16:00'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 16:00:00'' and '''+@parm_tgl_shift_1_2+''' + '' 16:59:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 16:00:00'' and '''+@parm_tgl_shift_1_2+''' + '' 16:59:59'' then id_sagyosha1 end) AS manpower, ''16:00-17:00'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 17:00:00'' and '''+@parm_tgl_shift_1_2+''' + '' 18:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 17:00:00'' and '''+@parm_tgl_shift_1_2+''' + '' 18:29:59'' then id_sagyosha1 end) AS manpower, ''17:00-18:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 18:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 19:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 18:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 19:29:59'' then id_sagyosha1 end) AS manpower, ''18:30-19:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 19:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 20:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 19:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 20:29:59'' then id_sagyosha1 end) AS manpower, ''19:30-20:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 20:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 21:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 20:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 21:29:59'' then id_sagyosha1 end) AS manpower, ''20:30-21:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 21:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 22:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 21:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 22:29:59'' then id_sagyosha1 end) AS manpower, ''21:30-22:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 22:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 23:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 22:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 23:29:59'' then id_sagyosha1 end) AS manpower, ''22:30-23:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 23:30:00'' and '''+@parm_tgl_shift_3+''' + '' 00:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 23:30:00'' and '''+@parm_tgl_shift_3+''' + '' 00:29:59'' then id_sagyosha1 end) AS manpower, ''23:30-00:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 00:30:00'' and '''+@parm_tgl_shift_3+''' + '' 01:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 00:30:00'' and '''+@parm_tgl_shift_3+''' + '' 01:29:59'' then id_sagyosha1 end) AS manpower, ''00:30-01:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 01:30:00'' and '''+@parm_tgl_shift_3+''' + '' 02:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 01:30:00'' and '''+@parm_tgl_shift_3+''' + '' 02:29:59'' then id_sagyosha1 end) AS manpower, ''01:30-02:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 02:30:00'' and '''+@parm_tgl_shift_3+''' + '' 03:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 02:30:00'' and '''+@parm_tgl_shift_3+''' + '' 03:29:59'' then id_sagyosha1 end) AS manpower, ''02:30-03:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 03:30:00'' and '''+@parm_tgl_shift_3+''' + '' 05:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 03:30:00'' and '''+@parm_tgl_shift_3+''' + '' 05:29:59'' then id_sagyosha1 end) AS manpower, ''03:30-05:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 05:30:00'' and '''+@parm_tgl_shift_3+''' + '' 06:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 05:30:00'' and '''+@parm_tgl_shift_3+''' + '' 06:29:59'' then id_sagyosha1 end) AS manpower, ''05:30-06:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei
						union all
						select id_kotei as PROSES, STUFF(STUFF(shift_date,7,0,''-''),5,0,''-'') as SHIFT_DATE, sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 06:30:00'' and '''+@parm_tgl_shift_3+''' + '' 07:29:59'' then amnt_OK else 0 end) AS qty_ok, count(distinct case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 06:30:00'' and '''+@parm_tgl_shift_3+''' + '' 07:29:59'' then id_sagyosha1 end) AS manpower, ''06:30-07:30'' JAM from [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_data_J_kotei 		
						group by shift_date, id_kotei	
					) RTJN
					left join [192.168.0.3].[RTJN_PRD].[DBO].Z_RT_master_kotei B on RTJN.PROSES = B.id_kotei 
					where 1=1
';

SET @@QUERY = @@QUERY + @parm_filter_output_halte + '

					group by JAM, SHIFT_DATE, PROSES
				) as [ACT] 				 
		GROUP BY [ACT].SHIFT_DATE, [ACT].JAM
) as [SC]
LEFT JOIN (
			select 
					TARGET_DATE, HALTE, JAM, sum(case when target_date = STUFF(STUFF('''+@parm_tgl_shift_date+''',7,0,''-''),5,0,''-'') then qty_ok else 0 end) [TARGET]
				from
				(
					select target_date, halte, target_qty_jam_ke_1 qty_ok, ''07:30-08:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]	
					union all
					select target_date, halte, target_qty_jam_ke_2 qty_ok, ''08:30-09:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_3 qty_ok, ''09:30-10:40'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_4 qty_ok, ''10:40-12:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]		
					union all
					select target_date, halte, target_qty_jam_ke_5 qty_ok, ''12:30-13:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_6 qty_ok, ''13:30-14:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_7 qty_ok, ''14:30-16:00'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_8 qty_ok, ''16:00-17:00'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_9 qty_ok, ''17:00-18:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_10 qty_ok, ''18:30-19:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_11 qty_ok, ''19:30-20:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_12 qty_ok, ''20:30-21:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_13 qty_ok, ''21:30-22:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_14 qty_ok, ''22:30-23:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
					union all
					select target_date, halte, target_qty_jam_ke_15_16_istirahat qty_ok, ''23:30-00:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]	
					union all
					select target_date, halte, target_qty_jam_ke_17 qty_ok, ''00:30-01:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]	
					union all
					select target_date, halte, target_qty_jam_ke_18 qty_ok, ''01:30-02:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]	
					union all
					select target_date, halte, target_qty_jam_ke_19 qty_ok, ''02:30-03:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]	
					union all
					select target_date, halte, target_qty_jam_ke_20 qty_ok, ''03:30-05:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]	
					union all
					select target_date, halte, target_qty_jam_ke_21 qty_ok, ''05:30-06:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]	
					union all
					select target_date, halte, target_qty_jam_ke_22 qty_ok, ''06:30-07:30'' JAM from [ad_dis_rtjn_sum_qty_amount_target]
				) ADDON
				group by JAM, TARGET_DATE, HALTE
			) as [TGT] 
ON [SC].SHIFT_DATE = [TGT].TARGET_DATE 	AND [SC].JAM = [TGT].JAM
LEFT JOIN ad_dis_rtjn_master_actual_masalah [ACT_TRBL] 
ON [SC].SHIFT_DATE = [ACT_TRBL].DATE AND [SC].JAM = [ACT_TRBL].TIME AND [TGT].HALTE = [ACT_TRBL].HALTE
WHERE [SC].SHIFT_DATE = STUFF(STUFF('''+@parm_tgl_shift_date+''',7,0,''-''),5,0,''-'') AND [TGT].HALTE = '+@halte+'
GROUP BY [ACT_TRBL].MASALAH, [ACT_TRBL].ACTION, [TGT].HALTE, [SC].SHIFT_DATE, [SC].JAM, [TGT].TARGET, [SC].ACTUAL, [SC].MP
';
EXEC(@@QUERY);