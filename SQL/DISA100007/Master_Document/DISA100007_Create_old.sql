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
				 AND [tgl_register] LIKE '%' + CONVERT(varchar, cast(year(getdate()) as varchar) + '-' +  cast(month(getdate()) as varchar), 105) + '%' 
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
		  (SELECT CONCAT(keterangan, ' -> ',@KETERANGAN) as keterangan FROM ad_dis_dc_master_document WHERE nama_document = @NAMA_DOKUMEN),
		  @USERNAME,
		  @CREATED_DATE
		);

		--Jika Data sudah ada di DB, lakukan update
		UPDATE ad_dis_dc_master_document SET
		  [qty_bundle] = (CAST(@QTY_BUNDLE as int) + qty_bundle)
		  ,[department] = @DEPARTMENT
		  ,[bagian] = @BAGIAN
		  ,[rak] = @NO_RAK
		  ,[label_rak] = @RAK
		  ,[masa_simpan] = RTRIM(@MASA_SIMPAN)
		  ,[estimasi_dispose] = @ESTIMASI_DISPOSE
		  ,[keterangan] = @KETERANGAN
		  ,[updated_by] = @USERNAME
		  ,[updated_date] = @CREATED_DATE
	      ,[flg_approve] = 'False'
	      ,[dept_head_created_by] = NULL
		  ,[dept_head_created_date] = NULL
		  ,[dept_head_created_sign] = NULL
		  ,[adm_created_by] = NULL
		  ,[adm_created_date] = NULL
		  ,[adm_created_sign] = NULL
		WHERE 
			nama_document = @NAMA_DOKUMEN
		
		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
		
	END ELSE
	BEGIN

		--Insert Data To Master Document
		INSERT INTO [ad_dis_dc_master_document]
		(
		  [no_document]
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
		  @NO_DOKUMEN
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
	SET @@ERR = 'ERROR INSERT [ad_dis_dc_master_document]:' +@NAMA_DOKUMEN+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
