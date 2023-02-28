DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_rt_label_gaikan SET
			id_produksi = @ID_PRODUKSI,
			id_proses = @ID_PROSES,
			nama_proses = @NAMA_PROSES,
			tipe = @TIPE,
			nik = @NIK,			
			nama = @NAMA,
			serial_no = @SERIAL_NO,
			lotto = @LOTTO,
			qty = @QTY,
			total_berat = @TOTAL_BERAT,
			keterangan = @KETERANGAN,
			shift = @SHIFT,
			update_by = @username,
			update_date = GETDATE()			
	WHERE id_produksi = @ID

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE [ad_dis_rt_label_gaikan]: ' + @ID_PRODUKSI +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
