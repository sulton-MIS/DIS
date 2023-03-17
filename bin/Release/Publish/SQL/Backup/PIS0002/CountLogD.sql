/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : [AI070] Vehicle Inspection and Traceability System
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : PIS0002
 * Function Name    : Log Monitoring Detail Screen
 * Function Group   : Common Master
 * Program Id       : CountLogD
 * Program Name     : Count Log Monitoring Detaul Data
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
SELECT CASE WHEN COUNT(1) > 0 THEN count(*) ELSE 0 END AS [Value]
FROM [dbo].[TB_R_LOG_D]
  WHERE [PROCESS_ID] = @ProcessID