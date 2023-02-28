	SELECT 
	   ROW_NUMBER() OVER (ORDER BY A.TRANS_DATE DESC) ROW_NUM,
       A.ID_TRANS as ID_BUNDLE,
	   FORMAT(A.TRANS_DATE, 'dd-MM-yyyy hh:mm:ss') as TRANS_DATE,
       A.DMC_CODE,
	   A.QTY_STD as QTY_BUNDLE_STD,
	   A.QTY as QTY_BUNDLE_ACT,
	   A.berat_bundle_std as BERAT_BUNDLE_STD,
	   A.berat_bundle_act as BERAT_BUNDLE_ACT,
	   A.berat_pcs_std as BERAT_PCS_STD,
	   A.AVG_BERAT_PCS,
	   A.JENIS_LOTTO,
	   A.STATUS_LOTTO,
	   A.KALI_PRINT,
	   A.NIK_GAIKAN,
	   A.OPR_GAIKAN,
	   A.SHF,
	   CASE WHEN A.STATUS_CHECKER IS NULL THEN '' ELSE 'Sudah Scan' END AS STATUS_CHECKER,
	   B.NAME_SAGYOSHA AS CHECKER,
	   FORMAT(A.CHECKER_DATE, 'dd-MM-yyyy hh:mm:ss') as CHECKER_DATE,
	   A.INPUT_ADM,
	   FORMAT(A.INPUT_DATE, 'dd-MM-yyyy hh:mm:ss') as INPUT_DATE,
	   A.UPDATE_ADM,
	   FORMAT(A.UPDATE_DATE, 'dd-MM-yyyy hh:mm:ss') as UPDATE_DATE,
	   A.KETERANGAN
    FROM dbo.Z_REX_Data_InOut_FG_New A
		LEFT JOIN Z_RT_master_sagyosha B ON A.checker = B.id_sagyosha
    WHERE 
		1=1 and id_trans like 'B%'
		AND A.ID_TRANS LIKE '%' +RTRIM(@ID_BUNDLE)+ '%'
		AND A.DMC_CODE LIKE '%' +RTRIM(@DMC_CODE)+ '%'
		AND nik_gaikan LIKE '%' +RTRIM(@NIK_GAIKAN)+ '%'
		AND A.opr_gaikan LIKE '%' +RTRIM(@OPR_GAIKAN)+ '%'
		AND A.TRANS_DATE >= '' + @TRANS_DATE+' 00:00:00'
		AND A.TRANS_DATE <= ''+ @TRANS_DATETO +' 23:59:59'
