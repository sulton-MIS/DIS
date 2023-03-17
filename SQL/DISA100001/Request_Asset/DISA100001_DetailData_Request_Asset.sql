SELECT 
	ROW_NUMBER() OVER (ORDER BY req_asset.no_request_asset ASC) ROW_NUM,
	req_asset.no_request_asset,
	req_asset.tgl_request,
	--dt_PR.id_pr,
	CASE WHEN dt_PR.id_pr is null THEN '' ELSE dt_PR.id_pr END as [id_pr],
	CASE WHEN dt_PR.tujuan is null THEN '' ELSE dt_PR.tujuan END as [tujuan],
	CASE WHEN dt_PR.effect is null THEN '' ELSE dt_PR.effect END as [effect],
	CASE WHEN dt_PR.tgl is null THEN '' ELSE dt_PR.tgl END as tgL_pr,
	req_asset.nama_asset,
	req_asset.keterangan,
	req_asset.pic_request,
	req_asset.dept_request,
	CASE 
		WHEN req_asset.flg_register_asset = 1 THEN 'COMPLETED'
		WHEN dt_PR.status is null THEN req_asset.status
	ELSE
		dt_PR.status
	END as [status_asset]

from 
	[192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_ma_request_detail_asset] as req_asset
	--[192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_ma_request_asset] as req_asset
LEFT JOIN
	[192.168.0.4].[TxDTIPRD].[dbo].[Z_REX_Purchase_Request] as dt_PR
ON
	req_asset.no_request_asset = dt_PR.no_request_asset

WHERE
	req_asset.no_request_asset= @NO_REQUEST_ASSET
	and req_asset.id= @ID


--SELECT 
--	ROW_NUMBER() OVER (ORDER BY req_asset.no_request_asset ASC) ROW_NUM,
--	req_asset.no_request_asset,
--	req_asset.tgl_request,
--	dt_PR.id_pr,
--	dt_PR_detail.nama,
--	dt_PR_detail.spec,
--	dt_PR.tujuan,
--	dt_PR.effect,
--	dt_PR.tgl as tgL_pr,
--	req_asset.nama_asset,
--	--req_asset.qty_asset,
--	req_asset.pic_request,
--	req_asset.dept_request,
--	CASE WHEN dt_PR.status like '%CANCEL%' THEN
--		req_asset.status
--	ELSE
--		dt_PR.status
--	END status_asset

--from 
--	[192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_ma_request_detail_asset] as req_asset
--	--[192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_ma_request_asset] as req_asset
--LEFT JOIN
--	[192.168.0.4].[TxDTIPRD].[dbo].[Z_REX_Purchase_Request] as dt_PR
--ON
--	req_asset.no_request_asset = dt_PR.no_request_asset
--JOIN
--	[192.168.0.4].[TxDTIPRD].[dbo].[Z_REX_PR_Detail] as dt_PR_detail
--ON
--	dt_PR.id_pr = dt_PR_detail.id_pr

--WHERE
--	req_asset.no_request_asset= @NO_REQUEST_ASSET
--	and req_asset.id= @ID
--	and dt_PR.id_PR = @ID_PR