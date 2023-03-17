DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX)
	, @@NO_URUT VARCHAR(MAX) = '';

BEGIN TRY
	IF(@NO_ASSET <> 'null' AND @KETERANGAN <> '')
	BEGIN
	--Update table Master Asset
	UPDATE ad_dis_ma_master_asset 
	SET
		nama_asset=LTRIM(@NAMA_ASSET),
		nama_asset_invoice=LTRIM(@NAMA_ASSET_INVOICE),
		item_code=LTRIM(@ITEM_CODE),
		merek=LTRIM(@MEREK),
		tipe=LTRIM(@TIPE),
		supplier=LTRIM(@SUPPLIER),
		harga_satuan=LTRIM(@HARGA_SATUAN),
		cost_upgrade=LTRIM(@COST_UPGRADE),
		spesifikasi=LTRIM(@SPESIFIKASI),
		keterangan=LTRIM(@NOTE_KETERANGAN),
		umur=LTRIM(@UMUR_EKONOMIS),
		dept_user=LTRIM(@DEPT_USER),
		nama_user=LTRIM(@NAMA_USER),
		kd_lokasi=LTRIM(@KD_LOKASI),
		halte =LTRIM(@HALTE),
		status=LTRIM(@STATUS_KONDISI),
		status_penggunaan=LTRIM(@STATUS_PENGGUNAAN),
		flg_label_asset=LTRIM(@FLG_LABEL_ASSET),
		updated_by=LTRIM(@USERNAME),
		updated_date=@DATE_UPDATED
	WHERE 
		NO_ASSET= @NO_ASSET

	--UPDATE TABLE Request Detail Asset
	UPDATE ad_dis_ma_request_detail_asset
	SET
		status=LTRIM(@STATUS_PENGADAAN)
	WHERE 
		id_tb_m_req_asset=LTRIM(@ID_TB_M_REQ_ASSET)

	--Input ke tabel History Asset
	IF(@KETERANGAN <> '')
	BEGIN
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
		@ID
		,'INVENTARISASI'
		,@KETERANGAN
		,'MODIFIKASI'
		,@USERNAME
		,@DATE_UPDATED
	)
	END

	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
	END ELSE
	BEGIN
		SET @@CHK = 'FALSE';
		SET @@ERR = 'NO DATA HAS BEEN CHANGED!';	
	END 
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_ma_master_asset: ' + @NO_ASSET +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
