DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_request_asset WHERE no_request_asset = @NOMOR_URUT_REQUEST);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_ma_request_asset
		(
		  no_request_asset, nama_asset, qty_asset, pic_request, dept_request, tgl_request
		)
		VALUES
		(
		  @NOMOR_URUT_REQUEST
		  ,@NAMA_ASSET
		  ,@QTY
		  ,@PIC_REQUEST
		  ,@DEPARTMENT
		  ,@TGL_REQUEST
		);

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_ma_request_asset:' +@NOMOR_URUT_REQUEST+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
