	SELECT 
		path_mesin 
	FROM
		ad_dis_dd_master_denki
	WHERE
		nama_mesin LIKE '%'+ RIGHT(@NAMA_MESIN,2) +''


	--DECLARE @@PANJANG_KARAKTER varchar(max) = '';
	--SET @@PANJANG_KARAKTER = (SELECT LEN(@NAMA_MESIN));
	
	--IF(@@PANJANG_KARAKTER = 10) 
	--BEGIN
	--	SELECT 
	--		path_mesin 
	--	FROM
	--		ad_dis_dd_master_denki
	--	WHERE
	--		nama_mesin = SUBSTRING(@NAMA_MESIN,3,8)
	--END ELSE
	--IF(@@PANJANG_KARAKTER = 9)
	--BEGIN
	--	SELECT 
	--		path_mesin 
	--	FROM
	--		ad_dis_dd_master_denki
	--	WHERE
	--		nama_mesin = SUBSTRING(@NAMA_MESIN,3,7)
	--END