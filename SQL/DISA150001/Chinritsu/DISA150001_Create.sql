DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM [ad_dis_pc_master_chinritsu] WHERE id_kotei = @ID_KOTEI and factory = @FACTORY and part = @PART);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO [ad_dis_pc_master_chinritsu]
		(
		  [part]
		  ,[id_kotei]
		  ,[factory]
		  ,[chinritsu]
			
		)
		VALUES
		(
			@PART,
			@ID_KOTEI,
			@FACTORY,
			@CHINRITSU
			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [ad_dis_pc_master_chinritsu]:' +@ID_KOTEI+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
