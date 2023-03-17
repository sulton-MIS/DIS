DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_master_asset WHERE no_asset like '%'+ @NO_ASSET + '%' and nama_asset = @NAMA_ASSET);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		--Input ke tabel Master Asset
		INSERT INTO ad_dis_ma_master_asset
		(
		  no_asset,
		  id_tb_m_req_asset,
		  no_request_asset,
		  id_pr,
		  nama_asset,
		  nama_asset_invoice,
		  item_code,
		  tahun,
		  umur,
		  bulan,
		  jenis_asset,
		  kategori_asset,
		  merek,
		  tipe,
		  supplier,
		  keterangan,
		  spesifikasi,
		  harga_satuan,
		  jenis_dokumen,
		  no_aju,
		  tgl_dokumen,
		  tgl_register,
		  nama_foto,
		  pic_request,
		  dept_request,
		  nama_user,
		  dept_user,
		  kd_lokasi,
		  halte,
		  status,
		  created_by,
		  created_date,
		  flg_dispose_asset
		)
		VALUES
		(
		  @NO_ASSET,
		  @ID,
		  @NO_REQUEST,
		  @ID_PR,
		  @NAMA_ASSET,
		  @NAMA_ASSET_INVOICE,
		  @ITEM_CODE,
		  @TAHUN,
		  @UMUR,
		  @BULAN,
		  @JENIS_ASSET,
		  @KATEGORI_ASSET,
		  @MEREK,
		  @TIPE,
		  @SUPPLIER,
		  @KETERANGAN,
		  @SPESIFIKASI,
		  @HARGA_SATUAN,
		  @JENIS_DOKUMEN,
		  @NO_AJU,
		  @TGL_DOKUMEN,
		  @TGL_REGISTER,
		  @FOTO_NAME,
		  @PIC_REQUEST,
		  @DEPT_REQUEST,
		  @NAMA_USER,
		  @DEPT_USER,
		  @KD_LOKASI,
		  @HALTE,
		  @STATUS_KONDISI,
		  @USERNAME,
		  @TGL_REQUEST,
		  0
		);

		--Update ke tabel Request Asset
		UPDATE ad_dis_ma_request_detail_asset
		SET
			flg_register_asset = 1
			,status = @STATUS
		WHERE 
			id_tb_m_req_asset = @ID 

		--Cek status Asset
		IF(@STATUS = 'ASSET IN')
			select @STATUS='PENGADAAN'
		ELSE
			select @STATUS 


		--Input ke tabel History Asset
		INSERT INTO ad_dis_ma_history_asset
		(
		  [no_asset]
		  ,[nama_fitur]
		  ,[keterangan]
		  ,[status]
		  ,[created_by]
		  ,[created_date]
		)
		VALUES(
			@NO_ASSET
			,'PENGADAAN'
			,'New Asset Incoming'
			,'PENGADAAN'
			,@USERNAME
			,@TGL_REQUEST
		)



		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

END TRY
BEGIN CATCH

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_ma_master_asset:' +@NO_ASSET+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS