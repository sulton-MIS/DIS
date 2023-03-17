/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : [AI070] Vehicle Inspection and Traceability System
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : PIS0002
 * Function Name    : Log Monitoring Detail Screen
 * Function Group   : Common Master
 * Program Id       : GetLogHByProcessID
 * Program Name     : Get Log Monitoring Header Data by Process ID
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
SELECT [PROCESS_ID]
      ,[START_DT]
      ,[END_DT]
      ,[MODULE_ID]
      ,[FUNCTION_ID]
      ,[PROCESS_STATUS]
      ,[USER_ID]
      ,[READ_FLAG]
      ,[REMARK]
  FROM [dbo].[TB_R_LOG_H]
  WHERE [PROCESS_ID] = @ProcessID 
  