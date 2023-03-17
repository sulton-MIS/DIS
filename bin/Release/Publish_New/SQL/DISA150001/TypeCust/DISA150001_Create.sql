DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM [ad_dis_pc_master_type_cust] WHERE dmc_type = @Dmc_Type);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO [ad_dis_pc_master_type_cust]
		(			 
			[dmc_type]
		  ,[customer]
		  ,[touch_panel_size]
		  ,[wis_version]
		  ,[lot_size]
		  ,[in_direct]
		  ,[sga]
			
		)
		VALUES
		(
			@Dmc_Type,
            @Customer,
            @Touch_Panel_Size,
            @Wis_Version,
            @Lot_Size,
            @In_Direct,
            @Sga
			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [ad_dis_pc_master_type_cust]:' +@Dmc_Type+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
