	SELECT 
	   ROW_NUMBER() OVER (ORDER BY B.TRANS_DATE DESC) ROW_NUM,
	   A.ID_TRANS as ID,
       A.ID_TRANS as ID_BUNDLE,
	   FORMAT(A.TRANS_DATE, 'dd-MM-yyyy HH:mm:ss') as TRANS_DATE,
	   A.ID_PRODUKSI,
	   A.ID_PROSES,
	   E.NAME_KOTEI AS NAMA_PROSES,
       A.DMC_CODE,
	   A.LOT_NO,
	   A.SERIAL_NO,
	   A.BERAT_PER_PCS,
	   B.KALI_PRINT as JML_PRINT,
	   C.id_sagyosha as NIK_GAIKAN, 
	   A.pic as OPR_GAIKAN,
	   A.SHF as SHIFT,
	   CASE WHEN B.status_checker IS NULL THEN ' ' ELSE 'Sudah Scan' END as STATUS_CHECKER,
	   D.name_sagyosha as Checker,
	   FORMAT(B.CHECKER_DATE, 'dd-MM-yyyy HH:mm:ss') as CHECKER_DATE,
	   B.KETERANGAN
    FROM dbo.Z_REX_Data_InOut_FG_Detail A
		LEFT JOIN Z_REX_Data_InOut_FG_New B ON B.id_trans = A.id_trans
		LEFT JOIN Z_RT_master_sagyosha C ON B.nik_gaikan = C.id_sagyosha
		LEFT JOIN Z_RT_master_sagyosha D ON B.checker = D.id_sagyosha
		LEFT JOIN Z_RT_master_kotei E ON A.id_proses = E.id_kotei
    WHERE 
		1=1 and A.id_trans like 'B%'
		AND A.ID_TRANS LIKE '%' +RTRIM(@ID_BUNDLE)+ '%'
		AND A.DMC_CODE LIKE '%' +RTRIM(@DMC_CODE)+ '%'
		AND nik_gaikan LIKE '%' +RTRIM(@NIK_GAIKAN)+ '%'
		AND B.opr_gaikan LIKE '%' +RTRIM(@OPR_GAIKAN)+ '%'
		AND A.TRANS_DATE >= '' + @TRANS_DATE+' 00:00:00'
		AND A.TRANS_DATE <= ''+ @TRANS_DATETO +' 23:59:59'