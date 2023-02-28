DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@QTY_BUNDLE VARCHAR(MAX)
	, @@JENIS_TRANSAKSI VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_dc_master_document WHERE [no_document] = @NO_DOCUMENT);
	

	IF(@@CNT > 0)
	BEGIN
		IF(@APPROVED_BY = 'DEPT_HEAD_USER')
		BEGIN
			UPDATE [ad_dis_dc_master_document_temp]
			SET
				dept_head_created_by = @USERNAME, 
				dept_head_created_date = @CREATED_DATE, 
				dept_head_created_sign = @USERNAME + '.JPG'
			WHERE 
				id_tb_m_list = @ID 
				AND no_document = @NO_DOCUMENT
		END ELSE

		IF(@APPROVED_BY = 'ADM_CONTROL')
		BEGIN
			--Tanda Tangan ADM. Control
			UPDATE [ad_dis_dc_master_document_temp]
				SET
					flg_approve = 1,
					adm_created_by = @USERNAME, 
					adm_created_date = @CREATED_DATE, 
					adm_created_sign = @USERNAME + '.JPG'
				WHERE 
					id_tb_m_list = @ID 
					AND no_document = @NO_DOCUMENT
		
			--Get Data Jenis Transaksi
			SET @@JENIS_TRANSAKSI = (SELECT jenis_transaksi FROM ad_dis_dc_master_document_temp WHERE id_tb_m_list = @ID AND [no_document] = @NO_DOCUMENT);
		
			--Get Data Qty Bundle
			SET @@QTY_BUNDLE = (SELECT qty_bundle FROM [ad_dis_dc_master_document_temp] WHERE id_tb_m_list = @ID AND no_document = @NO_DOCUMENT);

			IF(@@JENIS_TRANSAKSI = 'taruh')
			BEGIN
				--Create History Approval		
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
				  (SELECT no_document FROM [ad_dis_dc_master_document_temp] WHERE id_tb_m_list = @ID AND no_document = @NO_DOCUMENT),
				  @NAMA_MENU,
				  @NAMA_FITUR,
				  (SELECT 'Qty Bundel: ' + CONCAT(qty_bundle, ' -> ', qty_bundle + (CAST(@@QTY_BUNDLE as integer) )) as keterangan FROM ad_dis_dc_master_document WHERE no_document = @NO_DOCUMENT),
				  @USERNAME,
				  @CREATED_DATE
				);

				--Update Qty Bundle
				UPDATE ad_dis_dc_master_document SET
					 [qty_bundle] = qty_bundle + (CAST(@@QTY_BUNDLE as int))
				WHERE 
					no_document = @NO_DOCUMENT

			END ELSE
			
			IF(@@JENIS_TRANSAKSI = 'pinjam')
			BEGIN
			--Create History Approval		
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
				  (SELECT no_document FROM [ad_dis_dc_master_document_temp] WHERE id_tb_m_list = @ID AND no_document = @NO_DOCUMENT),
				  @NAMA_MENU,
				  @NAMA_FITUR,
				  (SELECT 'Qty Bundel: ' + CONCAT(qty_bundle, ' -> ',qty_bundle - (CAST(@@QTY_BUNDLE as integer) )) as keterangan FROM ad_dis_dc_master_document WHERE no_document = @NO_DOCUMENT),
				  @USERNAME,
				  @CREATED_DATE
				);

				--Update Qty Bundle
				UPDATE ad_dis_dc_master_document SET
					 [qty_bundle] = qty_bundle - (CAST(@@QTY_BUNDLE as int))
				WHERE 
					no_document = @NO_DOCUMENT
			END
		END
		

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
		
	END ELSE
	BEGIN
		IF(@APPROVED_BY = 'DEPT_HEAD_USER')
		BEGIN
			UPDATE [ad_dis_dc_master_document_temp]
			SET
				dept_head_created_by = @USERNAME, 
				dept_head_created_date = @CREATED_DATE, 
				dept_head_created_sign = @USERNAME + '.JPG'
			WHERE 
				id_tb_m_list = @ID 
				AND no_document = @NO_DOCUMENT
		END ELSE

		IF(@APPROVED_BY = 'ADM_CONTROL')
		BEGIN
			UPDATE [ad_dis_dc_master_document_temp]
			SET
				flg_approve = 1,
				adm_created_by = @USERNAME, 
				adm_created_date = @CREATED_DATE, 
				adm_created_sign = @USERNAME + '.JPG'
			WHERE 
				id_tb_m_list = @ID 
				AND no_document = @NO_DOCUMENT


			--Insert Data To Master Document
			INSERT INTO 										
			ad_dis_dc_master_document										
			( 				
				no_document, department, bagian, rak, label_rak, nama_document, qty_bundle, tgl_register, estimasi_dispose, masa_simpan, keterangan, flg_approve, created_by, created_date, updated_by, 
                updated_date, dept_head_created_by, dept_head_created_date, dept_head_created_sign, adm_created_by, adm_created_date, adm_created_sign, flg_dispose, dispose_by, dispose_date, flg_delete								
			) 				
			SELECT 				
				no_document, department, bagian, rak, label_rak, nama_document, qty_bundle, tgl_register, estimasi_dispose, masa_simpan, keterangan, flg_approve, created_by, created_date, updated_by, 
                updated_date, dept_head_created_by, dept_head_created_date, dept_head_created_sign, adm_created_by, adm_created_date, adm_created_sign, flg_dispose, dispose_by, dispose_date, flg_delete										
			FROM 				
				ad_dis_dc_master_document_temp 	
			WHERE 
				id_tb_m_list = @ID 
				AND no_document = @NO_DOCUMENT

			
			
			--INSERT INTO [ad_dis_dc_master_document]
			--(
			--  [no_document]
			--  ,[nama_document]
			--  ,[qty_bundle]
			--  ,[department]
			--  ,[bagian]
			--  ,[rak]
			--  ,[label_rak]
			--  ,[tgl_register]
			--  ,[estimasi_dispose]
			--  ,[masa_simpan]
			--  ,[keterangan]
			--  ,[created_by]
			--  ,[created_date]
			--)
			--VALUES
			--(
			--  (SELECT no_document FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT nama_document FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT qty_bundle FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT department FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT bagian FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT rak FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT label_rak FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT tgl_register FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT estimasi_dispose FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT masa_simpan FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,(SELECT keterangan FROM [ad_dis_dc_master_document_temp] WHERE no_document = @ID)
			--  ,@USERNAME
			--  ,getdate()
			--)
		END
	
		--Create History Approval		
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
		  @ID,
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
	SET @@ERR = 'ERROR INSERT [ad_dis_dc_master_document]:' +@ID+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
