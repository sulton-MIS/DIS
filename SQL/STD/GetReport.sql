/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : TMMIN Training Management System
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : STD
 * Function Name    : STD Report
 * Function Group   : STD Report
 * Program Id       : GetReport
 * Program Name     : Get Function Name
 * Program Type     : SQL
 * Description      : 
 * Environment      : .NET 4.0, ASP MVC 4.0
 * Author           : FID.Ine
 * Version          : 01.00.00
 * Creation Date    : 10/12/2015 19:48:00
 * 
 * Update history     Re-fix date       Person in charge      Description 
 *
 * Copyright(C) 2015 - . All Rights Reserved                                                                                              
 *************************************************************************************************/
 
 SELECT FUNCTION_NM
 FROM TB_M_FUNCTION
 WHERE FUNCTION_ID = @FUNCTION_ID