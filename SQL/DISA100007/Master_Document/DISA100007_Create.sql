DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_dc_master_document 
				 WHERE [nama_document] = @NAMA_DOKUMEN
				 AND [rak] = @NO_RAK
				 AND [label_rak] = @RAK
				 AND [department] = @DEPARTMENT
				 AND [bagian] = @BAGIAN
				 AND [tgl_register] LIKE '%' + CONVERT(varchar, cast(year(getdate()) as varchar) + '-' +  cast(month(getdate()) as varchar), 105) + '%' --Get data "years-month" (ex: 2022-11)
				 AND [flg_dispose] <> 1
				);

	IF(@@CNT > 0)
	BEGIN

		--History Data
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
		  (SELECT CONCAT(@NOTE_LOG, ' Qty Bundel: ',@QTY_BUNDLE) as keterangan FROM ad_dis_dc_master_document WHERE nama_document = @NAMA_DOKUMEN),
		  @USERNAME,
		  @CREATED_DATE
		);

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
		  ,[flg_dispose]
		  ,[created_by]
		  ,[created_date]
		)
		VALUES
		(
          @JENIS_TRANSAKSI
		  ,(SELECT no_document FROM ad_dis_dc_master_document WHERE nama_document = @NAMA_DOKUMEN)
		  ,(SELECT nama_document FROM ad_dis_dc_master_document WHERE nama_document = @NAMA_DOKUMEN)
		  ,@QTY_BUNDLE
		  ,@DEPARTMENT
		  ,@BAGIAN
		  ,@NO_RAK
		  ,@RAK
		  ,getdate()
		  ,@ESTIMASI_DISPOSE
		  ,@MASA_SIMPAN
		  ,@KETERANGAN
		  ,@FLG_APPROVE
		  ,'False'
		  ,@USERNAME
		  ,getdate()
		);
		
		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
		
	END ELSE
	BEGIN

		--Insert Data To Master Document Temp
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
		  ,[flg_dispose]
		  ,[created_by]
		  ,[created_date]
		)
		VALUES
		(
		  @JENIS_TRANSAKSI
		  ,@NO_DOKUMEN
		  ,@NAMA_DOKUMEN
		  ,@QTY_BUNDLE
		  ,@DEPARTMENT
		  ,@BAGIAN
		  ,@NO_RAK
		  ,@RAK
		  ,getdate()
		  ,@ESTIMASI_DISPOSE
		  --,DATEADD(year, CAST(@MASA_SIMPAN AS int), getdate()) --estimasi dispose old
		  ,@MASA_SIMPAN
		  ,@KETERANGAN
		  ,@FLG_APPROVE
		  ,'False'
		  ,@USERNAME
		  ,getdate()
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
		  @NO_DOKUMEN,
		  @NAMA_MENU,
		  @NAMA_FITUR,
		  (SELECT CONCAT(@NOTE_LOG, ' Qty Bundel: ',@QTY_BUNDLE) as keterangan),
		  @USERNAME,
		  @CREATED_DATE
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [ad_dis_dc_master_document]:' +@NAMA_DOKUMEN+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
