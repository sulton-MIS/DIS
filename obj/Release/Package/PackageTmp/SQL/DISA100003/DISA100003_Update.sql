DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	UPDATE ad_dis_pc_master_list_konpo SET
			item_code = @item_code,
			jenis_packing = @jenis_packing,
			qty_pcs = @qty_pcs,
			factory_size = @factory_size,
			indirect = @indirect,
			berat = @berat,
			panjang = @panjang,
			lebar = @lebar,
			tinggi = @tinggi,
			harga = @harga		
	WHERE id_konpo = @ID

	
	SET @@CHK = 'TRUE';
	SET @@ERR = 'Data Has Been Updated';
END TRY
BEGIN CATCH
	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR UPDATE TB_M_EMPLOYEE: ' + @item_code +
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
