DECLARE 
	  @@CNT INT
	, @@CEK_LAPOR INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@NO_URUT VARCHAR(MAX) = '';

BEGIN TRY
	IF(@NO_LAPOR <> 'null')
	BEGIN
		--UPDATE TABLE LAPOR ASSET
		UPDATE [ad_dis_ma_lapor_asset] 
		SET
			status=LTRIM(@STATUS_KONDISI)
			,updated_by=LTRIM(@USERNAME)
			,updated_date= @UPDATED_DATE
			,keterangan= @KETERANGAN
		WHERE 
			NO_LAPOR= @NO_LAPOR

		--INSERT TABLE LAPOR (MODIFIKASI, PINDAH, REPAIR, RUSAK) ASSET
		IF(@STATUS_KONDISI = 'MODIFIKASI')
		BEGIN
			SET @@CEK_LAPOR = (SELECT COUNT(1) FROM ad_dis_ma_lapor_modifikasi_asset WHERE [no_lapor] like '%'+ RTRIM(LTRIM(@NO_LAPOR)));
			
			IF(@@CEK_LAPOR > 0)
			BEGIN
				--Delete Lapor Pindah
				DELETE FROM 
					ad_dis_ma_lapor_pindah_asset
				WHERE
					NO_LAPOR = @NO_LAPOR

				--Update Data Modifikasi
				UPDATE ad_dis_ma_lapor_modifikasi_asset
				SET
					[harga_baru] = @HARGA_BARU,
					[cost_upgrade_baru] = @COST_UPGRADE_BARU,
					[spesifikasi_baru] = @SPESIFIKASI_BARU
				WHERE
					[no_lapor] = @NO_LAPOR

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
					,@HARGA_BARU
					,@COST_UPGRADE_BARU
					,@SPESIFIKASI_BARU
					,@USERNAME
					,@UPDATED_DATE 
				)
			END
			
			SET @@CHK = 'TRUE';
			SET @@ERR = 'Data Has Been Updated';
		END 
		
		ELSE IF(@STATUS_KONDISI = 'PINDAH')
		BEGIN
			SET @@CEK_LAPOR = (SELECT COUNT(1) FROM ad_dis_ma_lapor_pindah_asset WHERE [no_lapor] like '%'+ RTRIM(LTRIM(@NO_LAPOR)));

			IF(@@CEK_LAPOR > 0)
			BEGIN
				DELETE FROM 
					ad_dis_ma_lapor_modifikasi_asset
				WHERE
					NO_LAPOR = @NO_LAPOR

				--Update Data Pindah
				UPDATE ad_dis_ma_lapor_pindah_asset
				SET
					[kd_lokasi_baru] = @KD_LOKASI_BARU
					,[sub_lokasi_baru] = @SUB_LOKASI_BARU
					,[nama_user_baru] = @NAMA_USER_BARU
					,[dept_user_baru] = @DEPT_USER_BARU
					,[halte_baru] = @HALTE_BARU
				WHERE
					[no_lapor] = @NO_LAPOR

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
					,@KD_LOKASI_BARU
					,@SUB_LOKASI_BARU
					,@NAMA_USER_BARU
					,@DEPT_USER_BARU
					,@HALTE_BARU
					,@USERNAME
					,@UPDATED_DATE 
				)
			END

			SET @@CHK = 'TRUE';
			SET @@ERR = 'Data Has Been Updated';
		END



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
	SET @@ERR = 'ERROR UPDATE ad_dis_ma_lapor_asset: ' + @NO_LAPOR +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
