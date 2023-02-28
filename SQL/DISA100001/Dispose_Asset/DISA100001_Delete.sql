DECLARE 
	@@CNT INT
	, @@CEK_LAPOR INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);

IF(@typeFunction = 'UPDATE')
	BEGIN
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_dispose_asset_detail WHERE [no_dispose] like '%'+ @NO_DISPOSE AND [no_asset] = @NO_ASSET);
		IF(@@CNT > 0)
		BEGIN
			--Update table Master Asset
			UPDATE ad_dis_ma_master_asset
			SET
				flg_dispose_asset = 0,
				tgl_dispose_asset= NULL
			WHERE
				no_asset = (SELECT no_asset FROM [ad_dis_ma_dispose_asset_detail] WHERE no_dispose = @NO_DISPOSE AND no_asset = @NO_ASSET)
	
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
				(SELECT no_asset FROM [ad_dis_ma_dispose_asset_detail] WHERE NO_DISPOSE = @NO_DISPOSE AND no_asset = @NO_ASSET)
				,'DISPOSE ASSET'
				,'No Dispose Asset: ''' + @NO_DISPOSE + ''' Has been Removed!'
				,'DISPOSE'
				,@USERNAME
				,GETDATE()
			)
			
			--Delete Data Dispose Asset
			DELETE [ad_dis_ma_dispose_asset_detail] WHERE NO_DISPOSE = @NO_DISPOSE AND NO_ASSET = @NO_ASSET;

		END 

		SELECT 'True' AS MSG;
	END ELSE

IF(@typeFunction = 'DELETE')
	BEGIN
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_dispose_asset_detail WHERE [no_dispose] like '%'+ @NO_DISPOSE AND [no_asset] = @NO_ASSET);
		IF(@@CNT > 0)
		BEGIN
			--Update table Master Asset
			UPDATE ad_dis_ma_master_asset
			SET
				flg_dispose_asset = 0,
				tgl_dispose_asset= NULL
			WHERE
				no_asset = (SELECT no_asset FROM [ad_dis_ma_dispose_asset_detail] WHERE no_dispose = @NO_DISPOSE AND no_asset = @NO_ASSET)
	
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
				(SELECT no_asset FROM [ad_dis_ma_dispose_asset_detail] WHERE no_dispose = @NO_DISPOSE AND no_asset = @NO_ASSET)
				,'DISPOSE ASSET'
				,'No Dispose Asset: ''' + @NO_DISPOSE + ''' Has been Removed!'
				,'DISPOSE'
				,@USERNAME
				,GETDATE()
			)

			--Delete Data Dispose Asset Detail
			DELETE [ad_dis_ma_dispose_asset_detail] WHERE no_dispose = @NO_DISPOSE AND no_asset = @NO_ASSET;
			DELETE [ad_dis_ma_dispose_asset] WHERE no_dispose = @NO_DISPOSE;
	
			SELECT 'True' AS MSG;
		END 
	END




