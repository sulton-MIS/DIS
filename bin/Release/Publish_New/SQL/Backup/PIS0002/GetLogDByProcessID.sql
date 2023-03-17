/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : [AI070] Vehicle Inspection and Traceability System
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : PIS0002
 * Function Name    : Log Monitoring Detail Screen
 * Function Group   : Common Master
 * Program Id       : GetLogDByProcessID
 * Program Name     : Get Log Monitoring Detail Data by Process ID
 * Program Type     : SQL
 * Description      : 
 * Environment      : .NET 4.0, ASP MVC 4.0
 * Author           : FID.Rekhas
 * Version          : 01.00.00
 * Creation Date    : 29/12/2016 10:05:40
 * 
 * Update history     Re-fix date       Person in charge      Description 
 *
 * Copyright(C) 2016 - . All Rights Reserved                                                                                              
 *************************************************************************************************/
SELECT * FROM 
(
	SELECT ROW_NUMBER() OVER(ORDER BY SEQ_NO ASC) NUMBER
	  ,PROCESS_ID
      ,SEQ_NO
      ,ERROR_DT
      ,ERROR_LOC
      ,MESSAGE_TYPE
      ,MESSAGE_ID
      ,ERROR_MESSAGE
  FROM TB_R_LOG_D
	WHERE PROCESS_ID = @ProcessID
) AS TB
WHERE Number BETWEEN @FromNumber AND @ToNumber
ORDER BY Number