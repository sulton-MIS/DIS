DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
DECLARE @@MSG_TEXT VARCHAR(MAX);
DECLARE @@MSG_TYPE VARCHAR(MAX);

BEGIN TRY
	BEGIN
		INSERT INTO Z_REX_Data_InOut_FG_New
		(
		   [id_trans]
		  ,[dmc_code]
		  ,[qty_std]
		  ,[qty]
		  ,[berat_bundle_std]
		  ,[berat_bundle_act]
		  ,[berat_pcs_std]
		  ,[avg_berat_pcs]
		  ,[jenis_lotto]
		  ,[status_lotto]
		  ,[nik_gaikan]
		  ,[opr_gaikan]
		  ,[keterangan]
		  ,[shf]
		  ,[kali_print]
		  ,[trans_date]
		  ,[input_adm]
		  ,[input_date] 
		)
		VALUES
		(
			@BUNDLE_CODE,
			@DMC_CODE,
			@JUMLAH_BDL_STD,
			@JUMLAH_BDL_ACT,
			@BERAT_BDL_STD,
			@BERAT_BDL_ACT,
			@BERAT_PCS_STD,
			@BERAT_PCS_ACT,
			@JENIS_LOTTO,
			@STATUS_LOTTO,
			@NIK,
			@NAMA,
			@KETERANGAN,
			@SHIFT,
			1,
			GETDATE(),
			@NIK_ADM,
			@INPUT_ADM_DATE
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