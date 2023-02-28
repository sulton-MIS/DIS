DECLARE 
	@@NO_DOKUMEN VARCHAR(MAX),
	@@QTY_BUNDLE VARCHAR(MAX);


BEGIN
	IF (@PAGE_VIEWER = 'MasterListDokumen')
	BEGIN
		--DELETE ad_dis_dc_master_document WHERE id_tb_m_list = @ID;
		UPDATE 
			ad_dis_dc_master_document
		SET
			flg_delete = 1
		WHERE
			id_tb_m_list = @ID;

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
			(SELECT no_document FROM ad_dis_dc_master_document WHERE id_tb_m_list = @ID),
			'List Master Document',
			'Hapus Data',
			'No. Document: "' + (SELECT no_document FROM ad_dis_dc_master_document WHERE id_tb_m_list = @ID) + '" Has Been Deleted.',
			@USERNAME,
			getdate()
		);
	END ELSE

	IF (@PAGE_VIEWER = 'WaitingApproval')
	BEGIN
		--get no_dokumen
		SET @@NO_DOKUMEN = (SELECT no_document FROM ad_dis_dc_master_document_temp WHERE id_tb_m_list = @ID);

		--get qty_dokumen
		SET @@QTY_BUNDLE = (SELECT qty_bundle FROM ad_dis_dc_master_document_temp WHERE id_tb_m_list = @ID AND no_document = @@NO_DOKUMEN);

		--DELETE History
		DELETE FROM [ad_dis_dc_history_document]
		WHERE 
			no_document = @@NO_DOKUMEN			
			AND keterangan like '%' + @@QTY_BUNDLE + '%';


		--DELETE ad_dis_dc_master_document 
		DELETE ad_dis_dc_master_document_temp
		WHERE 
			id_tb_m_list = @ID
			AND no_document = @@NO_DOKUMEN;

	END
	
	SELECT 'True' AS MSG;
	
END



