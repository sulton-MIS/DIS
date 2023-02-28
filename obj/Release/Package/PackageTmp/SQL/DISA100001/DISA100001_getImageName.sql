DECLARE @@QUERY VARCHAR(MAX);

IF(@FITUR = 'PENGADAAN')
	BEGIN
		SET @@QUERY = 'SELECT nama_foto FROM [ad_dis_ma_master_asset] WHERE no_asset LIKE ''%'+RTRIM(@NAMA_FOTO)+'%'' ';
	END ELSE
IF(@FITUR = 'LAPOR')
	BEGIN
		SET @@QUERY = 'SELECT nama_foto_laporan FROM [ad_dis_ma_lapor_asset] WHERE no_lapor LIKE ''%'+RTRIM(@NAMA_FOTO)+'%'' ';
	END ELSE

IF(@FITUR = 'DISPOSE')
	BEGIN
		SET @@QUERY = 'SELECT nama_foto_laporan FROM [ad_dis_ma_dispose_asset] WHERE no_dispose LIKE ''%'+RTRIM(@NAMA_FOTO)+'%'' ';
	END ELSE
	
IF(@FITUR = 'AUDIT')
	BEGIN
		SET @@QUERY = 'SELECT nama_foto_audit FROM [ad_dis_ma_audit_asset] WHERE no_audit LIKE ''%'+RTRIM(@NAMA_FOTO)+'%'' ';
	END 

EXEC(@@QUERY); 



