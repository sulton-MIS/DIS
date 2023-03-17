DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;



SET @@QUERY = '';
SET @@QUERY = '
	SELECT 
		COUNT(jenis_asset) as QTY,
		--SUM(TB.harga_satuan) as AMOUNT
		SUBSTRING(format(SUM(TB.harga_satuan), ''C'',''id-ID''), 3, 100) as AMOUNT
	FROM 
		(
		SELECT 
			ROW_NUMBER() OVER (ORDER BY no_asset ASC) ROW_NUM,
			no_asset as ID, 
			*
		FROM 
			[ad_dis_ma_master_asset]		
		WHERE 
			1=1	
';

SET @@QUERY = @@QUERY+ ') AS TB 
		LEFT JOIN ad_dis_ma_lokasi_asset
		ON TB.kd_lokasi = ad_dis_ma_lokasi_asset.kd_lokasi
		LEFT JOIN [ad_dis_ma_request_detail_asset] as req_asset
		ON TB.id_tb_m_req_asset = req_asset.id_tb_m_req_asset
	WHERE 1=1';

IF(@NO_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_asset LIKE ''%'+RTRIM(@NO_ASSET)+'%'' ';
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

IF(@FLG_DISPOSE_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND FLG_DISPOSE_ASSET = '''+RTRIM(@FLG_DISPOSE_ASSET)+''' ';
	END
ELSE
	BEGIN
		SET @@QUERY = @@QUERY + 'AND (FLG_DISPOSE_ASSET is null or flg_dispose_asset=0)';
	END

IF(@JENIS_ASSET <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND jenis_asset LIKE ''%'+RTRIM(@JENIS_ASSET)+'%'' ';
	END

EXEC(@@QUERY);




