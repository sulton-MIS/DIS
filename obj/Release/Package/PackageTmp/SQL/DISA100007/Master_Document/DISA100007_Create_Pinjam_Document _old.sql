
DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	--SET @@CNT = (SELECT COUNT(1) FROM ad_dis_dc_master_document 
	--			 WHERE [nama_document] = @NAMA_DOKUMEN
	--			);

	--IF(@@CNT > 0)
	--BEGIN

	--	SET @@CHK = 'FALSE';
	--	SET @@ERR = 'DUPLICATE';
		
	--END ELSE
	BEGIN

		--Insert Data To Master Document Temp
		INSERT INTO [ad_dis_dc_master_document_temp]
		(
		  [jenis_transaksi]
		  ,[no_document]
		  ,[nama_document]
		  ,[rak]
		  ,[label_rak]
		  ,[keterangan]
		  ,[nama_peminjam]
		  ,[department]
		  ,[bagian]
		  ,[qty_bundle]
		  ,[masa_pinjam_days]
		  ,[tgl_pinjam]
		  ,[estimasi_kembali]
		  ,[flg_approve]
		  ,[flg_pinjam]
		  ,[created_by]
		  ,[created_date]
		)
		VALUES
		(
		  @JENIS_TRANSAKSI
		  ,(SELECT no_document FROM ad_dis_dc_master_document WHERE nama_document = @NAMA_DOKUMEN)
		  ,@NAMA_DOKUMEN
		  ,@NO_RAK
		  ,@RAK
		  ,@KETERANGAN
		  ,@NAMA_PEMINJAM
		  ,@DEPARTMENT
		  ,@BAGIAN
		  ,@QTY_BUNDLE
		  ,@MASA_PINJAM
		  ,@TGL_PINJAM
		  ,@ESTIMASI_KEMBALI
		  ,'FALSE'
		  ,@FLG_PINJAM
		  ,@USERNAME
		  ,getdate()
		);


		--Mengurangi Stok (qty_bundle) Dokumen
		--UPDATE ad_dis_dc_master_document
		--SET
		--	[qty_bundle] = qty_bundle - @QTY_BUNDLE
		--WHERE 
		--	[no_document] = (SELECT no_document FROM ad_dis_dc_master_document WHERE nama_document = @NAMA_DOKUMEN)


		
		--History Insert Data
		INSERT INTO [ad_dis_dc_history_document]
		(
		 [no_document]
		 ,[nm_menu]
		 ,[nm_fitur]
		 ,[keterangan]
		 ,[created_by]
		 ,[created_date]
		)
		VALUES
		(
		  (SELECT no_document FROM ad_dis_dc_master_document WHERE nama_document = @NAMA_DOKUMEN),
		  @NAMA_MENU,
		  @NAMA_FITUR,
		  @NOTE_LOG,
		  @USERNAME,
		  @CREATED_DATE
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [ad_dis_dc_pinjam_document]:' +@NAMA_DOKUMEN+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS