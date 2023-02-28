SELECT TOP(1)	
	unit_price as UNIT_PRICE	
FROM ad_dis_pc_master_unit_price 
WHERE item_code = @MATERIAL_KODE 


--=====================================
--HARGA SEMENTARA DARI TABLE SENDIRI
--=====================================
--SELECT TOP(1)	
--	PRICE as UNIT_PRICE,	
--	EDATE
--FROM XTANK 
--WHERE CODE = @MATERIAL_KODE and EDATE in (999999991,999999999)
--ORDER BY XTANK.INPUTDATE DESC

