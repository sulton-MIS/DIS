DECLARE 
	@@CNT INT
	, @@CEK_LAPOR INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_ma_audit_asset WHERE [no_audit] like '%'+ @NO_AUDIT);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		--Input Audit Asset
		INSERT INTO ad_dis_ma_audit_asset
		(
		  [no_audit]
		  ,[no_asset]
		  ,[jenis_audit]
		  ,[periode_bulan]
		  ,[periode_semester]
		  ,[tahun]
		  ,[status]
		  ,[keterangan]
		  ,[nama_foto_audit]
		  ,[created_by]
		  ,[created_date]
		)
		VALUES
		(
		  @NO_AUDIT
		  ,@NO_ASSET
		  ,@JENIS_AUDIT
		  ,@PERIODE_BULAN
		  ,@PERIODE_SEMESTER
		  ,@TAHUN
		  ,@STATUS_KONDISI
		  ,@KETERANGAN
		  ,@FOTO_NAME
		  ,@USERNAME
		  ,@CREATED_DATE
		);

		--Update Status Asset
		UPDATE [ad_dis_ma_master_asset] 
			SET 
			keterangan= LTRIM(@KETERANGAN),
			status_audit = LTRIM(@STATUS_AUDIT),
			status= LTRIM(@STATUS_KONDISI)
		WHERE
			NO_ASSET = @NO_ASSET

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
			@NO_ASSET
			,'AUDIT ASSET'
			,'Create Audit Asset: ''' + @NO_AUDIT + ''''
			,@STATUS_KONDISI
			,@USERNAME
			,GETDATE()
		)

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END

END TRY
BEGIN CATCH

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_ma_audit_asset:' +@NO_AUDIT+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
