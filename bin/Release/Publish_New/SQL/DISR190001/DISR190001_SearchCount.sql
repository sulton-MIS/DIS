DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;
SET @@QUERY = '';

SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT
		DISTINCT(A.id_seisan) as ID
		,DENSE_RANK() OVER (ORDER BY A.id_seisan ASC) ROW_NUM
		,A.id_seisan as id_seisan
		,a.id_hinmoku
		--,A.id_seihin
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
        SET @@QUERY = @@QUERY + 'AND id_seihin LIKE ''%' + RTRIM(@DMC_CODE) + '%'' ';
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
        SET @@QUERY = @@QUERY + 'AND other_lotNo LIKE ''%' + RTRIM(@LOT_NO) + '%'' ';
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
--        SET @@QUERY = @@QUERY + 'AND cast(time_sakusei as date) <= ''' + RTRIM(@WAKTU_SELESAI) + ''' ';
--	END

SET @@QUERY = @@QUERY+ ' AND (A.id_hinmoku not like (''%-FG%'') and A.id_hinmoku not like (''%-F-S%'') AND A.id_hinmoku not like (''%-G-S%'') AND A.id_hinmoku not like (''%-T-S%'') AND A.id_hinmoku not like (''%GK%''))
						) AS TB';

EXEC(@@QUERY);




--OLD 2022/05/04
--SET @@QUERY = '
--	SELECT ISNULL(max(ROW_NUM),0) FROM 
--	(
--	SELECT
--		DISTINCT(A.id_seisan) as ID
--		,DENSE_RANK() OVER (ORDER BY A.id_seisan ASC) ROW_NUM
--		,A.id_seisan as id_seisan
--		,A.id_seihin
--		--,A.other_lotNo
--		,(select top 1 other_lotNo from Z_RT_data_J_kotei where id_seisan = A.id_seisan order by id_kotei desc) as other_lotNo
--		,(select top 1 time_sakusei from Z_RT_data_K_seisankeikaku where id_seisan = A.id_seisan order by time_sakusei desc) as time_sakusei
--		,(select top 1 time_koshin from Z_RT_data_K_seisankeikaku where id_seisan = A.id_seisan order by time_koshin desc) as time_koshin

--	FROM Z_RT_data_J_kotei A
--		JOIN Z_RT_master_kotei B ON A.id_kotei = B.id_kotei
--		JOIN Z_RT_master_kikai C ON A.id_kikai = C.id_kikai
--		JOIN Z_RT_data_K_seisankeikaku D ON A.id_seisan = D.id_seisan
--	WHERE 
--		1=1	
--';
--IF(@DMC_CODE <> '')
--    BEGIN
--        SET @@QUERY = @@QUERY + 'AND id_seihin LIKE ''%' + RTRIM(@DMC_CODE) + '%'' ';
--	END
--ELSE
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND id_seihin = '''+RTRIM(@DMC_CODE)+''' ';
--	END

--IF(@DMC_PART <> '')
--    BEGIN
--        SET @@QUERY = @@QUERY + 'AND id_hinmoku LIKE ''%' + RTRIM(@DMC_PART) + '%'' ';
--	END

--IF(@LOT_NO <> '')
--    BEGIN
--        SET @@QUERY = @@QUERY + 'AND other_lotNo LIKE ''%' + RTRIM(@LOT_NO) + '%'' ';
--	END

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
--        SET @@QUERY = @@QUERY + 'AND cast(time_sakusei as date) <= ''' + RTRIM(@WAKTU_SELESAI) + ''' ';
--	END

--SET @@QUERY = @@QUERY+ ') AS TB';


--EXEC(@@QUERY);
