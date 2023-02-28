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
		@NO_ASSET
		,@NAMA_FITUR
		,@KETERANGAN
		,'DISPOSE'
		,@USERNAME
		,GETDATE()
	)


	-----Update table Dispose Asset
	IF(@STATUS_APPROVAL = 'PREPARED') --Dept. Head User
	BEGIN
		UPDATE ad_dis_ma_dispose_asset 
		SET
			status_approval = 'CHECKED DEPT. HEAD USER by ' + @USERNAME,
			dept_head_user_created=@USERNAME,
			dept_head_user_created_date=@DATE_APPROVAL,
			dept_head_user_created_sign=@USERNAME + '.jpg'
		WHERE 
			ID_TB_M_DISPOSE = @ID_TB_M_DISPOSE
			AND NO_DISPOSE = @NO_DISPOSE
	END ELSE
	IF(@STATUS_APPROVAL = 'CHECKED') --AMS
	BEGIN
		UPDATE ad_dis_ma_dispose_asset 
		SET
			status_approval = 'APPROVED AMS by ' + @USERNAME,
			ams_created=@USERNAME,
			ams_created_date=@DATE_APPROVAL,
			ams_created_sign=@USERNAME + '.jpg'
		WHERE 
			ID_TB_M_DISPOSE = @ID_TB_M_DISPOSE
			AND NO_DISPOSE = @NO_DISPOSE
	END ELSE
	IF(@STATUS_APPROVAL = 'APPROVED_AMS') --Dept. Head AMS
	BEGIN
		UPDATE ad_dis_ma_dispose_asset 
		SET
			status_approval = 'APPROVED DEPT. HEAD AMS by ' + @USERNAME,
			dept_head_ams_created=@USERNAME,
			dept_head_ams_created_date=@DATE_APPROVAL,
			dept_head_ams_created_sign=@USERNAME + '.jpg'
		WHERE 
			ID_TB_M_DISPOSE = @ID_TB_M_DISPOSE
			AND NO_DISPOSE = @NO_DISPOSE
	END ELSE
	IF(@STATUS_APPROVAL = 'APPROVED_DEPT_HEAD_AMS') --Dept. Head AMS
	BEGIN
		UPDATE ad_dis_ma_dispose_asset 
		SET
			status_approval = 'ACKNOWLEDGE GM by ' + @USERNAME,
			acknowledge_created=@USERNAME,
			acknowledge_created_date=@DATE_APPROVAL,
			acknowledge_created_sign=@USERNAME + '.jpg'
		WHERE 
			ID_TB_M_DISPOSE = @ID_TB_M_DISPOSE
			AND NO_DISPOSE = @NO_DISPOSE

		----Update table Master Asset
		--UPDATE ad_dis_ma_master_asset
		--SET
		--	flg_dispose_asset = 1,
		--	tgl_dispose_asset= @DATE_APPROVAL
		--WHERE
		--	no_asset = @NO_ASSET

	END

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
