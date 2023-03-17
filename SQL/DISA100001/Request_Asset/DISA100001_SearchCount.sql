﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT 
	ROW_NUMBER() OVER (ORDER BY req_asset.no_request_asset ASC) ROW_NUM,
	req_asset.id_tb_m_req_asset as [ID], 
	req_asset.no_request_asset as [no_request_asset],
	req_asset.created_date as [tgl_request],
	dt_PR.id_pr as [id_pr],
	dt_PR.tgl as [tgL_pr],
	req_asset.nama_asset as [nama_asset],
	req_asset.pic_request as [pic_request],
	req_asset.dept_request as [dept_request],
	dt_XSACT.no_mr as [NO_MR],
	CASE 
		WHEN (req_asset.flg_register_asset = 0 OR req_asset.flg_register_asset IS NULL) AND req_asset.status=''CANCEL'' THEN ''CANCEL''
		WHEN req_asset.flg_register_asset = 1 AND req_asset.status=''COMPLETED'' THEN ''COMPLETED''
		WHEN req_asset.flg_register_asset = 1 AND req_asset.status <> ''COMPLETED''  THEN ''ASSET IN''
		WHEN (dt_XSACT.no_mr IS NOT NULL AND dt_XSACT.no_mr <> '''') THEN ''RECEIVED GOODS''
		WHEN dt_PR.status is null THEN req_asset.status
	ELSE
		dt_PR.status
	END as [status_asset]

	FROM 
		[192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_ma_request_detail_asset] as req_asset
		LEFT JOIN [192.168.0.4].[TxDTIPRD].[dbo].[Z_REX_Purchase_Request] as dt_PR ON req_asset.no_request_asset = dt_PR.no_request_asset
		LEFT JOIN [192.168.0.4].[TxDTIPRD].[dbo].[XSLIP] as dt_XSLIP ON dt_PR.id_pr = dt_XSLIP.pr_number
	LEFT JOIN [192.168.0.4].[TxDTIPRD].[dbo].[XSACT] as dt_XSACT ON dt_XSLIP.porder = dt_XSACT.porder
	WHERE 1=1	

';

IF(@NO_REQUEST_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND req_asset.NO_REQUEST_ASSET LIKE ''%'+RTRIM(@NO_REQUEST_ASSET)+'%'' ';
	END

IF(@NAMA_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND req_asset.nama_asset  LIKE ''%'+RTRIM(@NAMA_ASSET)+'%'' ';
	END

IF(@ID_PR <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND dt_PR.id_pr  LIKE ''%'+@ID_PR+'%'' ';
	END

IF(@PIC_REQUEST <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND req_asset.pic_request  LIKE ''%'+@PIC_REQUEST+'%'' ';
	END
	
IF(@DEPT_REQUEST <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND req_asset.dept_request  LIKE ''%'+@DEPT_REQUEST+'%'' ';
	END

--IF(@TGL_REQUEST <> '')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND TGL_REQUEST  = '''+RTRIM(@TGL_REQUEST)+''' ';
--	END

--IF(@ID_PR <> '')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND nama_asset LIKE ''%'+RTRIM(@ID_PR)+'%'' ';
--	END

--IF(@TGL_PR <> '')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND merek LIKE ''%'+RTRIM(@TGL_PR)+'%'' ';
--	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

