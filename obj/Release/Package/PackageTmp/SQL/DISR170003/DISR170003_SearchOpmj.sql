﻿DECLARE @@QUERY VARCHAR(MAX);

SET @@QUERY = '';
SET @@QUERY = '
SELECT 
	ROW_NUMBER() OVER (ORDER BY [SC].HALTE ASC) ROW_NUM,
	[SC].HALTE as ID,
	[SC].HALTE AS HALTE,	
	SUM([SC].[HARI_01]) as ''HARI_01'', SUM([SC].[HARI_02]) as ''HARI_02'', SUM([SC].[HARI_03]) as ''HARI_03'', SUM([SC].[HARI_04]) as ''HARI_04'', SUM([SC].[HARI_05]) as ''HARI_05'', 
	SUM([SC].[HARI_06]) as ''HARI_06'', SUM([SC].[HARI_07]) as ''HARI_07'', SUM([SC].[HARI_08]) as ''HARI_08'', SUM([SC].[HARI_09]) as ''HARI_09'', SUM([SC].[HARI_10]) as ''HARI_10'',
	SUM([SC].[HARI_11]) as ''HARI_11'', SUM([SC].[HARI_12]) as ''HARI_12'', SUM([SC].[HARI_13]) as ''HARI_13'', SUM([SC].[HARI_14]) as ''HARI_14'', SUM([SC].[HARI_15]) as ''HARI_15'',
	SUM([SC].[HARI_16]) as ''HARI_16'', SUM([SC].[HARI_17]) as ''HARI_17'', SUM([SC].[HARI_18]) as ''HARI_18'', SUM([SC].[HARI_19]) as ''HARI_19'', SUM([SC].[HARI_20]) as ''HARI_20'',
	SUM([SC].[HARI_21]) as ''HARI_21'', SUM([SC].[HARI_22]) as ''HARI_22'', SUM([SC].[HARI_23]) as ''HARI_23'', SUM([SC].[HARI_24]) as ''HARI_24'', SUM([SC].[HARI_25]) as ''HARI_25'',
	SUM([SC].[HARI_26]) as ''HARI_26'', SUM([SC].[HARI_27]) as ''HARI_27'', SUM([SC].[HARI_28]) as ''HARI_28'', SUM([SC].[HARI_29]) as ''HARI_29'', SUM([SC].[HARI_30]) as ''HARI_30'',
	SUM([SC].[HARI_31]) as ''HARI_31''
FROM (

		SELECT 	 
			Z_RT_master_kotei.halte AS HALTE,							
			CASE WHEN (RIGHT(shift_date, 2) = ''01'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_01'',
			CASE WHEN (RIGHT(shift_date, 2) = ''02'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_02'',			
			CASE WHEN (RIGHT(shift_date, 2) = ''03'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_03'',
			CASE WHEN (RIGHT(shift_date, 2) = ''04'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_04'',
			CASE WHEN (RIGHT(shift_date, 2) = ''05'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_05'',
			CASE WHEN (RIGHT(shift_date, 2) = ''06'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_06'',
			CASE WHEN (RIGHT(shift_date, 2) = ''07'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_07'',
			CASE WHEN (RIGHT(shift_date, 2) = ''08'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_08'',
			CASE WHEN (RIGHT(shift_date, 2) = ''09'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_09'',
			CASE WHEN (RIGHT(shift_date, 2) = ''10'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_10'',
			CASE WHEN (RIGHT(shift_date, 2) = ''11'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_11'',
			CASE WHEN (RIGHT(shift_date, 2) = ''12'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_12'',
			CASE WHEN (RIGHT(shift_date, 2) = ''13'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_13'',
			CASE WHEN (RIGHT(shift_date, 2) = ''14'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_14'',
			CASE WHEN (RIGHT(shift_date, 2) = ''15'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_15'',
			CASE WHEN (RIGHT(shift_date, 2) = ''16'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_16'',
			CASE WHEN (RIGHT(shift_date, 2) = ''17'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_17'',
			CASE WHEN (RIGHT(shift_date, 2) = ''18'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_18'',
			CASE WHEN (RIGHT(shift_date, 2) = ''19'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_19'',
			CASE WHEN (RIGHT(shift_date, 2) = ''20'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_20'',
			CASE WHEN (RIGHT(shift_date, 2) = ''21'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_21'',
			CASE WHEN (RIGHT(shift_date, 2) = ''22'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_22'',
			CASE WHEN (RIGHT(shift_date, 2) = ''23'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_23'',
			CASE WHEN (RIGHT(shift_date, 2) = ''24'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_24'',
			CASE WHEN (RIGHT(shift_date, 2) = ''25'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_25'',
			CASE WHEN (RIGHT(shift_date, 2) = ''26'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_26'',
			CASE WHEN (RIGHT(shift_date, 2) = ''27'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_27'',
			CASE WHEN (RIGHT(shift_date, 2) = ''28'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_28'',
			CASE WHEN (RIGHT(shift_date, 2) = ''29'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_29'',
			CASE WHEN (RIGHT(shift_date, 2) = ''30'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_30'',
			CASE WHEN (RIGHT(shift_date, 2) = ''31'') THEN CAST((((SUM(ttl_sagyo)) - (ISNULL(SUM(J_PAUSE_WORKING.ttl_pause_working),0)) - (ISNULL(SUM(J_SETTING_AFTER.ttl_setting_after), 0))) / (3600*10)) - (100*1/100) as numeric(36,1)) else 0 end as ''HARI_31''			
		FROM 
			dbo.Z_RT_data_J_kotei 		
		INNER JOIN 
			dbo.Z_RT_master_kikai ON dbo.Z_RT_data_J_kotei.id_kikai = dbo.Z_RT_master_kikai.id_kikai 	
		INNER JOIN 
			dbo.Z_RT_master_kotei ON dbo.Z_RT_data_J_kotei.id_kotei = dbo.Z_RT_master_kotei.id_kotei 		
		LEFT OUTER JOIN (SELECT id_seisan, id_kotei, id_kikai, id_maejotai, bunban, SUM(sbttl_jotai) AS ttl_pause_working 
				FROM dbo.Z_RT_data_J_kikai AS Z_RT_data_J_kikai_1 
				WHERE (id_Remarks <> 6) AND (id_Remarks <> 2) AND (id_Remarks <> 24) 
				AND (id_Remarks <> 23) AND (id_Remarks <> 32) AND (id_Remarks <> 111) AND (id_Remarks <> 19) 
				AND (id_Remarks <> 38) AND (id_Remarks <> 9) AND (id_Remarks <> 10) 
				AND (id_Remarks <> 8) AND (id_Remarks <> 11) AND (id_Remarks <> 5) AND (id_Remarks <> 44) AND (id_Remarks <> 17) 
				AND (id_Remarks <> 45) AND (id_Remarks <> 31) AND (id_Remarks <> 15) AND (id_Remarks <> 129) 
				GROUP BY id_seisan, id_kotei, id_kikai, id_maejotai, bunban 
				HAVING (id_maejotai = 5)) AS J_PAUSE_WORKING 
		ON Z_RT_data_J_kotei.id_seisan = J_PAUSE_WORKING.id_seisan AND Z_RT_data_J_kotei.id_kotei = J_PAUSE_WORKING.id_kotei AND 
		Z_RT_data_J_kotei.id_kikai = J_PAUSE_WORKING.id_kikai AND Z_RT_data_J_kotei.bunban = J_PAUSE_WORKING.bunban 
		LEFT OUTER JOIN (SELECT id_seisan, id_kotei, id_kikai, id_maejotai, bunban, SUM(sbttl_jotai) AS ttl_setting_after 
				FROM dbo.Z_RT_data_J_kikai AS Z_RT_data_J_kikai_1 
				WHERE (id_Remarks = 6) AND (id_Remarks = 2) AND (id_Remarks = 24) 
				GROUP BY id_seisan, id_kotei, id_kikai, id_maejotai, bunban 
				HAVING (id_maejotai = 5)) AS J_SETTING_AFTER 
		ON Z_RT_data_J_kotei.id_seisan = J_SETTING_AFTER.id_seisan AND Z_RT_data_J_kotei.id_kotei = J_SETTING_AFTER.id_kotei AND Z_RT_data_J_kotei.id_kikai = J_SETTING_AFTER.id_kikai AND 
		Z_RT_data_J_kotei.bunban = J_SETTING_AFTER.bunban 			
		WHERE 1=1 
';

IF(@MDATE <> '')
BEGIN
	SET @@QUERY = @@QUERY + 'AND dbo.Z_RT_data_J_kotei.shift_date LIKE ''%'+@MDATE+'%'' ';
END
ELSE
BEGIN
	SET @@QUERY = @@QUERY + 'AND dbo.Z_RT_data_J_kotei.shift_date LIKE ''%'+(SELECT LEFT(CONVERT(varchar, GetDate(),112),6))+'%'' ';
END

SET @@QUERY = @@QUERY + '						 
			AND Z_RT_master_kikai.flg_LosstimeHalte = ''1''
			AND Z_RT_master_kotei.halte != 0
			AND Z_RT_data_J_kotei.flg_sagyokanryo = 1
		GROUP BY 	
			shift_date, halte

) as [SC]

';


SET @@QUERY = @@QUERY + 'GROUP BY [SC].HALTE ORDER BY [SC].HALTE ASC';

EXEC(@@QUERY )