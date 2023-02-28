DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50)= @START;
DECLARE @@DISPLAY VARCHAR(50)= @DISPLAY;
SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY B.id_seisan ASC) ROW_NUM,
	    B.id_seisan as ID,
        B.id_seisan,
	    A.id_hinmoku, 
	    A.other_lotNo,
	    B.CONT, 
	    B.amnt_keikaku_2 
	FROM 
		dbo.Z_RT_data_K_seisanID A
	JOIN
		dbo.Z_RT_data_K_seisankeikaku  B
	ON 
		A.id_seisan = B.id_seisan		
	WHERE 1=1	
';
IF(@ID_SEISAN <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND A.id_seisan= ''' + TRIM(@ID_SEISAN) + ''' ';
        --SET @@QUERY = @@QUERY + 'AND A.id_seisan LIKE ''%' + TRIM(@ID_SEISAN) + '%'' ';
	END

IF(@ID_HINMOKU <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND A.id_hinmoku LIKE ''%' + TRIM(@ID_HINMOKU) + '%'' ';
	END

SET @@QUERY = @@QUERY + ') as TB
';
IF(@@START > 0
   AND @@DISPLAY > 0)
    BEGIN
        SET @@QUERY = @@QUERY + ' WHERE ROW_NUM BETWEEN ' + @@START + ' AND ''' + @@DISPLAY + ''' ';
END;
EXEC (@@QUERY);