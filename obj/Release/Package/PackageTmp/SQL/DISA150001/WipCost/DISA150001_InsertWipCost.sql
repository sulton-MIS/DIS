DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
	

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM [ad_dis_pc_wip_cost] WHERE dmc_type = @DMC_CODE_PARTS);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO [ad_dis_pc_wip_cost]
		(
			[DMC_TYPE]
            ,[MATERIAL_COST]
            ,[FINISH_GOODS]
            ,[PRINTING]
            ,[LAMINATING_AKHIR]
            ,[WASHING_GLASS]
            ,[SCRIBE]
            ,[HOGOSIRU]
            ,[PUNCHING]
            ,[SUDAH_PRESS]
            ,[SUDAH_KAPTONTAPE]
            ,[SUDAH_CHUKAN]
            ,[SUDAH_FPC]
            ,[SUDAH_HEATSEAL]
            ,[SUDAH_HARIAWASE]
            ,[SUDAH_AGING]
            ,[SUDAH_OVEN]
            ,[SUDAH_HOKYOTAPE]
            ,[SUDAH_DOUBLETAPE]
            ,[SUDAH_FUREKENSA]
            ,[SUDAH_CEK_KELENGKAPAN]
            ,[SUDAH_DENKI]
            ,[SUDAH_GAIKAN]
		)
		VALUES
		(
			@DMC_CODE_PARTS,
			@MATERIAL_COST,
			@FINISH_GOODS,
			@PRINTING,			
            @LAMINATING_AKHIR,
            @WASHING_GLASS,
            @SCRIBE,
            @HOGOSIRU,
            @PUNCHING,
            @SUDAH_PRESS,
            @SUDAH_KAPTONTAPE,
            @SUDAH_CHUKAN,
            @SUDAH_FPC,
            @SUDAH_HEATSEAL,
            @SUDAH_HARIAWASE,
            @SUDAH_AGING,
            @SUDAH_OVEN,
            @SUDAH_HOKYOTAPE,
            @SUDAH_DOUBLETAPE,
            @SUDAH_FUREKENSA,
            @SUDAH_CEK_KELENGKAPAN,
            @SUDAH_DENKI,
            @SUDAH_GAIKAN
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [ad_dis_pc_wip_cost]:' + @DMC_CODE_PARTS +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
