﻿DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@MESSAGE VARCHAR(MAX);
DECLARE @@GETMESSAGE VARCHAR(MAX);
SET @@GETMESSAGE = (SELECT REPLACE(REPLACE(REPLACE(MSG_TEXT,'{0}', @PARAM1),'{1}', @PARAM2),'{2}',@PARAM3) FROM TB_M_MESSAGE WHERE MSG_ID = @MSG_ID);

SELECT @@GETMESSAGE AS MSG_TEXT;