DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@NO_URUT VARCHAR(MAX) = '';

BEGIN TRY
	IF(@ID <> 'null')
	BEGIN
	--Input ke tabel History Asset
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
		@ID
		,'LAPOR'
		,@KETERANGAN
		,'EDIT'
		,@USERNAME
		,GETDATE()
	)

	--Update table Master Asset
	UPDATE ad_dis_ma_lapor_asset 
	SET
		nama_foto_laporan=LTRIM(@NAMA_FOTO),
		updated_by=LTRIM(@USERNAME),
		updated_date=@DATE_UPDATED
	WHERE 
		NO_LAPOR= @ID


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
	SET @@ERR = 'ERROR UPDATE ad_dis_ma_lapor_asset: ' + @ID +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
