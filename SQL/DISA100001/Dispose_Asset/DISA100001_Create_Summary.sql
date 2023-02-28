DECLARE 
	@@CNT INT
	, @@CEK_LAPOR INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_dispose_asset WHERE [no_dispose] like '%'+ @NO_DISPOSE);
	IF(@@CNT > 0)
	BEGIN
		UPDATE ad_dis_ma_dispose_asset
		SET
			[nama_foto_laporan] = @NAMA_FILE_LAMPIRAN
			,[updated_by] = @USERNAME
			,[updated_date] = @CREATED_DATE
			,[updated_by_sign] = @CREATED_BY_SIGN
		WHERE
			NO_DISPOSE = @NO_DISPOSE
	END ELSE

	BEGIN
		--Input Dispose Asset
		INSERT INTO ad_dis_ma_dispose_asset
		(
		  [no_dispose]
		  ,[nama_foto_laporan]
		  ,[status_approval]
		  ,[created_by]
		  ,[created_date]
		  ,[created_by_sign]
		)
		VALUES
		(
		  RTRIM(@NO_DISPOSE)
		  ,@NAMA_FILE_LAMPIRAN
		  ,@STATUS_APPROVAL
		  ,@USERNAME
		  ,@CREATED_DATE
		  ,@CREATED_BY_SIGN
		);

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

END TRY
BEGIN CATCH

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_ma_dispose_asset:' +@NO_DISPOSE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
