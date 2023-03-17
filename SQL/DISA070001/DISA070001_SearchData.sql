DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;



SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY 	
		date,halte,
		CASE when time = ''07:30-08:30'' then 1 			 
			 when time = ''08:30-09:30'' then 2
			 when time = ''09:30-10:40'' then 3
			 when time = ''10:40-12:30'' then 4			 
			 when time = ''12:30-13:30'' then 5
			 when time = ''13:30-14:30'' then 6
			 when time = ''14:30-16:00'' then 7
			 when time = ''16:00-17:00'' then 8			 
			 when time = ''17:00-18:30'' then 9
			 when time = ''18:30-19:30'' then 10
			 when time = ''19:30-20:30'' then 11
			 when time = ''20:30-21:30'' then 12
			 when time = ''21:30-22:30'' then 13
			 when time = ''22:30-23:30'' then 14
			 when time = ''23:30-00:30'' then 15
			 when time = ''00:30-01:30'' then 16
			 when time = ''01:30-02:30'' then 17
			 when time = ''02:30-03:30'' then 18
			 when time = ''03:30-05:30'' then 19
			 when time = ''05:30-06:30'' then 20
			 when time = ''06:30-07:30'' then 21
		END ASC) ROW_NUM,
	no_id as ID, 
	*
	FROM [ad_dis_rtjn_master_actual_masalah]		
	WHERE 1=1	
';

IF(@DATE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND date LIKE ''%'+RTRIM(@DATE)+'%'' ';
	END

IF(@TIME <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND time LIKE ''%'+RTRIM(@TIME)+'%'' ';
	END

IF(@HALTE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND halte LIKE ''%'+RTRIM(@HALTE)+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)