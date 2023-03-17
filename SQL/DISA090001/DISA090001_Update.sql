﻿DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_rtjn_sum_qty_amount_target SET
	      target_date = @target_date,   
		  halte = @halte,   
          target_print_qty =  @target_print_qty,
			target_qty_jam_ke_1 =  @target_qty_jam_ke_1,
			target_amount_jam_ke_1 =  @target_amount_jam_ke_1,
			target_qty_jam_ke_2 =  @target_qty_jam_ke_2,
			target_amount_jam_ke_2 =  @target_amount_jam_ke_2,
			target_qty_jam_ke_3 =  @target_qty_jam_ke_3,
			target_amount_jam_ke_3 =  @target_amount_jam_ke_3,
			target_qty_jam_ke_4 =  @target_qty_jam_ke_4,
			target_amount_jam_ke_4 =  @target_amount_jam_ke_4,
			target_qty_jam_ke_5 =  @target_qty_jam_ke_5,
			target_amount_jam_ke_5 =  @target_amount_jam_ke_5,
			target_qty_jam_ke_6 =  @target_qty_jam_ke_6,
			target_amount_jam_ke_6 =  @target_amount_jam_ke_6,
			target_qty_jam_ke_7 =  @target_qty_jam_ke_7,
			target_amount_jam_ke_7 =  @target_amount_jam_ke_7,
			target_qty_jam_ke_8 =  @target_qty_jam_ke_8,
			target_amount_jam_ke_8 =  @target_amount_jam_ke_8,
			target_qty_jam_ke_9 =  @target_qty_jam_ke_9,
			target_amount_jam_ke_9 =  @target_amount_jam_ke_9,
			target_qty_jam_ke_10 =  @target_qty_jam_ke_10,
			target_amount_jam_ke_10 =  @target_amount_jam_ke_10,
			target_qty_jam_ke_11 =  @target_qty_jam_ke_11,
			target_amount_jam_ke_11 =  @target_amount_jam_ke_11,
			target_qty_jam_ke_12 =  @target_qty_jam_ke_12,
			target_amount_jam_ke_12 =  @target_amount_jam_ke_12,
			target_qty_jam_ke_13 =  @target_qty_jam_ke_13,
			target_amount_jam_ke_13 =  @target_amount_jam_ke_13,
			target_qty_jam_ke_14 =  @target_qty_jam_ke_14,
			target_amount_jam_ke_14 =  @target_amount_jam_ke_14,
			target_qty_jam_ke_15_16_istirahat =  @target_qty_jam_ke_15_16_istirahat,
			target_amount_jam_ke_15_16_istirahat =  @target_amount_jam_ke_15_16_istirahat,
			target_qty_jam_ke_17 =  @target_qty_jam_ke_17,
			target_amount_jam_ke_17 =  @target_amount_jam_ke_17,
			target_qty_jam_ke_18 =  @target_qty_jam_ke_18,
			target_amount_jam_ke_18 =  @target_amount_jam_ke_18,
			target_qty_jam_ke_19 =  @target_qty_jam_ke_19,
			target_amount_jam_ke_19 =  @target_amount_jam_ke_19,
			target_qty_jam_ke_20 =  @target_qty_jam_ke_20,
			target_amount_jam_ke_20 =  @target_amount_jam_ke_20,
			target_qty_jam_ke_21 =  @target_qty_jam_ke_21,
			target_amount_jam_ke_21 =  @target_amount_jam_ke_21,
			target_qty_jam_ke_22 =  @target_qty_jam_ke_22,
			target_amount_jam_ke_22 =  @target_amount_jam_ke_22
		
	WHERE target_date = @target_date and halte = @halte

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE ad_dis_rtjn_sum_qty_amount_target: ' + @target_date +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
