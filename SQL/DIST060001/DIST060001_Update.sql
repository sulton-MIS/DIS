DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE Y_ConvertionTablePacking SET
			ItemCode = @ItemCode,
            Parts = @Parts,
            SizeProduct = @SizeProduct,
            type = @type,
            BundleQty = @BundleQty,
            InnerQty = @InnerQty,
            MasterQty = @MasterQty,
            InnerType = @InnerType,
            InnerL = @InnerL,
            InnerW = @InnerW,
            InnerH = @InnerH,
            InnerWeight = @InnerWeight,
            MasterType = @MasterType,
            MasterL = @MasterL,
            MasterW = @MasterW,
            MasterH = @MasterH,
            MasterWeight = @MasterWeight	
	WHERE ItemCode = @ItemCode

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE Y_ConvertionTablePacking: ' + @ItemCode +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
