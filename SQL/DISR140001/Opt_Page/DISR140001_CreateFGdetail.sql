DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	BEGIN
		INSERT INTO Z_REX_Data_InOut_FG_Detail
		(
			id_trans,
			id_produksi,
			dmc_code,
			id_proses,
			--nama_proses,
			serial_no,
			lot_no,
			berat_per_pcs,
			remarkss,
			shf,
			trans_date,
			pic
		)
		VALUES
		(
			@BUNDLE_CODE,
			@ID_PRODUKSI,
			@DMC_CODE,
			@ID_PROSES,
			--@NAMA_PROSES,
			@SERIAL,
			@LOTNO,
			@BERAT_PCS_ACT,
			@KETERANGAN,
			@SHIFT,
			GETDATE(),
			@NAMA
		);

		SET @@CNT = SCOPE_IDENTITY();
		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
	
	
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT Z_REX_Data_InOut_FG_Detail:' +@BUNDLE_CODE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS,CAST(@@CNT AS VARCHAR(20)) AS WP_PROJECT_JOB_ID
