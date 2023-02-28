DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_dc_master_document_temp WHERE [id_tb_m_list] = @ID AND [no_document] = @NO_DOKUMEN);
	

	IF(@@CNT > 0)
	BEGIN

		UPDATE [ad_dis_dc_master_document_temp]
		SET
			flg_pinjam = 0,
			flg_kembali = 1,
			nama_pengembali = @USERNAME,
			tgl_kembali = @CREATED_DATE
		WHERE 
			[id_tb_m_list] = @ID 
			AND [no_document] = @NO_DOKUMEN
		
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
	SET @@ERR = 'ERROR INSERT [ad_dis_dc_master_document_temp]:' +@ID+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
