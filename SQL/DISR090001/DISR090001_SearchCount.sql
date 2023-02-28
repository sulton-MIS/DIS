﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;
--DECLARE @@EMPLOYEE_NAME VARCHAR(MAX) = @EMPLOYEE_NAME;
--DECLARE @@IDENTITYNUMBER VARCHAR(MAX) = @IDENTITYNUMBER;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY id_sagyosha ASC) ROW_NUM,
	id_sagyosha as ID, 
	*
	FROM  Z_RT_master_sagyosha	
	WHERE 1=1	
';

IF(@EMPLOYEE_NAME <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND name_sagyosha LIKE ''%'+RTRIM(@EMPLOYEE_NAME)+'%'' ';
	END

IF(@IDENTITYNUMBER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND id_sagyosha LIKE ''%'+RTRIM(@IDENTITYNUMBER)+'%'' ';
	END
IF(@STATUS_OPMJ <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND flg_opmj LIKE '''+(@STATUS_OPMJ)+''' ';
	END

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

