/************************************************************************************************************
 * Program History :																						*
 * 																											*
 * Project Name     : AI070 Vehicle Inspection & Tracebility System												*
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)										*
 * Function Id      : AI070010100																			*
 * Function Name    : Line Master Screen																	*
 * Function Group   : Master Maintenance																	*
 * Program Id       : DeleteLine															*
 * Program Name     : Delete Line Master																	*
 * Program Type     : SQL																					*
 * Description      : 																						*
 * Environment      : .NET 4.0, ASP MVC 4.0																	*
 * Author           : FID.Ricky																				*
 * Version          : 02.00.00																				*
 * Creation Date    : 12/20/2016 10:05:40																	*
 * 																											*
 * Update history		Re-fix date				Person in charge				Description					*
 *																  											*
 * Copyright(C) 2016 - Fujitsu Indonesia. All Rights Reserved                                               *                              
 ************************************************************************************************************/

DELETE FROM [dbo].[TB_M_STYLE]
	WHERE STYLE_CD = @StyleCode

SELECT top 1 message = replace(message_text,'{0}','Style Master delete ') from  tb_m_message where message_id='MTPS00036I'
