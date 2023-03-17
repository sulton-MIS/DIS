DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_pc_master_type_cust SET
			dmc_type = @Dmc_Type,
            customer = @Customer,
            touch_panel_detail = @Touch_Panel_Detail,
            wis_version = @Wis_Version,
            lot_size = @Lot_Size,
            in_direct = @In_Direct,
            sga = @Sga
	WHERE dmc_type = @Dmc_Type

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_pc_master_type_cust: ' + @Dmc_Type +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
