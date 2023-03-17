
DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM [ad_dis_rtjn_master_actual_masalah] WHERE halte = @HALTE and date = @DATE and time = @TIME);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO [ad_dis_rtjn_master_actual_masalah]
		(
			   [halte]
			  ,[date]
			  ,[time]
			  ,[opmj]
			  ,[masalah]
			  ,[action]
			
		)
		VALUES
		(
			@HALTE
			,@DATE
			,@TIME
			,@OPMJ
			,@MASALAH
			,@ACTION			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [ad_dis_rtjn_master_actual_masalah]:' +@HALTE+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
