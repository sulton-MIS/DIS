/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : AI070 Vehicle Inspection & Tarcebility
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : STD
 * Function Name    : STD Message
 * Function Group   : STD Message
 * Program Id       : GetMessage
 * Program Name     : Get Message
 * Program Type     : SQL
 * Description      : 
 * Environment      : .NET 4.0, ASP MVC 4.0
 * Author           : FID.Ricky
 * Version          : 01.00.00
 * Creation Date    : 12/20/2016 19:48:00
 * 
 * Update history     Re-fix date       Person in charge      Description 
 *
 * Copyright(C) 2016 - . All Rights Reserved                                                                                              
 *************************************************************************************************/
 
SELECT [MESSAGE_ID]
      ,[MESSAGE_TEXT]
      ,[MESSAGE_TYPE]
  FROM [TB_M_MESSAGE]
  WHERE [MESSAGE_ID] = @MSG_ID