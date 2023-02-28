DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM Y_ConvertionTablePacking WHERE ItemCode = @ItemCode);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO Y_ConvertionTablePacking
		(			 
			[ItemCode],
            [Parts],
            [SizeProduct],
            [type],
            [BundleQty],
            [InnerQty],
            [MasterQty],
            [InnerType],
            [InnerL],
            [InnerW],
            [InnerH],
            [InnerWeight],
            [MasterType],
            [MasterL],
            [MasterW],
            [MasterH],
            [MasterWeight]
			
		)
		VALUES
		(
			@ItemCode,
            @Parts,
            @SizeProduct,
            @type,
            @BundleQty,
            @InnerQty,
            @MasterQty,
            @InnerType,
            @InnerL,
            @InnerW,
            @InnerH,
            @InnerWeight,
            @MasterType,
            @MasterL,
            @MasterW,
            @MasterH,
            @MasterWeight
			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT Y_ConvertionTablePacking:' +@ItemCode+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
