﻿SELECT (CASE WHEN SYSTEM_ID IS NOT NULL THEN 'True' ELSE 'False' END) AS STATUS, SYSTEM_VALUE_TXT AS MESSAGE_TEXT FROM TB_M_SYSTEM WHERE SYSTEM_ID = 'WP_SECURITY_HEALTY_CHECK' AND SYSTEM_VALID_FR <= GETDATE() AND SYSTEM_VALID_TO >= GETDATE()