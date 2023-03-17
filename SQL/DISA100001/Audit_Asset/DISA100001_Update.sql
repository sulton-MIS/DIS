DECLARE 
	  @@CNT INT
	, @@CEK_LAPOR INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@NO_URUT VARCHAR(MAX) = '';

BEGIN TRY
	IF(@NO_AUDIT <> 'null')
	BEGIN
		IF(@JENIS_AUDIT = 'BULANAN')
		BEGIN
			--UPDATE TABLE AUDIT ASSET
			UPDATE [ad_dis_ma_audit_asset] 
			SET
				nama_foto_audit = LTRIM(@FOTO_NAME)
				,keterangan= LTRIM(@KETERANGAN)
				,periode_semester=LTRIM(@PERIODE)
				,tahun=LTRIM(@TAHUN)
				,status=LTRIM(@STATUS_KONDISI)
				,updated_by=LTRIM(@USERNAME)
				,updated_date= @UPDATED_DATE
			WHERE 
				NO_AUDIT= @NO_AUDIT
		END ELSE
		IF(@JENIS_AUDIT = 'SEMESTER')
		BEGIN
			--UPDATE TABLE AUDIT ASSET
			UPDATE [ad_dis_ma_audit_asset] 
			SET
				nama_foto_audit = LTRIM(@FOTO_NAME)
				,keterangan= LTRIM(@KETERANGAN)
				,periode_bulan=LTRIM(@PERIODE)
				,tahun=LTRIM(@TAHUN)
				,status=LTRIM(@STATUS_KONDISI)
				,updated_by=LTRIM(@USERNAME)
				,updated_date= @UPDATED_DATE
			WHERE 
				NO_AUDIT= @NO_AUDIT
		END
		
		--Input History Asset
		INSERT INTO ad_dis_ma_history_asset
		(
			[no_asset]
			,[keterangan]
			,[status]
			,[nama_fitur]
			,[created_by]
			,[created_date]
		)
		VALUES(
			@NO_ASSET
			,'Updated Audit Asset: ''' + @NO_AUDIT + ''''
			,@STATUS_KONDISI
			,@NAMA_FITUR
			,@USERNAME
			,GETDATE()
		)
		

		SET @@CHK = 'TRUE';
		SET @@ERR = 'Data Has Been Updated';
	END ELSE
	BEGIN
		SET @@CHK = 'FALSE';
		SET @@ERR = 'DATA CAN NOT SET NULL! PLEASE CHECK AGAIN BEFORE UPDATING!';	
	END 
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_ma_audit_asset: ' + @NO_AUDIT +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
