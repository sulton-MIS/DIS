﻿IF(@status = 'All')
BEGIN
	SELECT 
	A.TOP_POSITION,
	A.LEFT_POSITION,
	A.HEIGHT,
	A.WIDTH,
	A.PING,
	A.WINDOW_HEIGHT,
	A.WINDOW_WIDTH,
	A.BORDER_COLOR,
	A.ROTATION,
	A.ID_TB_R_WP_PROJECT_JOB
	FROM TB_R_IMPB_LOCATION AS A
	INNER JOIN TB_R_WP_PROJECT_JOB AS B ON A.ID_TB_R_WP_PROJECT_JOB = B.ID
	INNER JOIN TB_R_WP_PROJECT AS C ON B.WP_PROJECT_ID = C.ID
	WHERE C.IMPLEMENT_DATE_TO >= (SELECT TOP 1 START_DATE FROM TB_R_WP_PROJECT_JOB WHERE ID= @ID)
	AND C.IMPLEMENT_DATE_FROM <= (SELECT TOP 1 END_DATE FROM TB_R_WP_PROJECT_JOB WHERE ID= @ID)
	AND C.ID_TB_M_AREA = (SELECT TOP 1 TB_R_WP_PROJECT.ID_TB_M_AREA FROM TB_R_WP_PROJECT_JOB INNER JOIN TB_R_WP_PROJECT ON TB_R_WP_PROJECT_JOB.WP_PROJECT_ID = TB_R_WP_PROJECT.ID WHERE TB_R_WP_PROJECT_JOB.ID = @ID)
	AND B.ID != @ID
END
ELSE
BEGIN
	select TOP_POSITION,
	LEFT_POSITION,
	HEIGHT,
	WIDTH,
	PING,
	WINDOW_HEIGHT,
	WINDOW_WIDTH,
	BORDER_COLOR,
	ROTATION
	FROM TB_R_IMPB_LOCATION
	WHERE ID_TB_R_WP_PROJECT_JOB = @ID
END