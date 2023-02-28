




BEGIN
	DELETE ad_dis_rtjn_sum_qty_amount_target WHERE target_date = @ID;
	SELECT 'True' AS MSG;
	
END



