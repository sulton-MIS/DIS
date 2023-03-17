DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE [ad_dis_pc_master_unit_price] SET
			item_code = @ITEM_CODE,
            unit_price = @UNIT_PRICE
	WHERE item_code = @ITEM_CODE

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE [ad_dis_pc_master_unit_price]: ' + @ITEM_CODE +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
