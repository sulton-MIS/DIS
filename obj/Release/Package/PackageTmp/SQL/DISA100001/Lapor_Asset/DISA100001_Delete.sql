DECLARE @@STATUS_LAPOR VARCHAR(MAX) = '';

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
		(SELECT no_asset FROM [ad_dis_ma_lapor_asset] WHERE no_lapor = @ID)
		,'LAPOR ASSET'
		,'No Lapor Asset: ''' + @ID + ''' Has been Removed!'
		,(SELECT dt_lapor.status FROM [ad_dis_ma_master_asset] master_asset LEFT JOIN [ad_dis_ma_lapor_asset] dt_lapor ON master_asset.no_asset = dt_lapor.no_asset WHERE dt_lapor.no_lapor = @ID)
		,@USERNAME
		,GETDATE()
	)
	
	--Get Status From Summary Lapor
	SET @@STATUS_LAPOR = (SELECT status FROM [ad_dis_ma_lapor_asset] WHERE no_lapor= @ID);

	
	--Delete From Detail Lapor (Pindah, Modifikasi)
	IF (@@STATUS_LAPOR = 'PINDAH')
	BEGIN
		DELETE [ad_dis_ma_lapor_pindah_asset] WHERE no_lapor = @ID;
	END ELSE
	IF (@@STATUS_LAPOR = 'MODIFIKASI')
	BEGIN
		DELETE [ad_dis_ma_lapor_modifikasi_asset] WHERE no_lapor = @ID;
	END

	--Delete Summary Lapor
	DELETE [ad_dis_ma_lapor_asset] WHERE no_lapor = @ID;
	
	SELECT 'True' AS MSG;
END



