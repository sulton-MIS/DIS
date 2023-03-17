




BEGIN
	--Update table Master Asset
	UPDATE ad_dis_ma_master_asset
	SET
		flg_dispose_asset = 0,
		tgl_dispose_asset= NULL
	WHERE
		no_asset = (SELECT no_asset FROM [ad_dis_ma_dispose_asset] WHERE no_dispose = @ID)
	
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
		(SELECT no_asset FROM [ad_dis_ma_dispose_asset] WHERE no_dispose = @ID)
		,'DISPOSE ASSET'
		,'No Dispose Asset: ''' + @ID + ''' Has been Removed!'
		,'DISPOSE'
		,@USERNAME
		,GETDATE()
	)
	
	--Delete Data Dispose Asset
	DELETE [ad_dis_ma_dispose_asset] WHERE no_dispose = @ID;
	

	SELECT 'True' AS MSG;
END



