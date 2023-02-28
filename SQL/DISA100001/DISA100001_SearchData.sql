DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*, 
	--format(harga_satuan, ''C'',''id-ID'') as harga_satuan,
	SUBSTRING(format(harga_satuan, ''C'',''id-ID''), 3, 100) as harga_satuan,
	SUBSTRING(format(total, ''C'',''id-ID''), 3, 100) as total,
	CASE WHEN FLG_LABEL_ASSET = 1 then ''Sudah label'' ELSE ''Belum Label'' END as FLG_LABEL_ASSET,
	CASE WHEN FLG_DISPOSE_ASSET = 1 then ''Dispose'' WHEN FLG_DISPOSE_ASSET = 0 then ''Non-Dispose''  ELSE ''Non-Dispose'' END as FLG_DISPOSE_ASSET,
	LEFT(CONVERT(VARCHAR, tgl_bc, 120), 10) as tgl_bc,
	LEFT(CONVERT(VARCHAR, tgl_regist, 120), 10) as tgl_regist,
	LEFT(CONVERT(VARCHAR, tgl_dispose_asset, 120), 20) as tgl_dispose

 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY id_tb_m_asset ASC) ROW_NUM,
	no_asset as ID, 
	*
	FROM ad_dis_ma_master_asset		
	WHERE 1=1	
';

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
	END
IF(@FLG_DISPOSE_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND FLG_DISPOSE_ASSET = '''+RTRIM(@FLG_DISPOSE_ASSET)+''' ';
	END
ELSE
	BEGIN
		SET @@QUERY = @@QUERY + 'AND (FLG_DISPOSE_ASSET is null or flg_dispose_asset=0)';
	END

IF(@NAMA_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND nama_asset LIKE ''%'+RTRIM(@NAMA_ASSET)+'%'' ';
	END
IF(@MEREK <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND merek LIKE ''%'+RTRIM(@MEREK)+'%'' ';
	END
IF(@SUPPLIER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND supplier LIKE ''%'+RTRIM(@SUPPLIER)+'%'' ';
	END

SET @@QUERY = @@QUERY +' ) as TB
	JOIN ad_dis_ma_lokasi_asset
	ON TB.kd_lokasi = ad_dis_ma_lokasi_asset.kd_lokasi
';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)