DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	BEGIN
		INSERT INTO [ad_dis_ma_request_detail_asset]
		(
			no_request_asset, keterangan, nama_asset, pic_request, dept_request, tgl_request, created_by, created_date, status
		)
		VALUES
		(
		   @NOMOR_URUT_REQUEST
		  ,@KETERANGAN
		  ,@NAMA_ASSET
		  ,@PIC_REQUEST
		  ,@DEPT_REQUEST
		  ,@TGL_REQUEST
		  ,@username
		  ,@CREATED_DATE
		  ,@STATUS_REQUEST
		);

		SET @@CNT = SCOPE_IDENTITY();
		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_ma_request_detail_asset:' +@NAMA_ASSET+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

--SELECT @@CHK AS STACK, @@ERR AS LINE_STS,CAST(@@CNT AS VARCHAR(20)) AS WP_PROJECT_JOB_ID


-- OLD
--DECLARE @@CNT INT
--	, @@CHK VARCHAR(20)
--	, @@ERR VARCHAR(MAX);


--BEGIN TRY
--	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_request_asset WHERE no_request_asset = @NOMOR_URUT_REQUEST);
	

--	IF(@@CNT > 0)
--	BEGIN

--		SET @@CHK = 'FALSE';
--		SET @@ERR = 'DUPLICATE';
		
--	END ELSE
--	BEGIN
		
--		INSERT INTO ad_dis_ma_request_asset_detail
--		(
--		  no_request_asset, nama_asset, pic_request, dept_request, created_by, created_date
--		)
--		VALUES
--		(
--		  @NOMOR_URUT_REQUEST
--		  ,@NAMA_ASSET
--		  ,@PIC_REQUEST
--		  ,@DEPT_REQUEST
--		  ,@username
--		  ,@TGL_REQUEST
--		);

--		SET @@CHK = 'TRUE';
--		SET @@ERR = 'NOTHING';
--	END

--END TRY
--BEGIN CATCH

	

--	SET @@CHK = 'FALSE';
--	SET @@ERR = 'ERROR INSERT ad_dis_ma_request_asset_detail:' +@NOMOR_URUT_REQUEST+
--	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
--END CATCH

--SELECT @@CHK AS STACK, @@ERR AS LINE_STS
