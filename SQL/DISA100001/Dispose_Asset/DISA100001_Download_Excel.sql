SELECT
	ROW_NUMBER() OVER (ORDER BY dt_dispose.no_dispose ASC) ROW_NUM,
	dt_dispose.no_dispose,
	dt_dispose.no_asset,
	dt_dispose.status_approval,
	dt_dispose.keterangan,
	dt_dispose.created_by,
	dt_dispose.created_date,
	CASE WHEN dt_dispose.updated_by= '' THEN '-' ELSE dt_dispose.updated_by END updated_by,
	dt_dispose.updated_date,
	--CASE WHEN CAST(dt_dispose.updated_date AS datetime) IS NULL  THEN NULL ELSE CAST(dt_dispose.updated_date AS datetime) END updated_date,
	CASE WHEN dt_dispose.dept_head_user_created= '' THEN '-' ELSE dt_dispose.dept_head_user_created END dept_head_user_created,
	dt_dispose.dept_head_user_created_date,
	CASE WHEN dt_dispose.ams_created= '' THEN '-' ELSE dt_dispose.ams_created END ams_created,
	dt_dispose.ams_created_date,
	CASE WHEN dt_dispose.dept_head_ams_created= '' THEN '-' ELSE dt_dispose.dept_head_ams_created END dept_head_ams_created,
	dt_dispose.dept_head_ams_created_date,
	CASE WHEN dt_dispose.acknowledge_created= '' THEN '-' ELSE dt_dispose.acknowledge_created END acknowledge_created,
	dt_dispose.acknowledge_created_date
FROM
	ad_dis_ma_dispose_asset as dt_dispose
WHERE
	dt_dispose.no_dispose LIKE '%' + RTRIM(@NO_DISPOSE) + '%'
	AND dt_dispose.no_asset LIKE '%' + RTRIM(@NO_ASSET) + '%'
	AND dt_dispose.status_approval LIKE '%' + RTRIM(@STATUS_APPROVAL) + '%'