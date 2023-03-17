DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM Z_REX_Data_InOut_FG_New WHERE id_trans = @BUNDLE_CODE and dmc_code = @DMC_CODE);
	IF(@@CNT > 0)
	BEGIN

		UPDATE Z_REX_Data_InOut_FG_New
		SET qty_std = @JUMLAH_BDL_STD,
			qty = @JUMLAH_BDL_ACT,
			berat_std = @BERAT_BDL_STD,
			berat_act = @BERAT_BDL_ACT,
			jenis_lotto = 'Serial',
			status_lotto = 'Non Campuran',
			nik_gaikan = @NIK,
			opr_gaikan = @NAMA,
			keterangan = '-',
			shf = 1,
			kali_print = 1,
			trans_date = GETDATE()
		WHERE id_trans = @BUNDLE_CODE and dmc_code = @DMC_CODE

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

	END ELSE
	BEGIN
		INSERT INTO Z_REX_Data_InOut_FG_New
		(
			 [id_trans]
		  ,[dmc_code]
		  ,[qty_std]
		  ,[qty]
		  ,[berat_std]
		  ,[berat_act]
		  ,[jenis_lotto]
		  ,[status_lotto]
		  ,[nik_gaikan]
		  ,[opr_gaikan]
		  ,[keterangan]
		  ,[shf]
		  ,[kali_print]
		  ,[trans_date]
			
		)
		VALUES
		(
			@BUNDLE_CODE,
			@DMC_CODE,
			@JUMLAH_BDL_STD,
			@JUMLAH_BDL_ACT,
			@BERAT_BDL_STD,
			@BERAT_BDL_ACT,
			'Serial',
			'Non Campuran',
			@NIK,
			@NAMA,
			'-',
			1,
			1,
			GETDATE()
		);

		SET @@CNT = SCOPE_IDENTITY();

		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';
	END
END TRY
BEGIN CATCH
	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT Z_REX_Data_InOut_FG_New:' +@BUNDLE_CODE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS,CAST(@@CNT AS VARCHAR(20)) AS WP_PROJECT_ID