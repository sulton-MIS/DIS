-- START QUERY--
SELECT
	--A.id_seisan id_prod
	--, A.id_hinmoku dmc_part
	--, H.name_hinmokushubetsu part
	--, D.id_kotei kode_proses
	D.name_kotei as NAME_KOTEI
	, C.other_lotNo as OTHER_LOTNO
	,(select top 1 other_lotNo from Z_RT_data_J_kotei where id_seisan = @ID  order by id_kotei desc) as lot --to set value detail
	, C.amnt_OK as amnt_OK
	, C.amnt_NG as amnt_NG
	, C.amnt_PND as amnt_PND
	, C.id_Sagyosha1 as ID_SAGYOSHA1
	, name_sagyosha as NAME_SAGYOSHA1
	, z_inputuser_adm as Z_INPUTUSER_ADM
	--,(SELECT TOP 1 CASE WHEN (id_hinmoku like '%ATP%') THEN SUBSTRING(id_hinmoku, 1, 7) WHEN (id_hinmoku like '%AST%') THEN SUBSTRING(id_hinmoku, 1, 7)
	--WHEN (id_hinmoku like '%TP%') THEN SUBSTRING(id_hinmoku, 1, 11) ELSE id_hinmoku  end as id_seihin FROM Z_RT_data_K_seisankeikaku WHERE id_seisan=@ID) as id_seihin
	,(SELECT TOP 1 A.id_hinmoku FROM Z_RT_data_K_seisankeikaku WHERE id_seisan=@ID) as id_seihin

FROM
	Z_RT_data_K_seisankeikaku A
	--INNER JOIN Z_KOUT B ON B.CODE = A.id_hinmoku AND B.KBAN2 = A.id_kotei AND B.Z_RT_INPUT_FLG = 'Y'
	LEFT OUTER JOIN Z_RT_data_J_kotei C ON C.id_seisan = A.id_seisan AND C.id_kotei = A.id_kotei
	INNER JOIN Z_RT_master_kotei D ON D.id_kotei = A.id_kotei
	--LEFT OUTER JOIN(SELECT   CODE, MAX(KCODE) AS KCODE FROM Z_PRTS GROUP BY CODE) AS E ON E.CODE = A.id_hinmoku
	--LEFT OUTER JOIN Z_PRTS F ON F.CODE = A.id_hinmoku AND F.KCODE = E.KCODE  AND D.flg_increByCavity = 1
	LEFT JOIN Z_RT_master_hinmoku G on A.id_hinmoku = G.id_hinmoku
	--LEFT JOIN Z_RT_master_hinmokushubetsu H on G.id_hinmokushubetsu = H.id_hinmokushubetsu
	LEFT JOIN Z_RT_master_kikai I on C.id_kikai = I.id_kikai
	--left join Z_RT_master_factory J on I.factory = J.factory
	LEFT JOIN Z_RT_master_sagyosha K on C.id_sagyosha1 = K.id_sagyosha
 WHERE 
	 --B.Z_RT_INPUT_FLG = 'Y' AND
	 A.id_kotei not in ('5120', '5290', '5455', '9010', '9020') AND
	 A.id_seisan = @ID
	 GROUP BY 
	A.id_seisan
	, C.id_seihin
	, A.id_hinmoku
	--, H.name_hinmokushubetsu
	, D.id_kotei
	, D.name_kotei
	, C.other_lotNo
	, C.amnt_OK
	, C.amnt_NG
	, C.amnt_PND
	, C.id_sagyosha1
	, K.name_sagyosha
	, C.Z_INPUTUSER_ADM

ORDER BY
	D.id_kotei

--SELECT
--	--A.id_seisan id_prod
--	--, C.id_seihin dmc_code
--	--, A.id_hinmoku dmc_part
--	--, H.name_hinmokushubetsu part
--	--, D.id_kotei kode_proses
--	D.name_kotei as NAME_KOTEI
--	--, C.other_lotNo lot
--	, C.amnt_OK as AMNT_OK
--	, C.amnt_NG as AMNT_NG
--	, C.amnt_PND as AMNT_PND
--	, C.id_Sagyosha1 as ID_SAGYOSHA1
--	, name_sagyosha as NAME_SAGYOSHA1
--	, z_inputuser_adm as Z_INPUTUSER_ADM

--FROM
--	Z_RT_data_K_seisankeikaku A
--	--INNER JOIN Z_KOUT B ON B.CODE = A.id_hinmoku AND B.KBAN2 = A.id_kotei AND B.Z_RT_INPUT_FLG = 'Y'
--	LEFT OUTER JOIN Z_RT_data_J_kotei C ON C.id_seisan = A.id_seisan AND C.id_kotei = A.id_kotei
--	INNER JOIN Z_RT_master_kotei D ON D.id_kotei = A.id_kotei
--	--LEFT OUTER JOIN(SELECT   CODE, MAX(KCODE) AS KCODE FROM Z_PRTS GROUP BY CODE) AS E ON E.CODE = A.id_hinmoku
--	--LEFT OUTER JOIN Z_PRTS F ON F.CODE = A.id_hinmoku AND F.KCODE = E.KCODE  AND D.flg_increByCavity = 1
--	LEFT JOIN Z_RT_master_hinmoku G on A.id_hinmoku = G.id_hinmoku
--	--LEFT JOIN Z_RT_master_hinmokushubetsu H on G.id_hinmokushubetsu = H.id_hinmokushubetsu
--	LEFT JOIN Z_RT_master_kikai I on C.id_kikai = I.id_kikai
--	--left join Z_RT_master_factory J on I.factory = J.factory
--	LEFT JOIN Z_RT_master_sagyosha K on C.id_sagyosha1 = K.id_sagyosha
-- WHERE 
--	 --B.Z_RT_INPUT_FLG = 'Y' AND
--	 A.id_kotei not in ('5120', '5290', '5455', '9010', '9020') AND
--	 A.id_seisan = @ID
--	 GROUP BY 
--	A.id_seisan
--	, C.id_seihin
--	, A.id_hinmoku
--	--, H.name_hinmokushubetsu
--	, D.id_kotei
--	, D.name_kotei
--	, C.other_lotNo
--	, C.amnt_OK
--	, C.amnt_NG
--	, C.amnt_PND
--	, C.id_sagyosha1
--	, K.name_sagyosha
--	, C.Z_INPUTUSER_ADM

--ORDER BY
--	D.id_kotei
 
-- END QUERY-- 
 
