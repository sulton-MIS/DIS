DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_pc_production_cost_material_usage SET			
			dmc_code = @DMC_CODE,
			part = @PART,
			dmc_code_parts = @DMC_CODE_PARTS,
			kode_proses = @KODE_PROSES,
			nama_proses = @NAMA_PROSES,
			setting_time = @SETTING_TIME,
			cycle_time = @CYCLE_TIME
	WHERE dmc_code_parts = @DMC_CODE_PARTS and kode_proses = @KODE_PROSES 

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_pc_production_cost_material_usage: ' + @DMC_CODE_PARTS + 
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
