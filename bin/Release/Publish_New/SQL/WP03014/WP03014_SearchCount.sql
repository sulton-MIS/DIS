﻿DECLARE @@QUERY VARCHAR(MAX);

SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
		SELECT 
			ROW_NUMBER() OVER (ORDER BY A.ID_TB_R_LEARN_REG_PROJ_EMPLOYEE ASC) ROW_NUM,
			A.ID_TB_R_LEARN_REG_PROJ_EMPLOYEE AS ID
		FROM 
			TB_R_LEARN_REG_PROJ_EMPLOYEE AS A
		WHERE 
			A.IS_DELETED = 0
';

SET @@QUERY = @@QUERY +') as TB';


EXEC(@@QUERY);
