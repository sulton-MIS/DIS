
select 
	@periode_tgl_shift_date shift_date2, 
	--A.shift, 
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 07:00:00' and @periode_tgl_shift_1_2 + ' 07:59:59' then id_sagyosha1 end) AS jam_0700_sd_0800,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 08:00:00' and @periode_tgl_shift_1_2 + ' 08:59:59' then id_sagyosha1 end) AS jam_0800_sd_0900,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 09:00:00' and @periode_tgl_shift_1_2 + ' 09:59:59' then id_sagyosha1 end) AS jam_0900_sd_1000,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 10:00:00' and @periode_tgl_shift_1_2 + ' 10:59:59' then id_sagyosha1 end) AS jam_1000_sd_1100,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 11:00:00' and @periode_tgl_shift_1_2 + ' 12:39:59' then id_sagyosha1 end) AS jam_1100_sd_1240,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 12:40:00' and @periode_tgl_shift_1_2 + ' 13:39:59' then id_sagyosha1 end) AS jam_1240_sd_1340,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 13:40:00' and @periode_tgl_shift_1_2 + ' 14:39:59' then id_sagyosha1 end) AS jam_1340_sd_1440,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 14:40:00' and @periode_tgl_shift_1_2 + ' 15:39:59' then id_sagyosha1 end) AS jam_1440_sd_1540,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 15:40:00' and @periode_tgl_shift_1_2 + ' 16:39:59' then id_sagyosha1 end) AS jam_1540_sd_1640,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 16:40:00' and @periode_tgl_shift_1_2 + ' 17:39:59' then id_sagyosha1 end) AS jam_1640_sd_1740,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 17:40:00' and @periode_tgl_shift_1_2 + ' 19:59:59' then id_sagyosha1 end) AS jam_1740_sd_2000,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 20:00:00' and @periode_tgl_shift_1_2 + ' 20:59:59' then id_sagyosha1 end) AS jam_2000_sd_2100,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 21:00:00' and @periode_tgl_shift_1_2 + ' 21:59:59' then id_sagyosha1 end) AS jam_2100_sd_2200,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 22:00:00' and @periode_tgl_shift_1_2 + ' 22:59:59' then id_sagyosha1 end) AS jam_2200_sd_2300,
	count(distinct case when time_kanryo between @periode_tgl_shift_1_2 + ' 23:00:00' and @periode_tgl_shift_1_2 + ' 23:59:59' then id_sagyosha1 end) AS jam_2300_sd_0000,
	count(distinct case when time_kanryo between @periode_tgl_shift_3 + ' 00:00:00' and @periode_tgl_shift_3 + ' 00:59:59' then id_sagyosha1 end) AS jam_0000_sd_0100,
	count(distinct case when time_kanryo between @periode_tgl_shift_3 + ' 01:00:00' and @periode_tgl_shift_3 + ' 01:59:59' then id_sagyosha1 end) AS jam_0100_sd_0200,
	count(distinct case when time_kanryo between @periode_tgl_shift_3 + ' 02:00:00' and @periode_tgl_shift_3 + ' 02:59:59' then id_sagyosha1 end) AS jam_0200_sd_0300,
	count(distinct case when time_kanryo between @periode_tgl_shift_3 + ' 03:00:00' and @periode_tgl_shift_3 + ' 04:59:59' then id_sagyosha1 end) AS jam_0300_sd_0500,
	count(distinct case when time_kanryo between @periode_tgl_shift_3 + ' 05:00:00' and @periode_tgl_shift_3 + ' 05:59:59' then id_sagyosha1 end) AS jam_0500_sd_0600,
	count(distinct case when time_kanryo between @periode_tgl_shift_3 + ' 06:00:00' and @periode_tgl_shift_3 + ' 06:59:59' then id_sagyosha1 end) AS jam_0600_sd_0700,
	count(distinct case when time_kanryo between @periode_tgl_shift_3 + ' 06:59:59' and @periode_tgl_shift_3 + ' 07:29:29' then id_sagyosha1 end) AS stgh8_30_menit
from 
	Z_RT_data_J_kotei A
	left join Z_RT_master_kotei B on A.id_kotei = B.id_kotei
where 
	A.shift_date = @periode_tgl_shift_date
	and A.id_kotei = 5230 -- Proses Gaikan 2x
GROUP BY 
	A.shift_date 
	--,A.shift 
order by A.shift_date
