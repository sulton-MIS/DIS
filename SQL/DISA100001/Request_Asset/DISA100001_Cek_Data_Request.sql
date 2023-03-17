SELECT 
		req_asset.no_request_asset as NO_REQUEST
	from 
		[192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_ma_request_detail_asset] as req_asset
	WHERE
		req_asset.no_request_asset LIKE '%'+@NOMOR_URUT_REQUEST+'%' ;