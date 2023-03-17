DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*,
	TB.ID, 
	TB.id_tb_m_dispose, 
	TB.keterangan as keterangan_dispose,
	TB.created_by,
	TB.updated_by,
	(''Rp.'' + SUBSTRING(format(harga_satuan, ''C'',''id-ID''), 3, 100)) as harga_satuan,
	CASE 
	WHEN reject_created_sign <> '''' THEN status_approval
	WHEN acknowledge_created_sign <> '''' THEN (''ACKNOWLEDGE GM by: '' + TB.acknowledge_created)
	WHEN dept_head_ams_created_sign <> '''' THEN (''APPROVED DEPT. HEAD AMS by: '' + TB.dept_head_ams_created)
	WHEN ams_created_sign <> '''' THEN (''APPROVED AMS by: '' + TB.ams_created) 
	WHEN dept_head_user_created_sign <> '''' THEN (''CHECKED DEPT. HEAD USER by: '' + TB.dept_head_user_created) 
	WHEN updated_by_sign <> '''' THEN (''PREPARED USER by: '' + TB.updated_by)
	ELSE (''PREPARED USER by: '' + TB.created_by) 
	END as status_approval,
	master_asset.STATUS as STATUS_KONDISI
	
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY dt_dispose.created_date ASC) ROW_NUM,
	no_dispose as ID, 
	*
	FROM [ad_dis_ma_dispose_asset] as dt_dispose
	WHERE 1=1	
';

IF(@NO_DISPOSE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_dispose LIKE ''%'+RTRIM(@NO_DISPOSE)+'%'' ';
	END

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
	END

IF(@STATUS_APPROVAL <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND status_approval LIKE ''%'+RTRIM(@STATUS_APPROVAL)+'%'' ';
	END


SET @@QUERY = @@QUERY +') as TB
	LEFT JOIN [ad_dis_ma_master_asset] as master_asset ON TB.no_asset = master_asset.no_asset
	LEFT JOIN [ad_dis_ma_lokasi_asset] lokasi_asset ON master_asset.kd_lokasi = lokasi_asset.kd_lokasi
';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)