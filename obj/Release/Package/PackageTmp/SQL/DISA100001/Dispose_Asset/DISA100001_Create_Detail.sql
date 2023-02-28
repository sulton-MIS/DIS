DECLARE 
	@@CNT INT
	, @@CEK_LAPOR INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_dispose_asset_detail WHERE [no_dispose] like '%'+ @NO_DISPOSE AND [no_asset] = @NO_ASSET);
	IF(@@CNT > 0)
	BEGIN
		--Delete Data Dispose Detail
		--DELETE FROM
		--	ad_dis_ma_dispose_asset_detail
		--WHERE
		--	NO_DISPOSE = RTRIM(@NO_DISPOSE)

		--Input Dispose Asset
		INSERT INTO ad_dis_ma_dispose_asset_detail
		(
		  [no_dispose]
		  ,[no_asset]
		  ,[keterangan]
		)
		VALUES
		(
		  RTRIM(@NO_DISPOSE)
		  ,@NO_ASSET
		  ,@KETERANGAN
		);

		--Update table Master Asset
		UPDATE ad_dis_ma_master_asset
		SET
			keterangan= @KETERANGAN,
			status = @STATUS_KONDISI,
			flg_dispose_asset = 1,
			tgl_dispose_asset= getdate()
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
			,'Create Dispose Asset: ''' + @NO_DISPOSE + ''''
			,(SELECT status FROM ad_dis_ma_master_asset WHERE no_asset = @NO_ASSET)
			,@USERNAME
			,GETDATE()
		)

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

	END ELSE

	BEGIN
		--Input Dispose Asset
		INSERT INTO ad_dis_ma_dispose_asset_detail
		(
		  [no_dispose]
		  ,[no_asset]
		  ,[keterangan]
		)
		VALUES
		(
		  RTRIM(@NO_DISPOSE)
		  ,@NO_ASSET
		  ,@KETERANGAN
		);

		--Update table Master Asset
		UPDATE ad_dis_ma_master_asset
		SET
			keterangan= @KETERANGAN,
			status = @STATUS_KONDISI,
			flg_dispose_asset = 1,
			tgl_dispose_asset= getdate()
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
			,'Create Dispose Asset: ''' + @NO_DISPOSE + ''''
			,(SELECT status FROM ad_dis_ma_master_asset WHERE no_asset = @NO_ASSET)
			,@USERNAME
			,GETDATE()
		)

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

END TRY
BEGIN CATCH

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_ma_dispose_asset_detail:' +@NO_DISPOSE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
