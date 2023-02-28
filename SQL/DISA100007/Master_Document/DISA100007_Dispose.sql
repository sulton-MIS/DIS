DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_dc_master_document WHERE [no_document] = @ID);
	

	IF(@@CNT > 0)
	BEGIN

		UPDATE [ad_dis_dc_master_document]
		SET
			flg_dispose = 1,
			dispose_by = @USERNAME,
			dispose_date = @CREATED_DATE
		WHERE 
			no_document = @ID
		
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
