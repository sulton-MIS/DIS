




BEGIN
	UPDATE [ad_dis_ma_request_detail_asset]
	SET 
		STATUS = @STATUS
	WHERE 
		id_tb_m_req_asset= @ID;

	---------------------OLD 2022/06/29----------------------------------
	--DELETE [ad_dis_ma_request_detail_asset] 
	--WHERE 
	--id_tb_m_req_asset= @ID;


	SELECT 'True' AS MSG;
	
END



