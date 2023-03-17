DECLARE 
	@@CNT INT
	, @@CEK_LAPOR INT
	, @@CEK_NO_ASSET INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_lapor_asset WHERE [no_lapor] like '%'+ @NO_LAPOR);
	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	SET @@CEK_LAPOR = (SELECT COUNT(1) FROM ad_dis_ma_lapor_asset WHERE [no_asset] like '%'+ @NO_ASSET AND flg_approval_lapor IS NULL);
	IF (@@CEK_LAPOR > 0)
	BEGIN

		SET @@CHK = 'NOT APPROVED';
		SET @@ERR = 'NO.ASSET HAS NOT BEEN PREVIOUSLY APPROVED by AMS BEFORE!';
		
	END ELSE

	BEGIN
		--Input Lapor Asset
		INSERT INTO ad_dis_ma_lapor_asset
		(
		  [no_lapor]
		  ,[no_asset]
		  ,[status]
		  ,[keterangan]
		  ,[nama_foto_laporan]
		  ,[tgl_lapor]
		  ,[created_by]
		  ,[created_date]
		  ,[flg_approval_lapor]
		)
		VALUES
		(
		  @NO_LAPOR
		  ,@NO_ASSET
		  ,@STATUS_KONDISI
		  ,@KETERANGAN
		  ,@FOTO_NAME
		  ,@TGL_LAPOR
		  ,@USERNAME
		  ,@CREATED_DATE
		  ,NULL --Untuk status Waiting Approval
		);

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
			,'LAPOR ASSET'
			,'Create Lapor Asset: ''' + @NO_LAPOR + ''''
			,@STATUS_KONDISI
			,@USERNAME
			,GETDATE()
		)

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

	IF(@STATUS_KONDISI = 'PINDAH')
	BEGIN
		SET @@CEK_LAPOR = (SELECT COUNT(1) FROM ad_dis_ma_lapor_pindah_asset WHERE [no_lapor] like '%'+ RTRIM(LTRIM(@NO_LAPOR)));
		
		IF(@@CEK_LAPOR > 0)
		BEGIN
			UPDATE ad_dis_ma_lapor_pindah_asset
			SET
				kd_lokasi_baru = @LOKASI,
				sub_lokasi_baru = @SUB_LOKASI,
				nama_user_baru = @NAMA_USER,
				dept_user_baru = @DEPT_USER,
				halte_baru = @HALTE,
				created_by = @USERNAME,
				created_date = @CREATED_DATE
			WHERE [no_lapor] like '%'+ RTRIM(LTRIM(@NO_LAPOR) + '%') 
		END ELSE
		BEGIN
			INSERT INTO ad_dis_ma_lapor_pindah_asset
			(
				[no_lapor]
				,[no_asset]
				,[kd_lokasi_baru]
				,[sub_lokasi_baru]
				,[nama_user_baru]
				,[dept_user_baru]
				,[halte_baru]
				,[created_by]
				,[created_date]
			)
			VALUES
			(
				@NO_LAPOR
				,@NO_ASSET
				,@LOKASI
				,@SUB_LOKASI
				,@NAMA_USER
				,@DEPT_USER
				,@HALTE
				,@USERNAME
				,@CREATED_DATE
			);
		END
			

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END ELSE

	IF(@STATUS_KONDISI = 'MODIFIKASI')
	BEGIN
		SET @@CEK_LAPOR = (SELECT COUNT(1) FROM ad_dis_ma_lapor_pindah_asset WHERE [no_lapor] like '%'+ RTRIM(LTRIM(@NO_LAPOR)));
		IF(@@CEK_LAPOR > 0)
		BEGIN
			UPDATE ad_dis_ma_lapor_modifikasi_asset
			SET
			  [harga_baru] = @HARGA
			  ,[cost_upgrade_baru] = @COST_UPGRADE
			  ,[spesifikasi_baru] = @SPESIFIKASI
			  ,[created_by] = @USERNAME
			  ,[created_date] = @CREATED_DATE
			WHERE [no_lapor] like '%'+ RTRIM(LTRIM(@NO_LAPOR) + '%') 
		END ELSE
		BEGIN
			INSERT INTO ad_dis_ma_lapor_modifikasi_asset
			(
			  [no_lapor]
			  ,[no_asset]
			  ,[harga_baru]
			  ,[cost_upgrade_baru]
			  ,[spesifikasi_baru]
			  ,[created_by]
			  ,[created_date]
			)
			VALUES
			(
			  @NO_LAPOR
			  ,@NO_ASSET
			  ,@HARGA
			  ,@COST_UPGRADE
			  ,@SPESIFIKASI
			  ,@USERNAME
			  ,@CREATED_DATE
			);
		END

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

END TRY
BEGIN CATCH

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_ma_lapor_asset:' +@NO_LAPOR+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS, @@CEK_NO_ASSET AS CEK_NOASSET
