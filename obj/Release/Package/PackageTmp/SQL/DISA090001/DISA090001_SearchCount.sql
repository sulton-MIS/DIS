DECLARE @@QUERY VARCHAR(MAX);


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY target_date ASC) ROW_NUM,
	target_date as ID, 
	*
	FROM  ad_dis_rtjn_sum_qty_amount_target	
	WHERE 1=1	
';

IF(@TARGET_DATE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND target_date LIKE ''%'+RTRIM(@TARGET_DATE)+'%'' ';
	END


SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

