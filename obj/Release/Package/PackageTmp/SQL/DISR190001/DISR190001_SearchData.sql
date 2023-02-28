DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50)= @START;
DECLARE @@DISPLAY VARCHAR(50)= @DISPLAY;
SET @@QUERY = '';

SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT 
		DISTINCT(A.id_seisan) as ID
		,DENSE_RANK() OVER (ORDER BY A.id_seisan ASC) ROW_NUM
		,LTRIM(A.id_seisan) as ID_SEISAN
		,LTRIM(A.id_hinmoku) as ID_HINMOKU
		--,A.other_lotNo
		,(select top 1 other_lotNo from Z_RT_data_J_kotei where id_seisan = A.id_seisan order by id_kotei desc) as other_lotNo
		,(select top 1 time_sakusei from Z_RT_data_K_seisankeikaku where id_seisan = A.id_seisan order by time_sakusei desc) as time_sakusei
		,(select top 1 time_koshin from Z_RT_data_K_seisankeikaku where id_seisan = A.id_seisan order by time_koshin desc) as time_koshin

	FROM Z_RT_data_J_kotei A
		JOIN Z_RT_master_kotei B ON A.id_kotei = B.id_kotei
		JOIN Z_RT_master_kikai C ON A.id_kikai = C.id_kikai
		JOIN Z_RT_data_K_seisankeikaku D ON A.id_seisan = D.id_seisan
	WHERE 
		1=1	
';
IF(@DMC_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.id_seihin LIKE ''%' + RTRIM(@DMC_CODE) + '%'' ';
	END

IF(@DMC_PART <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND A.id_hinmoku LIKE ''%' + RTRIM(@DMC_PART) + '%'' ';
	END
ELSE
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.id_hinmoku = ''---CLEAR BUTTON---'' ';
	END

IF(@LOT_NO <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND other_lotNo like ''%' + RTRIM(@LOT_NO) + '%'' ';
	END

--IF(@KODE_PROSES <> '')
--    BEGIN
--        SET @@QUERY = @@QUERY + 'AND id_kotei LIKE ''%' + RTRIM(@KODE_PROSES) + '%'' ';
--	END

--IF(@KODE_MESIN <> '')
--    BEGIN
--        SET @@QUERY = @@QUERY + 'AND id_kikai = ''' + RTRIM(@KODE_MESIN) + ''' ';
--	END

--IF(@WAKTU_MULAI <> '')
--    BEGIN
--        SET @@QUERY = @@QUERY + 'AND cast(time_sagyo as date) >= ''' + RTRIM(@WAKTU_MULAI) + ''' ';
--	END

--IF(@WAKTU_SELESAI <> '')
--    BEGIN
--        SET @@QUERY = @@QUERY + 'AND cast(time_kanryo as date) <= ''' + RTRIM(@WAKTU_SELESAI) + ''' ';
--	END

SET @@QUERY = @@QUERY + '
	AND (A.id_hinmoku not like (''%-FG%'') and A.id_hinmoku not like (''%-F-S%'') and A.id_hinmoku not like (''%-G-S%'') and A.id_hinmoku not like (''%-T-S%'') 
	and A.id_hinmoku not like (''%GK%''))
	GROUP BY
		A.id_seisan	
		--,A.id_seihin
		--,A.other_lotNo
		,A.id_hinmoku
		,D.time_sakusei
		,D.time_koshin
	) as TB
';
IF(@@START > 0
   AND @@DISPLAY > 0)
    BEGIN
        SET @@QUERY = @@QUERY + ' WHERE ROW_NUM BETWEEN ' + @@START + ' AND ''' + @@DISPLAY + ''' ';
END;
EXEC (@@QUERY);

