DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
	


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_pc_price_list WHERE dmc_type = @DMC_TYPE and customer = @CUSTOMER and jenis_transportation = @JENIS_TRANSPORTATION);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_pc_price_list
		(
			 [dmc_type]
            ,[customer]
            ,[touch_panel_type]
            ,[touch_panel_size]
            ,[versi_wis]
            ,[total_yield_film]
            ,[jenis_transportation]
            ,[lot_10]
            ,[lot_20]
            ,[lot_50]
            ,[lot_100]
            ,[lot_200]
            ,[lot_300]
            ,[lot_400]
            ,[lot_500]
            ,[lot_1000]
            ,[lot_5000]
		)
		VALUES
		(
			@DMC_TYPE,
			@CUSTOMER,
			@TOUCH_PANEL_TYPE,		
			@TOUCH_PANEL_SIZE,
			@VERSI_WIS,			
            @TOTAL_YIELD_FILM,
			@JENIS_TRANSPORTATION,
			@LOT_10,
			@LOT_20,
			@LOT_50,
			@LOT_100,
			@LOT_200,
			@LOT_300,
			@LOT_400,
			@LOT_500,
			@LOT_1000,
			@LOT_5000
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_pc_price_list:' + @DMC_TYPE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
