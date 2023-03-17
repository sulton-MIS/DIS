DECLARE @@QUERY VARCHAR(MAX);
Declare @@QUERY_NULL Varchar(MAX);

SET @@QUERY = '';

SET @@QUERY = '
		select 
		top 10
		'+ @parm_tgl_shift_date +' as periode,
	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 08:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 08:29:59'' then amnt_OK else 0 end) end AS jam_0730_sd_0830,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 08:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 09:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 09:29:59'' then amnt_OK else 0 end) end AS jam_0830_sd_0930,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 09:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 10:39:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 10:39:59'' then amnt_OK else 0 end) end AS jam_0930_sd_1040,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 10:40:00'' and '''+@parm_tgl_shift_1_2+''' + '' 12:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 12:29:59'' then amnt_OK else 0 end) end AS jam_1040_sd_1230,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 12:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 13:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 13:29:59'' then amnt_OK else 0 end) end AS jam_1230_sd_1330,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 13:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 14:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 14:29:59'' then amnt_OK else 0 end) end AS jam_1330_sd_1430,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 14:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 15:59:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 15:59:59'' then amnt_OK else 0 end) end AS jam_1430_sd_1600,
';
SET @@QUERY = @@QUERY+ '
	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 16:00:00'' and '''+@parm_tgl_shift_1_2+''' + '' 16:59:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 16:59:59'' then amnt_OK else 0 end) end AS jam_1600_sd_1700,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 17:00:00'' and '''+@parm_tgl_shift_1_2+''' + '' 18:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 18:29:59'' then amnt_OK else 0 end) end AS jam_1700_sd_1830,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 18:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 19:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 19:29:59'' then amnt_OK else 0 end) end AS jam_1830_sd_1930,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 19:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 20:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 20:29:59'' then amnt_OK else 0 end) end AS jam_1930_sd_2030,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 20:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 21:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 21:29:59'' then amnt_OK else 0 end) end AS jam_2030_sd_2130,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 21:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 22:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 22:29:59'' then amnt_OK else 0 end) end AS jam_2130_sd_2230,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 22:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 23:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_1_2+''' + '' 23:29:59'' then amnt_OK else 0 end) end AS jam_2230_sd_2330,
';
SET @@QUERY = @@QUERY+ '
		case when sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 23:30:00'' and '''+@parm_tgl_shift_3+''' + '' 00:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 00:29:59'' then amnt_OK else 0 end) end AS jam_2330_sd_0030,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 00:30:00'' and '''+@parm_tgl_shift_3+''' + '' 01:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 01:29:59'' then amnt_OK else 0 end) end AS jam_0030_sd_0130,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 01:30:00'' and '''+@parm_tgl_shift_3+''' + '' 02:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 02:29:59'' then amnt_OK else 0 end) end AS jam_0130_sd_0230,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 02:30:00'' and '''+@parm_tgl_shift_3+''' + '' 03:29:59'' then amnt_OK else 0 end) = 0 then 0
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 03:29:59'' then amnt_OK else 0 end) end AS jam_0230_sd_0330,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 03:30:00'' and '''+@parm_tgl_shift_3+''' + '' 05:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 05:29:59'' then amnt_OK else 0 end) end AS jam_0330_sd_0530,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 05:30:00'' and '''+@parm_tgl_shift_3+''' + '' 06:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 06:29:59'' then amnt_OK else 0 end) end AS jam_0530_sd_0630,

	    case when sum(case when time_sagyo between '''+@parm_tgl_shift_3+''' + '' 06:30:00'' and '''+@parm_tgl_shift_3+''' + '' 07:29:59'' then amnt_OK else 0 end) = 0 then 0 
			else sum(case when time_sagyo between '''+@parm_tgl_shift_1_2+''' + '' 07:30:00'' and '''+@parm_tgl_shift_3+''' + '' 07:29:59'' then amnt_OK else 0 end) end AS jam_0630_sd_0730,	
		
		sum(amnt_OK) AS akumulasi_aktual

	from
		Z_RT_data_J_kotei A 
		left join Z_RT_master_kotei B on A.id_kotei = B.id_kotei 
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

