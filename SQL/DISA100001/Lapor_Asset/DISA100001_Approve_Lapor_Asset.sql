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
		,'LAPOR ASSET'
		,@KETERANGAN
		,@STATUS_KONDISI
		,@USERNAME
		,GETDATE()
	)

	--Update table Master Asset
	IF (@STATUS_KONDISI='PINDAH')
	BEGIN
	UPDATE ad_dis_ma_master_asset 
	SET
		nama_user= (SELECT dt_lapor_pindah.nama_user_baru FROM [ad_dis_ma_lapor_pindah_asset] AS dt_lapor_pindah WHERE dt_lapor_pindah.no_lapor = @ID),
		dept_user = (SELECT dt_lapor_pindah.dept_user_baru FROM [ad_dis_ma_lapor_pindah_asset] AS dt_lapor_pindah WHERE dt_lapor_pindah.no_lapor = @ID),
		halte = (SELECT dt_lapor_pindah.halte_baru FROM [ad_dis_ma_lapor_pindah_asset] AS dt_lapor_pindah WHERE dt_lapor_pindah.no_lapor = @ID),
		kd_lokasi = (SELECT dt_lapor_pindah.kd_lokasi_baru FROM [ad_dis_ma_lapor_pindah_asset] AS dt_lapor_pindah WHERE dt_lapor_pindah.no_lapor = @ID),
		keterangan = (SELECT keterangan FROM  ad_dis_ma_lapor_asset WHERE no_lapor = @ID),
		status= 'OK',
		--status=LTRIM(@STATUS_KONDISI),
		updated_by=LTRIM(@USERNAME),
		updated_date=@DATE_APPROVAL
	WHERE 
		NO_ASSET= @NO_ASSET
	END ELSE

	IF (@STATUS_KONDISI='MODIFIKASI')
	BEGIN
	UPDATE ad_dis_ma_master_asset 
	SET
		harga_satuan = (SELECT dt_lapor_modifikasi.harga_baru FROM [ad_dis_ma_lapor_modifikasi_asset] AS dt_lapor_modifikasi WHERE dt_lapor_modifikasi.no_lapor = @ID),
		cost_upgrade = (SELECT dt_lapor_modifikasi.cost_upgrade_baru FROM [ad_dis_ma_lapor_modifikasi_asset] AS dt_lapor_modifikasi WHERE dt_lapor_modifikasi.no_lapor = @ID),
		spesifikasi = (SELECT dt_lapor_modifikasi.spesifikasi_baru FROM [ad_dis_ma_lapor_modifikasi_asset] AS dt_lapor_modifikasi WHERE dt_lapor_modifikasi.no_lapor = @ID),
		keterangan = (SELECT keterangan FROM  ad_dis_ma_lapor_asset WHERE no_lapor = @ID),
		status= 'OK',
		--status=LTRIM(@STATUS_KONDISI),
		updated_by=LTRIM(@USERNAME),
		updated_date=@DATE_APPROVAL
	WHERE 
		NO_ASSET= @NO_ASSET
	END ELSE

	IF (@STATUS_KONDISI='RUSAK')
	BEGIN
	UPDATE ad_dis_ma_master_asset 
	SET
		keterangan = (SELECT keterangan FROM  ad_dis_ma_lapor_asset WHERE no_lapor = @ID),
		status= 'NG',
		updated_by=LTRIM(@USERNAME),
		updated_date=@DATE_APPROVAL
	WHERE 
		NO_ASSET= @NO_ASSET
	END ELSE
	
	IF (@STATUS_KONDISI='REPAIR')
	BEGIN
	UPDATE ad_dis_ma_master_asset 
	SET
		keterangan = (SELECT keterangan FROM  ad_dis_ma_lapor_asset WHERE no_lapor = @ID),
		status= 'OK',
		updated_by=LTRIM(@USERNAME),
		updated_date=@DATE_APPROVAL
	WHERE 
		NO_ASSET= @NO_ASSET
	END 



	--Update table Lapor Asset
	UPDATE ad_dis_ma_lapor_asset 
	SET
		flg_approval_lapor=1,
		approval_by=LTRIM(@USERNAME),
		approval_date=@DATE_APPROVAL
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
