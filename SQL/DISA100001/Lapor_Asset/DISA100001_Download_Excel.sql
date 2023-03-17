SELECT
	ROW_NUMBER() OVER (ORDER BY dt_lapor.no_lapor ASC) ROW_NUM,
	dt_lapor.no_lapor,
	dt_lapor.no_asset,
	dt_lapor.status,
	dt_lapor.keterangan,
	dt_lapor.created_by,
	dt_lapor.created_date,
	CASE WHEN dt_lapor.flg_approval_lapor = 1 THEN 'Approved' WHEN dt_lapor.flg_approval_lapor = 0 THEN 'Not Approved' ELSE 'Waiting Approval' END as status_approval
FROM
	ad_dis_ma_lapor_asset as dt_lapor
WHERE
	dt_lapor.no_lapor LIKE '%' + RTRIM(@NO_LAPOR) + '%'
	AND dt_lapor.no_asset LIKE '%' + RTRIM(@NO_ASSET) + '%'