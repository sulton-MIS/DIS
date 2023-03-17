




BEGIN
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
		(SELECT no_asset FROM [ad_dis_ma_audit_asset] WHERE no_audit= @ID)
		,'AUDIT'
		,'No Audit Asset: ''' + @ID + ''' Has been Removed!'
		,(SELECT status FROM [ad_dis_ma_audit_asset] WHERE no_audit= @ID)
		,@USERNAME
		,GETDATE()
	)

	--Delete Table Audit Asset
	DELETE [ad_dis_ma_audit_asset] WHERE no_audit = @ID;


	SELECT 'True' AS MSG;
END



