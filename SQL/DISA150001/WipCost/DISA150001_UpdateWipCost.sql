DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE [ad_dis_pc_wip_cost] SET
			dmc_type = @DMC_CODE_PARTS,
			material_cost = @MATERIAL_COST,
			finish_goods = @FINISH_GOODS,
			printing = @PRINTING,
			laminating_akhir = @LAMINATING_AKHIR,
            washing_glass = @WASHING_GLASS,
            scribe = @SCRIBE,
            hogosiru = @HOGOSIRU,
            punching = @PUNCHING,
            sudah_press = @SUDAH_PRESS,
            sudah_kaptontape = @SUDAH_KAPTONTAPE,
            sudah_chukan = @SUDAH_CHUKAN,
            sudah_fpc = @SUDAH_FPC,
            sudah_heatseal = @SUDAH_HEATSEAL,
            sudah_hariawase = @SUDAH_HARIAWASE,
            sudah_aging = @SUDAH_AGING,
            sudah_oven = @SUDAH_OVEN,
            sudah_hokyotape = @SUDAH_HOKYOTAPE,
            sudah_doubletape = @SUDAH_DOUBLETAPE,
            sudah_furekensa = @SUDAH_FUREKENSA,
            sudah_cek_kelengkapan = @SUDAH_CEK_KELENGKAPAN,
            sudah_denki = @SUDAH_DENKI,
            sudah_gaikan = @SUDAH_GAIKAN         
	WHERE dmc_type = @DMC_CODE_PARTS

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE [ad_dis_pc_wip_cost]: ' + @DMC_CODE_PARTS + 
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
