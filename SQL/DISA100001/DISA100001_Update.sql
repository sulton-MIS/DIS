DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@NO_URUT VARCHAR(MAX) = '';

BEGIN TRY
	IF(@NAMA_ASSET <> 'null')
	BEGIN
	--Input data ke History Asset
	INSERT INTO [ad_dis_ma_history_perubahan_asset]
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
		  ,[flg_dispose_asset]
		  ,[tgl_dispose_asset]
		  ,[tgl_history]
		)
		VALUES
		(
		  (select no_asset from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select nama_asset from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select nama_foto from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select merek from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select tipe from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select supplier from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select tahun from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select qty from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select harga_satuan from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select cast(qty as int) * cast(harga_satuan as int) from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select jenis_asset from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select kategori_asset from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select pic_beli from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select dept_user from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select nama_user from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select kd_lokasi from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select halte from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select jenis_doc from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select no_bc from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select tgl_bc from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select tgl_regist from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select status from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select flg_label_asset from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select flg_dispose_asset from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,(select case when tgl_dispose_asset is null then NULL else tgl_dispose_asset end as tgl_dispose_asset from ad_dis_ma_master_asset where no_asset=@NO_ASSET)
		  ,GETDATE()
		)
	
	
	--Update table Master Asset
	UPDATE ad_dis_ma_master_asset 
	SET
		nama_asset=LTRIM(@NAMA_ASSET),
		nama_foto=LTRIM(@NAMA_FOTO),
		merek=LTRIM(@MEREK),
		tipe=LTRIM(@TIPE),
		supplier=LTRIM(@SUPPLIER),
		qty=LTRIM(@QTY),
		harga_satuan=LTRIM(@HARGA_SATUAN),
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
