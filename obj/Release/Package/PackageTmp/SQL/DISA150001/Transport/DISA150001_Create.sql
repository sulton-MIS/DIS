DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_pc_master_transportation WHERE item_code = @item_code and jenis_transportation = @jenis_transportation);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_pc_master_transportation
		(			 
			[item_code],
            [lot_size],
            [master_qty],
            [box_qty],
            [weight],
            [total_weight],
            [jenis_transportation],
            [transportation_cost],
            [awb_free_jpn],
            [edi_free_air_jpn],
            [ams_free_jpn],
            [trucking_0_250_kg_jpn],
            [handling_air_under_50_kg_jpn],
            [handling_air_upto_50_kg],
            [total_cost]
			
		)
		VALUES
		(
			@item_code,
            @lot_size,
            @master_qty,
            @box_qty,
            @weight,
            @total_weight,
            @jenis_transportation,
            @transportation_cost,
            @awb_free_jpn,
            @edi_free_air_jpn,
            @ams_free_jpn,
            @trucking_0_250_kg_jpn,
            @handling_air_under_50_kg_jpn,
            @handling_air_upto_50_kg,
            @total_cost
			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_pc_master_transportation:' +@item_code+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
