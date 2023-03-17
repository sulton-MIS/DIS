DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);
	


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM [ad_dis_pc_transportation_sum] WHERE item_code = @item_code and code_trans = @code_trans);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO [ad_dis_pc_transportation_sum]
		(
			 [item_code]
			  ,[code_trans]
			  ,[lot_size]
			  ,[master_type]
			  ,[master_qty]
			  ,[qty_box]
			  ,[master_weight]
			  ,[total_cost]
		)
		VALUES
		(
				@item_code,
                @code_trans,
                @lot_size,
                @master_type,
                @master_qty,
                @qty_box,
                @master_weight,
                @total_cost
			

		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT [ad_dis_pc_transportation_sum]:' + @item_code +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
