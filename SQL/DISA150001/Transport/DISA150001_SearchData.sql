DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;



SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY id_trans ASC) ROW_NUM,
	id_trans as ID, 
	 [id_trans]
      ,[item_code]
      ,A.[code_trans]
	  ,B.[transportation] jenis_transportation
      ,[lot_size]
      ,[master_type]
      ,[master_qty]
      ,[qty_box] 
      ,[master_weight]
      ,[total_cost]
  FROM [TxDTIPRD].[dbo].[ad_dis_pc_transportation_sum] A
  INNER  JOIN 
	ad_dis_pc_master_transportation_code B
	ON A.code_trans = B.code_trans
	WHERE 1=1	
';

IF(@ITEM_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND item_code LIKE ''%'+RTRIM(@ITEM_CODE)+'%'' ';
	END

IF(@JENIS_TRANSPORTATION <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.[code_trans] LIKE ''%'+RTRIM(@JENIS_TRANSPORTATION)+'%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)



