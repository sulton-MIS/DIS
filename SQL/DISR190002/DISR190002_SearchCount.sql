DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
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
        SET @@QUERY = @@QUERY + 'AND A.id_seisan LIKE ''%' + RTRIM(@ID_SEISAN) + '%'' ';
	END

IF(@ID_HINMOKU <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND A.id_hinmoku LIKE ''%' + RTRIM(@ID_HINMOKU) + '%'' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

