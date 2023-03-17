DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@NO_URUT VARCHAR(MAX) = '';

BEGIN TRY
	IF(@NAMA_ASSET <> 'null') AND (@JENIS_ASSET <> 'null') AND (@KATEGORI_ASSET <> 'null') AND (@KD_LOKASI <> 'null') AND (@TAHUN <> 'null')AND (@STATUS <> 'null')
	BEGIN
	SELECT
	@@NO_URUT =
	CASE WHEN 
		LEN(@NO_ASSET) < 11 THEN CAST(SUBSTRING (LTRIM(@NO_ASSET), 10, 12) as int)
	ELSE 
		 CAST(SUBSTRING (LTRIM(@NO_ASSET), 11, 12) as int) 
	END
	FROM 
		[ad_dis_ma_master_asset]
	WHERE 
		no_asset = @NO_ASSET

	UPDATE ad_dis_ma_master_asset 
	SET
		no_asset=LTRIM(@TAHUN + '.' + @JENIS_ASSET + '.' + @KATEGORI_ASSET + '.' + @@NO_URUT),
		nama_asset=LTRIM(@NAMA_ASSET),
		nama_foto=LTRIM(@NAMA_FOTO),
		merek=LTRIM(@MEREK),
		tipe=LTRIM(@TIPE),
		supplier=LTRIM(@SUPPLIER),
		tahun=LTRIM(@TAHUN),
		qty=LTRIM(@QTY),
		harga_satuan=LTRIM(@HARGA_SATUAN),
		jenis_asset=LTRIM(@JENIS_ASSET),
		kategori_asset=LTRIM(@KATEGORI_ASSET),
		pic_beli=LTRIM(@PIC_BELI),
		dept_user=LTRIM(@DEPT_USER),
		nama_user=LTRIM(@NAMA_USER),
		kd_lokasi=LTRIM(@KD_LOKASI),
		halte =LTRIM(@HALTE),
		jenis_doc=LTRIM(@JENIS_DOC),
		no_bc=LTRIM(@NO_BC),
		tgl_bc=LTRIM(@TGL_BC),
		tgl_regist=LTRIM(@TGL_REGIST),
		[status]=LTRIM(@STATUS),
		flg_label_asset=LTRIM(@FLG_LABEL_ASSET)
		

	WHERE no_asset= @NO_ASSET
		
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
	END ELSE
	BEGIN
		SET @@CHK = 'FALSE';
		SET @@ERR = 'DATA CAN NOT SET NULL! PLEASE CHECK AGAIN BEFORE UPDATING!';	
	END 
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_ma_master_asset: ' + @NO_ASSET +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
