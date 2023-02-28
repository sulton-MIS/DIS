
DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);

BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM Z_RT_master_tool WHERE id_tool = @ID_TOOL and name_tool = @NAME_TOOL);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO Z_RT_master_tool
		(
			   [id_tool]
			  ,[name_tool]
			  ,[factory]
			  ,[lifetime]		
			  ,[limit]
			  ,[status]
			  ,[time_koshin]
			
		)
		VALUES
		(
			@ID_TOOL
			,@NAME_TOOL
			,@FACTORY
			,@LIFETIME						
			,@LIMIT
			,'AKTIF'
			,GETDATE()
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [master_tool]:' +@ID_TOOL+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
