DECLARE @@CNT INT
	, @@CHK VARCHAR(20)
	, @@ERR VARCHAR(MAX);


BEGIN TRY
	SET @@CNT = (SELECT COUNT(1) FROM ad_dis_pc_master_list_konpo WHERE item_code = @item_code and jenis_packing = @jenis_packing);
	

	IF(@@CNT > 0)
	BEGIN

		SET @@CHK = 'FALSE';
		SET @@ERR = 'DUPLICATE';
		
	END ELSE
	BEGIN
		
		INSERT INTO ad_dis_pc_master_list_konpo
		(
			 [item_code]
			,[jenis_packing]
			,[qty_pcs]
			,[factory_size]
			,[indirect]
			,[berat]
			,[panjang]
			,[lebar]
			,[tinggi]
			,[harga]
			
		)
		VALUES
		(
			@item_code,
			@jenis_packing,
			@qty_pcs,
			@factory_size,
			@indirect,
			@berat,
			@panjang,
			@lebar,
			@tinggi,
			@harga
			
		);


		SET @@CHK = 'TRUE';
		SET @@ERR = 'NOTHING';

		

	END
END TRY
BEGIN CATCH

	

	SET @@CHK = 'FALSE';
	SET @@ERR = 'ERROR INSERT ad_dis_pc_master_list_konpo:' +@item_code+
	'<br/>Detail Error :|: ' + ERROR_MESSAGE() + ' :|: ';	
END CATCH

SELECT @@CHK AS STACK, @@ERR AS LINE_STS
