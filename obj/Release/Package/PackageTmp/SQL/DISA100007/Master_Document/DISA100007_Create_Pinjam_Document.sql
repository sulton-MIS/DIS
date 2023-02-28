DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY

	BEGIN

		--Insert Data To Master Document Temp ==> Ambil data dari Master List Document jika sudah ada
		INSERT INTO [ad_dis_dc_master_document_temp]
		(
		  [jenis_transaksi]
		  ,[no_document]
		  ,[nama_document]
		  ,[qty_bundle]
		  ,[department]
		  ,[bagian]
		  ,[rak]
		  ,[label_rak]
		  ,[tgl_register]
		  ,[estimasi_dispose]
		  ,[masa_simpan]
		  ,[keterangan]
		  ,[flg_approve]
		  ,[created_by]
		  ,[created_date]
		  ,[nama_peminjam]
		  ,[department_peminjam]
		  ,[bagian_peminjam]
		  ,[note_peminjam]
		  ,[masa_pinjam_days]
		  ,[tgl_pinjam]
		  ,[estimasi_kembali]
		)
		VALUES
		(
          @JENIS_TRANSAKSI
		  ,(SELECT no_document FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT nama_document FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT qty_bundle FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT department FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT bagian FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT rak FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT label_rak FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT tgl_register FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT estimasi_dispose FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT masa_simpan FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,(SELECT keterangan FROM ad_dis_dc_master_document WHERE no_document = @NO_DOKUMEN AND nama_document = @NAMA_DOKUMEN)
		  ,'FALSE'
		  ,@USERNAME
		  ,getdate()
		  ,@NAMA_PEMINJAM
		  ,@DEPARTMENT_PEMINJAM
		  ,@BAGIAN_PEMINJAM
		  ,@NOTE_PEMINJAM
		  ,@MASA_PINJAM
		  ,@TGL_PINJAM
		  ,@ESTIMASI_KEMBALI
		);

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





