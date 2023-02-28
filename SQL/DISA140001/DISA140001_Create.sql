
DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM [ad_dis_rt_label_gaikan] WHERE id_produksi = @ID_PRODUKSI and id_proses = @ID_PROSES);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO [ad_dis_rt_label_gaikan]
		(
			   [id_produksi]
			  ,[id_proses]
			  ,[nama_proses]
			  ,[tipe]
			  ,[nik]
			  ,[nama]
			  ,[serial_no]
			  ,[lotto]
			  ,[qty]
			  ,[total_berat]
			  ,[keterangan]
			  ,[shift]			  
			  ,[create_by]
			  ,[create_date]
			  
			
		)
		VALUES
		(
			@ID_PRODUKSI
			,@ID_PROSES
			,@NAMA_PROSES
			,@TIPE						
			,@NIK
			,@NAMA
			,@SERIAL_NO
			,@LOTTO
			,@QTY
			,@TOTAL_BERAT
			,@KETERANGAN
			,@SHIFT			
			,@username
			,GETDATE()			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [ad_dis_rt_label_gaikan]:' +@ID_PRODUKSI+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
