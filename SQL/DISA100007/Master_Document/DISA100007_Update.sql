DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	IF (@PAGE_VIEWER = 'MasterListDokumen')
	BEGIN
		UPDATE ad_dis_dc_master_document 
		SET
		   [qty_bundle] = @QTY_BUNDLE
		  ,[department] = @DEPARTMENT
		  ,[bagian] = @BAGIAN
		  ,[rak] = @NO_RAK
		  ,[label_rak] = @LABEL_RAK
		  ,[nama_document] = @NAMA_DOKUMEN
		  ,[masa_simpan] = RTRIM(@MASA_SIMPAN)
		  ,[estimasi_dispose] = @ESTIMASI_DISPOSE
		  --,[estimasi_dispose] = DATEADD(year, CAST(@MASA_SIMPAN AS decimal), tgl_register)
		  ,[keterangan] = @KETERANGAN
		  ,[updated_by] = @USERNAME
		  ,[updated_date] = @DATE_UPDATED
		WHERE 
			no_document = @NO_DOKUMEN

		--Create History
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
			@LOG_HISTORY_KETERANGAN,
			@USERNAME,
			@DATE_UPDATED
		);

			
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';

	END 
	
	ELSE IF (@PAGE_VIEWER = 'WaitingApproval')
	BEGIN
		UPDATE ad_dis_dc_master_document_temp 
		SET
		   [qty_bundle] = @QTY_BUNDLE
		  ,[department] = @DEPARTMENT
		  ,[bagian] = @BAGIAN
		  ,[rak] = @NO_RAK
		  ,[label_rak] = @LABEL_RAK
		  ,[nama_document] = @NAMA_DOKUMEN
		  ,[masa_simpan] = RTRIM(@MASA_SIMPAN)
		  ,[estimasi_dispose] = @ESTIMASI_DISPOSE
		  --,[estimasi_dispose] = DATEADD(year, CAST(@MASA_SIMPAN AS decimal), tgl_register)
		  ,[keterangan] = @KETERANGAN
		  ,[updated_by] = @USERNAME
		  ,[updated_date] = @DATE_UPDATED
		WHERE 
			no_document = @NO_DOKUMEN

		--Create History
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
			@LOG_HISTORY_KETERANGAN,
			@USERNAME,
			@DATE_UPDATED
		);

	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';

	END

END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_dc_master_document: ' + @NO_DOKUMEN +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
