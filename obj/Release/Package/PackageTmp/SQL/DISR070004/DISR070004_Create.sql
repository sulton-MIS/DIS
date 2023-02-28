DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM Z_RT_master_kikai WHERE id_kikai = @id_kikai);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO Z_RT_master_kikai
		(
			 [id_kikai]
			,[name_kikai]
			,[id_koteishubetsu]
			--,[odr_yusen]
			--,[num_fuguairitsu]
			,[IPaddress]
			,[line]
			,[cluster]
			,[factory]
			,[comment]
			,[time_koshin]
			,[group_kikai]
			,[group_kikai_sort]
			,[flg_visible_oven]
			,[machine_name]
			,[initial_kikai]
		)
		VALUES
		(
			@id_kikai,
			@name_kikai,
			@id_koteishubetsu,
			@IPaddress,
			@line,
			@cluster,
			@factory,
			@comment,
			GETDATE(),
			@group_kikai,
			@group_kikai_sort,
			--@flg_visible_oven,
			0,
			@machine_name,
			@initial_kikai
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		
	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT Z_RT_master_kikai:' +@id_kikai+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
