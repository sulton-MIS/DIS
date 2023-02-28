﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;
DECLARE @@TIME_UNIT_CRITERIA VARCHAR(MAX) = @TIME_UNIT_CRITERIA;
DECLARE @@EXECUTION_TIME VARCHAR(MAX) = @EXECUTION_TIME;
DECLARE @@STATUS_ACTIVE VARCHAR(MAX) = @STATUS_ACTIVE;

SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
		SELECT ROW_NUMBER() OVER (ORDER BY SYSTEM_ID ASC) ROW_NUM,
		SYSTEM_ID,
		SYSTEM_TYPE,
		SYSTEM_CD,
		SYSTEM_VALID_FR,
		SYSTEM_VALID_TO,
		SYSTEM_VALUE_TXT,
		SYSTEM_VALUE_NUM,
		CONVERT(VARCHAR(10),SYSTEM_VALUE_DT) as SYSTEM_VALUE_DT,
		CREATED_BY,
		CREATED_DT,
		CHANGED_BY,
		CHANGED_DT 
		FROM TB_M_SYSTEM
		WHERE 1=1 AND IS_DELETED = 0
';

IF(@SYSTEM_ID <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND SYSTEM_ID LIKE ''%'+RTRIM(@SYSTEM_ID)+'%'' ';
	END

IF(@SYSTEM_TYPE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND SYSTEM_TYPE LIKE ''%'+RTRIM(@SYSTEM_TYPE)+'%'' ';
	END

IF(@SYSTEM_VALUE_TEXT <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND SYSTEM_VALUE_TXT LIKE ''%'+RTRIM(@SYSTEM_VALUE_TEXT)+'%'' ';
	END

IF(@SYSTEM_VALUE_NUM <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND SYSTEM_VALUE_NUM LIKE ''%'+RTRIM(@SYSTEM_VALUE_NUM)+'%'' ';
	END

IF(@SYSTEM_FROM <> '' AND @SYSTEM_TO <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND SYSTEM_VALUE_DT BETWEEN '''+@SYSTEM_FROM+''' AND '''+@SYSTEM_TO+''' ';
	END

SET @@QUERY = @@QUERY +') as TB';

EXEC(@@QUERY);

