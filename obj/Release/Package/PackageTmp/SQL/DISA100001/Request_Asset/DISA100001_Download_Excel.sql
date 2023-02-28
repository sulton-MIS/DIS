SELECT 
	ROW_NUMBER() OVER (ORDER BY req_asset.no_request_asset ASC) ROW_NUM,
	req_asset.no_request_asset as [no_request_asset],
	LEFT(CONVERT(VARCHAR, req_asset.tgl_request, 120), 20) as tgl_request,
	dt_PR.id_pr as [id_pr],
	LEFT(CONVERT(VARCHAR, dt_PR.tgl, 120), 20) as tgL_pr,
	req_asset.nama_asset as [nama_asset],
	req_asset.pic_request as [pic_request],
	req_asset.dept_request as [dept_request],
	CASE 
		--WHEN req_asset.flg_register_asset = 1 AND ' + @@CNT + '= 1 THEN ''COMPLETED''
		WHEN (req_asset.flg_register_asset = 0 OR req_asset.flg_register_asset IS NULL) AND req_asset.status='CANCEL' THEN 'CANCEL'
		WHEN req_asset.flg_register_asset = 1 AND req_asset.status='COMPLETED' THEN 'COMPLETED'
		WHEN req_asset.flg_register_asset = 1 AND req_asset.status <> 'COMPLETED' THEN 'ASSET IN'
		WHEN dt_PR.status is null THEN req_asset.status
	ELSE
		dt_PR.status
	END as [status_asset]

FROM 
	[192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_ma_request_detail_asset] as req_asset
LEFT JOIN
	[192.168.0.4].[TxDTIPRD].[dbo].[Z_REX_Purchase_Request] as dt_PR
ON
	req_asset.no_request_asset = dt_PR.no_request_asset
WHERE 
	req_asset.no_request_asset LIKE '%' +RTRIM(@NO_REQUEST_ASSET)+ '%'
	AND req_asset.nama_asset LIKE '%' +RTRIM(@NAMA_ASSET)+ '%'
	AND req_asset.pic_request LIKE '%' +RTRIM(@PIC_REQUEST)+ '%'
	AND req_asset.dept_request LIKE '%' +RTRIM(@DEPT_REQUEST)+ '%'
	AND (dt_PR.id_pr LIKE '%' + @ID_PR + '%' OR dt_PR.id_pr IS NULL)