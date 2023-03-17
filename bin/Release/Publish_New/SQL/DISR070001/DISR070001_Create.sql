DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM Z_RT_master_sagyosha WHERE id_sagyosha = @id_sagyosha);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO Z_RT_master_sagyosha
		(
			 [name_sagyosha]
			,[id_sagyosha]
			,[dept]
			,[bagian]
			,[jabatan]
			,[grp]
			,[comment]
			,[time_koshin]
			,[tmk]
			
		)
		VALUES
		(
			@name_sagyosha,
			@id_sagyosha,
			@dept,
			@bagian,
			@jabatan,
			@grp,
			@comment,
			GETDATE(),
			@tmk
			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT Z_RT_master_sagyosha:' +@id_sagyosha+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
