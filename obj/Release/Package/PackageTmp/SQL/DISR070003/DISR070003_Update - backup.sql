DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE Z_RT_master_kotei 
	SET
		name_kotei= @name_kotei,
		halte= @halte,
		id_koteishubetsu= @id_koteishubetsu,
		--id_koteishubetsu= @name_koteishubetsu,
		flg_increByCavity= @flg_increByCavity,
		rate_handankaishi= '0.10',
		rate_ALRTchien= '1.20',
		id_gamenshubetsu= @id_gamenshubetsu,
		flg_RTJNon= @flg_RTJNon,
		comment= @comment,
		flg_rimen= @flg_rimen,
		flg_need_tool= @flg_need_tool,
		time_koshin= GETDATE(),
		flag_logical= @flag_logical,
		initial_process= @initial_process,
		flg_check_schedule= @flg_check_schedule,
		flg_disp_material= @flg_disp_material,
		flg_warning_material= @flg_warning_material,
		flg_oven= @flg_oven,
		group_process= @group_process,
		category= @category,
		sort_no= @sort_no,
		flg_chokoritsu= @flg_chokoritsu,
		bgcolor= @bgcolor,
		group_process_cost= @group_process_cost,
		type_process= @type_process,
		category_process= @category_process,
		prod_cost_level= @prod_cost_level,
		flg_use_cl= @flg_use_cl
	WHERE id_kotei = @id_kotei
		
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE Z_RT_master_kotei: ' + @id_kotei +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
