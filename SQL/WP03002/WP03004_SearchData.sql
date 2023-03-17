﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;


SET @@QUERY = '';
SET @@QUERY = '
SELECT 
	*
FROM 
(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY A.TITLE ASC) ROW_NUM,
		A.ID_TB_M_LEARN_MOD_TRAINING AS ID,
		A.TITLE,
		A.DESCRIPTION,
		A.CONTENT_TRAINING,
		A.FILE_NAME,
		A.IS_DELETED
	FROM 
		TB_M_LEARN_MODULE_TRAINING AS A
	WHERE 
		A.IS_DELETED = 0
';

IF(@TITLE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.TITLE LIKE ''%'+@TITLE+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)