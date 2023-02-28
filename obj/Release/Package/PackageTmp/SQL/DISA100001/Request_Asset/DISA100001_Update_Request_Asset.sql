DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);

BEGIN TRY
	IF(@NO_REQUEST_ASSET <> 'null')
	BEGIN
	--Update table Request Asset (ubah Nama_Asset)
	UPDATE [ad_dis_ma_request_detail_asset] 
	SET
		NAMA_ASSET=LTRIM(@NAMA_ASSET)
	WHERE id_tb_m_req_asset= @ID

	--Update table Request Asset (ubah PIC_Request & Dept_Request)
	UPDATE [ad_dis_ma_request_detail_asset]
	SET
		pic_request=LTRIM(@PIC_REQUEST),
		dept_request=LTRIM(@DEPT_REQUEST)
	WHERE no_request_asset = @NO_REQUEST_ASSET
	

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
	SET @@ERR = 'ERROR UPDATE ad_dis_ma_request_asset: ' + @ID +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
