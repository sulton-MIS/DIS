DECLARE 
	@@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM Z_RT_master_kotei WHERE id_kotei = @id_kotei);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO Z_RT_master_kotei
		(
		   [id_kotei]
		  ,[name_kotei]
		  ,[halte]
		  ,[id_koteishubetsu]
		  ,[flg_increByCavity]
		  ,[rate_handankaishi]
		  ,[rate_ALRTchien]
		  ,[id_gamenshubetsu]
		  ,[flg_RTJNon]
		  ,[comment]
		  ,[flg_rimen]
		  ,[flg_need_tool]
		  ,[time_koshin]
		  ,[flag_logical]
		  ,[initial_process]
		  ,[flg_check_schedule]
		  ,[flg_disp_material]
		  ,[flg_warning_material]
		  ,[flg_oven]
		  ,[group_process]
		  ,[category]
		  ,[sort_no]
		  ,[flg_chokoritsu]
		  ,[bgcolor]
		  ,[group_process_cost]
		  ,[type_process]
		  ,[category_process]
		  ,[prod_cost_level]
		  ,[flg_use_cl]
		)
		VALUES
		(
			@id_kotei,
			@name_kotei,
			@halte,
			@id_koteishubetsu,
			@flg_increByCavity,
			'0.10',
			'1.20',
			@id_gamenshubetsu,
			@flg_RTJNon,
			@comment,
			@flg_rimen,
			@flg_need_tool,
			GETDATE(),
			@flag_logical,
			@initial_process,
			@flg_check_schedule,
			@flg_disp_material,
			@flg_warning_material,
			@flg_oven,
			@group_process,
			@category,
			@sort_no,
			@flg_chokoritsu,
			@bgcolor,
			@group_process_cost,
			@type_process,
			@category_process,
			@prod_cost_level,
			@flg_use_cl
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		
	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT Z_RT_master_kotei:' +@id_kotei+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
