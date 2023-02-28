SELECT 
	*
	,(select convert(varchar, created_date, 113)) as CREATED_DATE
	,(select convert(varchar, updated_date, 113)) as UPDATED_DATE
	,(select convert(varchar, dispose_date, 113)) as DISPOSE_DATE
	,(select convert(varchar, DATEADD(year, 0, tgl_register), 105)) AS TGL_REGISTER
    ,(select convert(varchar, estimasi_dispose, 105)) AS estimasi_dispose
FROM 
	ad_dis_dc_master_document

WHERE
	nama_document = RTRIM(@NAMA_DOKUMEN)  
	AND label_rak LIKE '%' + RTRIM(@LABEL_RAK) + '%'
	AND rak LIKE '%' + RTRIM(@NO_RAK) + '%'
	AND department LIKE '%' + RTRIM(@DEPARTMENT) + '%'
	AND bagian LIKE '%' + RTRIM(@BAGIAN) + '%'
	AND (flg_dispose IS NULL OR flg_dispose = 0)
	--AND flg_delete <> 1
	--nama_document LIKE '%' + @NAMA_DOKUMEN + '%'
