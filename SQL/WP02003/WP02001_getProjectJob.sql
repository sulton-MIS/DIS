﻿SELECT  ID,
		WP_PROJECT_ID,
		JOB_NAME,
		WP_IMPB_NO
FROM TB_R_WP_PROJECT_JOB
WHERE WP_PROJECT_ID = @WP_PROJECT_ID;