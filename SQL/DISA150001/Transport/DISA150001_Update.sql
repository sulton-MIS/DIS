DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_pc_master_transportation SET
			item_code = @item_code,			
            lot_size = @lot_size,
            master_qty = @master_qty,
            box_qty = @box_qty,
            weight = @weight,
            total_weight = @total_weight,
            jenis_transportation = @jenis_transportation,
            transportation_cost = @transportation_cost,
            awb_free_jpn = @awb_free_jpn,
            edi_free_air_jpn = @edi_free_air_jpn,
            ams_free_jpn = @ams_free_jpn,
            trucking_0_250_kg_jpn = @trucking_0_250_kg_jpn,
            handling_air_under_50_kg_jpn = @handling_air_under_50_kg_jpn,
            handling_air_upto_50_kg = @handling_air_upto_50_kg,
            total_cost = @total_cost	
	WHERE id_trans = @ID

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_pc_master_transportation: ' + @item_code +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
