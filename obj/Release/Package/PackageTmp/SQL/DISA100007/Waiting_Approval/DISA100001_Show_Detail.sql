SELECT 
	*
	,(select convert(varchar, DATEADD(year, 0, tgl_register), 105)) AS TGL_REGISTER
    ,(select convert(varchar, estimasi_dispose, 105)) AS estimasi_dispose,(select convert(varchar, created_date, 113)) as CREATED_DATE
	,(select convert(varchar, updated_date, 113)) as UPDATED_DATE
	,(select convert(varchar, dispose_date, 113)) as DISPOSE_DATE

FROM 
	ad_dis_dc_master_document
WHERE 
	no_document = @ID
