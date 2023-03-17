DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM Z_REX_Data_InOut_FG_Detail WHERE id_trans = @BUNDLE_CODE and id_produksi = @ID_PRODUKSI);
	IF(@@CNT > 0)
	BEGIN
		UPDATE Z_REX_Data_InOut_FG_Detail
		SET id_proses = @ID_PROSES,
			nama_proses = @NAMA_PROSES,
			serial_no = @SERIAL,
			lot_no = @LOTNO,
			berat_per_pcs = @BERAT_PCS_ACT,
			remarkss = '-',
			shf = 1,
			trans_date = GETDATE(),
			pic = @NAMA
		WHERE id_trans = @BUNDLE_CODE and id_produksi = @ID_PRODUKSI

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END ELSE
	BEGIN
		INSERT INTO Z_REX_Data_InOut_FG_Detail
		(
			id_trans,
			id_produksi,
			dmc_code,
			id_proses,
			nama_proses,
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
			@NAMA_PROSES,
			@SERIAL,
			@LOTNO,
			@BERAT_PCS_ACT,
			'-',
			1,
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

--DECLARE @@CNT INT
--	, @@CHK VARCHAR(20)
--	, @@ERR VARCHAR(MAX);
--DECLARE @@MSG_TEXT VARCHAR(MAX);
--DECLARE @@MSG_TYPE VARCHAR(MAX);

--BEGIN TRY
--	SET @@CNT = (SELECT COUNT(1) FROM Z_REX_Data_InOut_FG_Detail WHERE id_trans = @BUNDLE_CODE and id_produksi = @ID_PRODUKSI);
--	IF(@@CNT > 0)
--	BEGIN
--		UPDATE Z_REX_Data_InOut_FG_Detail
--		SET id_proses = @ID_PROSES,
--			nama_proses = @NAMA_PROSES,
--			serial_no = @SERIAL,
--			lot_no = @LOTNO,
--			berat_per_pcs = @BERAT_PCS_ACT,
--			remarkss = '-',
--			shf = 1,
--			trans_date = GETDATE(),
--			pic = @NAMA
--		WHERE id_trans = @BUNDLE_CODE and id_produksi = @ID_PRODUKSI

--		SET @@CHK = 'TRUE';
--		SET @@ERR = 'NOTHING';
--	END ELSE
--	BEGIN
--		INSERT INTO Z_REX_Data_InOut_FG_Detail
--		(
--			id_trans,
--			id_produksi,
--			dmc_code,
--			id_proses,
--			nama_proses,
--			serial_no,
--			lot_no,
--			berat_per_pcs,
--			remarkss,
--			shf,
--			trans_date,
--			pic
--		)
--		VALUES
--		(
--			@BUNDLE_CODE,
--			@ID_PRODUKSI,
--			@DMC_CODE,
--			@ID_PROSES,
--			@NAMA_PROSES,
--			@SERIAL,
--			@LOTNO,
--			@BERAT_PCS_ACT,
--			'-',
--			1,
--			GETDATE(),
--			@NAMA
--		);

--		SET @@CNT = SCOPE_IDENTITY();
--		SET @@CHK = 'TRUE';
--		SET @@ERR = 'NOTHING';
--	END
--END TRY
--BEGIN CATCH
--	SET @@CHK = 'FALSE';
--	SET @@ERR = 'ERROR INSERT Z_REX_Data_InOut_FG_Detail:' +@BUNDLE_CODE+
--	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
--END CATCH

--SELECT @@CHK AS STACK, @@ERR AS LINE_STS,CAST(@@CNT AS VARCHAR(20)) AS WP_PROJECT_JOB_ID