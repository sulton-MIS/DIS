DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@NO_URUT VARCHAR(MAX) = '';

BEGIN TRY
	IF(@NO_DISPOSE <> 'null')
	BEGIN
	--Input ke tabel History Asset
	INSERT INTO ad_dis_ma_history_asset
	(
		[no_asset]
		,[keterangan]
		,[status]
		,[created_by]
		,[created_date]
	)
	VALUES(
		@NO_ASSET
		,@KETERANGAN
		,@STATUS_KONDISI
		,@USERNAME
		,GETDATE()
	)

	--Update table Lapor Asset
	UPDATE ad_dis_ma_dispose_asset 
	SET
		status_approval = @STATUS_APPROVAL,
		reject_created_by = LTRIM(@USERNAME),
		reject_created_date = @DATE_REJECT,
		reject_created_sign = @USERNAME + '.jpg'
	WHERE 
		ID_TB_M_DISPOSE = @ID_TB_M_DISPOSE
		AND NO_DISPOSE = @NO_DISPOSE
		--AND NO_ASSET= @NO_ASSET

	--Update table Master Asset
	UPDATE ad_dis_ma_master_asset 
	SET
		flg_dispose_asset = 0
	WHERE 
		NO_ASSET= @NO_ASSET


	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
	END ELSE
	BEGIN
		SET @@CHK = 'FALSE';
		SET @@ERR = 'APPROVAL ERROR!';	
	END 
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR APPROVAL ad_dis_ma_dispose_asset: ' + @NO_DISPOSE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
