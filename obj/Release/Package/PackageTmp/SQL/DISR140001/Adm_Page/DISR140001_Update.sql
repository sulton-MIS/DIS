DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
BEGIN TRY
	UPDATE Z_REX_Data_InOut_FG_New 
	SET 
		[qty_std] = @JUMLAH_BDL_STD, 
		[qty] = @JUMLAH_BDL_ACT, 
		[berat_bundle_std] = @BERAT_BDL_STD, 
		[berat_bundle_act] = @BERAT_BDL_ACT, 
		[berat_pcs_std] = @BERAT_PCS_STD, 
		[avg_berat_pcs] = @BERAT_PCS_ACT, 
		[jenis_lotto] = @JENIS_LOTTO, 
		[status_lotto] = @STATUS_LOTTO, 
		[keterangan] = @KETERANGAN, 
		[update_adm] = @username, 
		[update_date] = GETDATE(), 
		[kali_print] = kali_print + 1
	WHERE 
		id_trans = @BUNDLE_CODE

	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE Z_REX_Data_InOut_FG_New:' +@BUNDLE_CODE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS