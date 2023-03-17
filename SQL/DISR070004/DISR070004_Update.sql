DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE Z_RT_master_kikai 
	SET
	    id_kikai = @id_kikai,
		name_kikai = @name_kikai,
		id_koteishubetsu = @id_koteishubetsu,
		ipaddress = @IPaddress,
		line = @line,
		cluster = @cluster,
		factory = @factory,
		comment = @comment,
		time_koshin = GETDATE(),
		group_kikai= @group_kikai,
		group_kikai_sort= @group_kikai_sort,
		machine_name= @machine_name,
		initial_kikai= @initial_kikai
		
	WHERE id_kikai = @id_kikai
		
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE Z_RT_master_kikai: ' + @id_kikai +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
