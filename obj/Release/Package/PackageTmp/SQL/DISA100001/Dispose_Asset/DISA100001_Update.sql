DECLARE 
	  @@CNT INT
	, @@CEK_LAPOR INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@NO_URUT VARCHAR(MAX) = '';

BEGIN TRY
	IF(@NO_DISPOSE <> 'null')
	BEGIN
		--UPDATE TABLE DISPOSE ASSET
		UPDATE [ad_dis_ma_dispose_asset] 
		SET
			nama_foto_laporan = LTRIM(@FOTO_NAME)
			,keterangan= LTRIM(@KETERANGAN)
			,status_approval=LTRIM(@STATUS_APPROVAL)
			,updated_by=LTRIM(@USERNAME)
			,updated_date= @UPDATED_DATE
			,updated_by_sign= @UPDATED_SIGN
		WHERE 
			NO_DISPOSE= @NO_DISPOSE

		--Update table Master Asset
		UPDATE ad_dis_ma_master_asset
		SET
			status = @STATUS_KONDISI_ASSET
		WHERE
			no_asset = @NO_ASSET

		--Input History Asset
		INSERT INTO ad_dis_ma_history_asset
		(
			[no_asset]
			,[nama_fitur]
			,[keterangan]
			,[status]
			,[created_by]
			,[created_date]
		)
		VALUES(
			@NO_ASSET
			,@NAMA_FITUR
			,'Updated Dispose Asset: ''' + @NO_DISPOSE + ''''
			,@STATUS_KONDISI_ASSET
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
	SET @@ERR = 'ERROR UPDATE ad_dis_ma_dispose_asset: ' + @NO_DISPOSE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
