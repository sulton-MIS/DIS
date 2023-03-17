DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE [ad_dis_pc_transportation_sum] SET
				item_code = @item_code,
                code_trans = @code_trans,
                lot_size = @lot_size,
                master_type = @master_type,
                master_qty = @master_qty,
                qty_box = @qty_box,
                master_weight = @master_weight,
                total_cost = @total_cost
	WHERE item_code = @item_code and code_trans = @code_trans 

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE [ad_dis_pc_transportation_sum]: ' + @item_code +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
