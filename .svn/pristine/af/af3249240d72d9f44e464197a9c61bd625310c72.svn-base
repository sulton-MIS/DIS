DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE Z_RT_master_sagyosha SET
	    id_sagyosha = @id_sagyosha,
		name_sagyosha = @name_sagyosha,
		dept = @dept,
		bagian = @bagian,
		jabatan = @jabatan,
		grp = @grp,
		comment = @comment,
		tmk = @tmk			
	WHERE id_sagyosha = @ID

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE TB_M_EMPLOYEE: ' + @id_sagyosha +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
