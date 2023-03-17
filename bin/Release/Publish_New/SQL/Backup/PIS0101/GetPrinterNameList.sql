﻿/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : [AI070] Production Instruction System
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : PIS101
 * Function Name    : Page Form Header Screen
 * Function Group   : Production Indication
 * Program Id       : GetListPlantCode
 * Program Name     : Get All available list of Printer Name in TB_M_PRINTER_MAPPING table
 * Program Type     : SQL
 * Description      : 
 * Environment      : .NET 4.0, ASP MVC 4.0
 * Author           : FID.Fachrein
 * Version          : 01.00.00
 * Creation Date    : 3 Jul 2017 10:05:40
 * 
 * Update history     Re-fix date       Person in charge      Description 
 *
 * Copyright(C) 2017 - . All Rights Reserved                                                                                              
 *************************************************************************************************/
SELECT	LOGICAL_TERMINAL as [Key],
		LOGICAL_TERMINAL as [Value]
FROM TB_M_PRINTER_MAPPING
ORDER BY LOGICAL_TERMINAL ASC