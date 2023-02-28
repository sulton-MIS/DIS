/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : TMMIN Training Management System
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : STD
 * Function Name    : STD Message
 * Function Group   : STD Message
 * Program Id       : GetSystem
 * Program Name     : Get System Master
 * Program Type     : SQL
 * Description      : 
 * Environment      : .NET 4.0, ASP MVC 4.0
 * Author           : FID.Diman
 * Version          : 01.00.00
 * Creation Date    : 19/01/2016 18:38:00
 * 
 * Update history     Re-fix date       Person in charge      Description 
 *
 * Copyright(C) 2015 - . All Rights Reserved                                                                                              
 *************************************************************************************************/
 
SELECT SYS_VAL FROM TB_M_SYSTEM
WHERE SYS_CAT = @SysCat 
AND SYS_SUB_CAT = @SysSubCat
AND SYS_CD = @SysCd