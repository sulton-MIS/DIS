DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50)= @START;
DECLARE @@DISPLAY VARCHAR(50)= @DISPLAY;
SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY target_date DESC) ROW_NUM,
	target_date as ID, 
	*
	FROM ad_dis_rtjn_sum_qty_amount_target		
	WHERE 1=1	
';
IF(@TARGET_DATE <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND target_date LIKE ''%' + RTRIM(@TARGET_DATE) + '%'' ';
END;
IF(@HALTE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND halte LIKE '''+@HALTE+''' ';
	END
SET @@QUERY = @@QUERY + ') as TB';
IF(@@START > 0
   AND @@DISPLAY > 0)
    BEGIN
        SET @@QUERY = @@QUERY + ' WHERE ROW_NUM BETWEEN ' + @@START + ' AND ''' + @@DISPLAY + ''' ';
END;
EXEC (@@QUERY);