




BEGIN
	UPDATE Z_RT_master_sagyosha SET flg_opmj = @status_opmj	WHERE id_sagyosha = @ID;
	SELECT 'True' AS MSG;
	
END



