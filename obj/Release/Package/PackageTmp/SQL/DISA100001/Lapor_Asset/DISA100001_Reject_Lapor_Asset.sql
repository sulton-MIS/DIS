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
	UPDATE ad_dis_ma_lapor_asset 
	SET
		flg_approval_lapor= 0,
		reject_by= LTRIM(@USERNAME),
		reject_date= @DATE_REJECT
	WHERE 
		ID_TB_M_LAPOR = @ID_TB_M_LAPOR
		AND NO_LAPOR = @ID
		AND NO_ASSET= @NO_ASSET


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
	SET @@ERR = 'ERROR APPROVAL ad_dis_ma_lapor_asset: ' + @ID +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
