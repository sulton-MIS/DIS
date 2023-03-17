DECLARE @@QUERY VARCHAR(MAX);
Declare @@QUERY_NULL Varchar(MAX);

SET @@QUERY = '';
SET @@QUERY = '
		select 		
		'+ @parm_tgl_shift_date +' as periode,
	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 08:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 08:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_1)*100 as decimal(18,1)) else 0 end) end AS jam_0730_sd_0830,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 08:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 09:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 09:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_2)*100 as decimal(18,1)) else 0 end) end AS jam_0830_sd_0930,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 09:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 10:39:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 10:39:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_3)*100 as decimal(18,1)) else 0 end) end AS jam_0930_sd_1040,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 10:40:00'' and '''+@parm_tgl_shift_1_2+''' + '' 12:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 12:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_4)*100 as decimal(18,1)) else 0 end) end AS jam_1040_sd_1230,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 12:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 13:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 13:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_5)*100 as decimal(18,1)) else 0 end) end AS jam_1230_sd_1330,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 13:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 14:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 14:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_6)*100 as decimal(18,1)) else 0 end) end AS jam_1330_sd_1430,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 14:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 15:59:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 15:59:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_7)*100 as decimal(18,1)) else 0 end) end AS jam_1430_sd_1600,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 16:00:00'' and '''+@parm_tgl_shift_1_2+''' + '' 16:59:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 16:59:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_8)*100 as decimal(18,1)) else 0 end) end AS jam_1600_sd_1700,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 17:00:00'' and '''+@parm_tgl_shift_1_2+''' + '' 18:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 18:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_9)*100 as decimal(18,1)) else 0 end) end AS jam_1700_sd_1830,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 18:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 19:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 19:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_10)*100 as decimal(18,1)) else 0 end) end AS jam_1830_sd_1930,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 19:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 20:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 20:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_11)*100 as decimal(18,1)) else 0 end) end AS jam_1930_sd_2030,
';
SET @@QUERY = @@QUERY + '
	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 20:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 21:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 21:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_12)*100 as decimal(18,1)) else 0 end) end AS jam_2030_sd_2130,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 21:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 22:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 22:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_13)*100 as decimal(18,1)) else 0 end) end AS jam_2130_sd_2230,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 22:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 23:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 23:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_14)*100 as decimal(18,1)) else 0 end) end AS jam_2230_sd_2330,

		case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 23:30:00'' and '''+@parm_tgl_shift_3+''' + '' 00:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 00:29:59'' then CAST((amnt_OK/NULLIF(TGT.target_qty_jam_ke_15_16_istirahat,0))*100 as decimal(18,1)) else 0 end) end AS jam_2330_sd_0030,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 00:30:00'' and '''+@parm_tgl_shift_3+''' + '' 01:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 01:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_17)*100 as decimal(18,1)) else 0 end) end AS jam_0030_sd_0130,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 01:30:00'' and '''+@parm_tgl_shift_3+''' + '' 02:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 02:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_18)*100 as decimal(18,1)) else 0 end) end AS jam_0130_sd_0230,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 02:30:00'' and '''+@parm_tgl_shift_3+''' + '' 03:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 03:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_19)*100 as decimal(18,1)) else 0 end) end AS jam_0230_sd_0330,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 03:30:00'' and '''+@parm_tgl_shift_3+''' + '' 05:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 05:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_20)*100 as decimal(18,1)) else 0 end) end AS jam_0330_sd_0530,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 05:30:00'' and '''+@parm_tgl_shift_3+''' + '' 06:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 06:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_21)*100 as decimal(18,1)) else 0 end) end AS jam_0530_sd_0630,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 06:30:00'' and '''+@parm_tgl_shift_3+''' + '' 07:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 07:29:59'' then CAST((amnt_OK/TGT.target_qty_jam_ke_22)*100 as decimal(18,1)) else 0 end) end AS jam_0630_sd_0730,	
		
		sum(amnt_OK) AS akumulasi_aktual

	from
		Z_RT_data_J_kotei A 
		left join Z_RT_master_kotei B on A.id_kotei = B.id_kotei 
';
SET @@QUERY = @@QUERY + '

		left join (
						select 
						target_date		
						,target_qty_jam_ke_1 
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 as target_qty_jam_ke_2
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 as target_qty_jam_ke_3
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4  as target_qty_jam_ke_4
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 as target_qty_jam_ke_5
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 as target_qty_jam_ke_6
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 as target_qty_jam_ke_7
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 as target_qty_jam_ke_8
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 as target_qty_jam_ke_9
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 as target_qty_jam_ke_10
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 as target_qty_jam_ke_11
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 as target_qty_jam_ke_12
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 + target_qty_jam_ke_13 as target_qty_jam_ke_13
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 + target_qty_jam_ke_13 + target_qty_jam_ke_14 as target_qty_jam_ke_14
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 + target_qty_jam_ke_13 + target_qty_jam_ke_14 + target_qty_jam_ke_15_16_istirahat as target_qty_jam_ke_15_16_istirahat
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 + target_qty_jam_ke_13 + target_qty_jam_ke_14 + target_qty_jam_ke_15_16_istirahat + target_qty_jam_ke_17 as target_qty_jam_ke_17
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 + target_qty_jam_ke_13 + target_qty_jam_ke_14 + target_qty_jam_ke_15_16_istirahat + target_qty_jam_ke_17 + target_qty_jam_ke_18 as target_qty_jam_ke_18
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 + target_qty_jam_ke_13 + target_qty_jam_ke_14 + target_qty_jam_ke_15_16_istirahat + target_qty_jam_ke_17 + target_qty_jam_ke_18 + target_qty_jam_ke_19 as target_qty_jam_ke_19
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 + target_qty_jam_ke_13 + target_qty_jam_ke_14 + target_qty_jam_ke_15_16_istirahat + target_qty_jam_ke_17 + target_qty_jam_ke_18 + target_qty_jam_ke_19 + target_qty_jam_ke_20 as target_qty_jam_ke_20
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 + target_qty_jam_ke_13 + target_qty_jam_ke_14 + target_qty_jam_ke_15_16_istirahat + target_qty_jam_ke_17 + target_qty_jam_ke_18 + target_qty_jam_ke_19 + target_qty_jam_ke_20 + target_qty_jam_ke_21 as target_qty_jam_ke_21
						,target_qty_jam_ke_1 + target_qty_jam_ke_2 + target_qty_jam_ke_3 + target_qty_jam_ke_4 + target_qty_jam_ke_5 + target_qty_jam_ke_6 + target_qty_jam_ke_7 + target_qty_jam_ke_8 + target_qty_jam_ke_9 + target_qty_jam_ke_10 + target_qty_jam_ke_11 + target_qty_jam_ke_12 + target_qty_jam_ke_13 + target_qty_jam_ke_14 + target_qty_jam_ke_15_16_istirahat + target_qty_jam_ke_17 + target_qty_jam_ke_18 + target_qty_jam_ke_19 + target_qty_jam_ke_20 + target_qty_jam_ke_21 + target_qty_jam_ke_22 as target_qty_jam_ke_22
						,target_qty_jam_ke_1	+ target_qty_jam_ke_2	+ target_qty_jam_ke_3	+ target_qty_jam_ke_4	+ target_qty_jam_ke_5	+ target_qty_jam_ke_6	+ target_qty_jam_ke_7	+ target_qty_jam_ke_8	+ target_qty_jam_ke_9	+ target_qty_jam_ke_10	+ target_qty_jam_ke_11	+ target_qty_jam_ke_12	+ target_qty_jam_ke_13	+ target_qty_jam_ke_14	+ target_qty_jam_ke_15_16_istirahat	+ target_qty_jam_ke_17	+ target_qty_jam_ke_18	+ target_qty_jam_ke_19	+ target_qty_jam_ke_20	+ target_qty_jam_ke_21	+ target_qty_jam_ke_22 as akumulasi_target
					from 
						[192.168.0.10].[TxDTIPRD].[DBO].ad_dis_rtjn_sum_qty_amount_target
					where halte = ''' +@halte+''' 
				  ) AS TGT
         ON A.shift_date = TGT.target_date
	where 
		1=1 
';
SET @@QUERY_NULL = @@QUERY + 'and A.id_kotei = 9999' ;
SET @@QUERY = @@QUERY + 'and A.shift_date = '+ @parm_tgl_shift_date +''  + @parm_filter_output_halte ;

IF (COUNT(@@QUERY) > 0)
	BEGIN 
		EXEC(@@QUERY);
	END
ELSE
	BEGIN
		EXEC(@@QUERY_NULL);
	END



