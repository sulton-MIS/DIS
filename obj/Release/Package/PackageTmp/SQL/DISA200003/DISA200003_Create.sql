DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_master_asset WHERE no_asset like '%'+ @NO_URUT and nama_asset = @NAMA_ASSET);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_ma_master_asset
		(
		  [no_asset]
		  ,[nama_asset]
		  ,[nama_foto]
		  ,[merek]
		  ,[tipe]
		  ,[supplier]
		  ,[tahun]
		  ,[qty]
		  ,[harga_satuan]
		  ,[total]
		  ,[jenis_asset]
		  ,[kategori_asset]
		  ,[pic_beli]
		  ,[dept_user]
		  ,[nama_user]
		  ,[kd_lokasi]
		  ,[halte]
		  ,[jenis_doc]
		  ,[no_bc]
		  ,[tgl_bc]
		  ,[tgl_regist]
		  ,[status]
		  ,[flg_label_asset]
		)
		VALUES
		(
		  @TAHUN + '.' + @JENIS_ASSET + '.' + @KATEGORI_ASSET + '.' + @NO_URUT
		  ,@NAMA_ASSET
		  ,@NAMA_FOTO
		  ,@MEREK
		  ,@TIPE
		  ,@SUPPLIER
		  ,@TAHUN
		  ,@QTY
		  ,@HARGA_SATUAN
		  ,cast(@QTY as int) * cast(@HARGA_SATUAN as int)
		  ,@JENIS_ASSET
		  ,@KATEGORI_ASSET
		  ,@PIC_BELI
		  ,@DEPT_USER
		  ,@NAMA_USER
		  ,@KD_LOKASI
		  ,@HALTE
		  ,@JENIS_DOC
		  ,@NO_BC
		  ,@TGL_BC
		  ,@TGL_REGIST
		  ,@STATUS
		  ,@FLG_LABEL_ASSET
		);

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_ma_master_asset:' +@NAMA_ASSET+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
