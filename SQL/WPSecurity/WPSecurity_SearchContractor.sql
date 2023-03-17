DECLARE @@QUERY VARCHAR(MAX);

SET @@QUERY = '';
SET @@QUERY = '
SELECT 
	ROW_NUMBER() OVER (ORDER BY [SC].NIK ASC) ROW_NUM,
	[SC].NIK as ID,
	[SC].NIK as NIK,
	[SC].NAMA as NAMA, 
	[SC].GRP as GRP,
	SUM([SC].[HARI_01]) as ''HARI_01'', SUM([SC].[HARI_02]) as ''HARI_02'', SUM([SC].[HARI_03]) as ''HARI_03'', SUM([SC].[HARI_04]) as ''HARI_04'', SUM([SC].[HARI_05]) as ''HARI_05'', 
	SUM([SC].[HARI_06]) as ''HARI_06'', SUM([SC].[HARI_07]) as ''HARI_07'', SUM([SC].[HARI_08]) as ''HARI_08'', SUM([SC].[HARI_09]) as ''HARI_09'', SUM([SC].[HARI_10]) as ''HARI_10'',
	SUM([SC].[HARI_11]) as ''HARI_11'', SUM([SC].[HARI_12]) as ''HARI_12'', SUM([SC].[HARI_13]) as ''HARI_13'', SUM([SC].[HARI_14]) as ''HARI_14'', SUM([SC].[HARI_15]) as ''HARI_15'',
	SUM([SC].[HARI_16]) as ''HARI_16'', SUM([SC].[HARI_17]) as ''HARI_17'', SUM([SC].[HARI_18]) as ''HARI_18'', SUM([SC].[HARI_19]) as ''HARI_19'', SUM([SC].[HARI_20]) as ''HARI_20'',
	SUM([SC].[HARI_21]) as ''HARI_21'', SUM([SC].[HARI_22]) as ''HARI_22'', SUM([SC].[HARI_23]) as ''HARI_23'', SUM([SC].[HARI_24]) as ''HARI_24'', SUM([SC].[HARI_25]) as ''HARI_25'',
	SUM([SC].[HARI_16]) as ''HARI_26'', SUM([SC].[HARI_27]) as ''HARI_27'', SUM([SC].[HARI_28]) as ''HARI_28'', SUM([SC].[HARI_29]) as ''HARI_29'', SUM([SC].[HARI_30]) as ''HARI_30'',
	SUM([SC].[HARI_31]) as ''HARI_31''
FROM (

		SELECT 	 
			dbo.Z_RT_master_sagyosha.id_sagyosha AS NIK,			
			dbo.Z_RT_master_sagyosha.name_sagyosha AS NAMA,
			dbo.Z_RT_master_sagyosha.grp AS GRP,
			CASE WHEN (RIGHT(shift_date, 2) = ''01'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_01'',
			CASE WHEN (RIGHT(shift_date, 2) = ''02'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_02'',
			CASE WHEN (RIGHT(shift_date, 2) = ''03'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_03'',
			CASE WHEN (RIGHT(shift_date, 2) = ''04'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_04'',
			CASE WHEN (RIGHT(shift_date, 2) = ''05'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_05'',
			CASE WHEN (RIGHT(shift_date, 2) = ''06'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_06'',
			CASE WHEN (RIGHT(shift_date, 2) = ''07'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_07'',
			CASE WHEN (RIGHT(shift_date, 2) = ''08'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_08'',
			CASE WHEN (RIGHT(shift_date, 2) = ''09'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_09'',
			CASE WHEN (RIGHT(shift_date, 2) = ''10'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_10'',
			CASE WHEN (RIGHT(shift_date, 2) = ''11'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_11'',
			CASE WHEN (RIGHT(shift_date, 2) = ''12'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_12'',
			CASE WHEN (RIGHT(shift_date, 2) = ''13'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_13'',
			CASE WHEN (RIGHT(shift_date, 2) = ''14'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_14'',
			CASE WHEN (RIGHT(shift_date, 2) = ''15'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_15'',
			CASE WHEN (RIGHT(shift_date, 2) = ''16'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_16'',
			CASE WHEN (RIGHT(shift_date, 2) = ''17'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_17'',
			CASE WHEN (RIGHT(shift_date, 2) = ''18'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_18'',
			CASE WHEN (RIGHT(shift_date, 2) = ''19'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_19'',
			CASE WHEN (RIGHT(shift_date, 2) = ''20'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_20'',
			CASE WHEN (RIGHT(shift_date, 2) = ''21'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_21'',
			CASE WHEN (RIGHT(shift_date, 2) = ''22'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_22'',
			CASE WHEN (RIGHT(shift_date, 2) = ''23'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_23'',
			CASE WHEN (RIGHT(shift_date, 2) = ''24'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_24'',
			CASE WHEN (RIGHT(shift_date, 2) = ''25'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_25'',
			CASE WHEN (RIGHT(shift_date, 2) = ''26'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_26'',
			CASE WHEN (RIGHT(shift_date, 2) = ''27'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_27'',
			CASE WHEN (RIGHT(shift_date, 2) = ''28'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_28'',
			CASE WHEN (RIGHT(shift_date, 2) = ''29'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_29'',
			CASE WHEN (RIGHT(shift_date, 2) = ''30'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_30'',
			CASE WHEN (RIGHT(shift_date, 2) = ''31'') THEN SUM(amnt_OK) + SUM(amnt_NG) + SUM(amnt_PND) else 0 end AS ''HARI_31''			
		FROM 
			dbo.Z_RT_data_J_kotei 
		INNER JOIN 
			dbo.Z_RT_data_J_sagyosha ON dbo.Z_RT_data_J_kotei.id_seisan = dbo.Z_RT_data_J_sagyosha.id_seisan 
			AND dbo.Z_RT_data_J_kotei.id_kotei = dbo.Z_RT_data_J_sagyosha.id_kotei AND dbo.Z_RT_data_J_kotei.id_kikai = dbo.Z_RT_data_J_sagyosha.id_kikai 
			AND dbo.Z_RT_data_J_kotei.bunban = dbo.Z_RT_data_J_sagyosha.bunban 
		INNER JOIN 
			dbo.Z_RT_master_sagyosha ON dbo.Z_RT_data_J_sagyosha.id_sagyosha = dbo.Z_RT_master_sagyosha.id_sagyosha 
		INNER JOIN 
			dbo.Z_RT_master_kotei ON dbo.Z_RT_data_J_kotei.id_kotei = dbo.Z_RT_master_kotei.id_kotei 
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
			AND Z_RT_master_kotei.name_kotei in (
			''Double Sheet'',
			''Hariawase'',
			''Hariawase Awal'',
			''Hariawase Polycarbon'',
			''Pasang Ag Protection Sht'',
			''Pasang Anti Bacteri Film'',
			''Pasang EMI Shield'',
			''Pasang Overlay'',
			''Pasang Smoke Sheet'',
			''Pasang UV Cut Film'')
		GROUP BY 	
			Z_RT_master_sagyosha.id_sagyosha, Z_RT_master_sagyosha.name_sagyosha, Z_RT_master_sagyosha.grp, shift_date

) as [SC]
WHERE 1=1

';

IF(@NIK <> '')
BEGIN
	SET @@QUERY = @@QUERY + 'AND [SC].NIK LIKE ''%'+@NIK+'%'' ';
END

IF(@NAMA <> '')
BEGIN
	SET @@QUERY = @@QUERY + 'AND [SC].NAMA LIKE ''%'+@NAMA+'%'' ';
END

IF(@GRP <> '')
BEGIN
	SET @@QUERY = @@QUERY + 'AND [SC].GRP LIKE ''%'+@GRP+'%'' ';
END

SET @@QUERY = @@QUERY + 'GROUP BY [SC].NIK, [SC].NAMA, [SC].GRP';

EXEC(@@QUERY )