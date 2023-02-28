SELECT
	ROW_NUMBER() OVER (ORDER BY dt_lapor.no_lapor ASC) ROW_NUM,
	dt_lapor.no_lapor,
	dt_lapor.no_asset,
	master_asset.nama_asset,
	dt_lapor.status,
	dt_lapor.keterangan,
	master_asset.nama_user,
	master_asset.dept_user,
	dt_lapor.created_by,
	dt_lapor.created_date,
	CASE WHEN dt_lapor.flg_approval_lapor = 1 THEN 'Approved' WHEN dt_lapor.flg_approval_lapor = 0 THEN 'Not Approved' ELSE 'Waiting Approval' END as status_approval
FROM
	ad_dis_ma_lapor_asset as dt_lapor
	LEFT JOIN [ad_dis_ma_master_asset] as master_asset ON dt_lapor.no_asset = master_asset.no_asset
WHERE
	dt_lapor.no_lapor LIKE '%' + RTRIM(@NO_LAPOR) + '%'
	AND dt_lapor.no_asset LIKE '%' + RTRIM(@NO_ASSET) + '%'
	AND master_asset.nama_user LIKE '%' +RTRIM(@NAMA_USER)+ '%' 
	AND master_asset.dept_user LIKE '%' +RTRIM(@DEPARTMENT_USER)+ '%' 