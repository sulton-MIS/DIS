/************************************************************************************************************
 * Program History :																						*
 * 																											*
 * Project Name     : AI070 Production Instruction  System													*
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)										*
 * Function Id      : AI070010100																			*
 * Function Name    : Page Form Designer Header																*
 * Function Group   : Prodcution Indication																	*
 * Program Id       : DeleteData																			*
 * Program Name     : Delete Page Form Designer Header														*
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

DELETE FROM [dbo].[TB_R_PAGE_H]
	WHERE [PLANT_CD]	= @PlantCode
			AND [TEMPLATE_NM]	= @TemplateName
			AND [BC_TYPE]		= @BcType
			AND [LOGICAL_TERMINAL]	= @LogicalTerminal

SELECT top 1 message = replace(message_text,'{0}','Page Form Designer Header delete ') from  tb_m_message where message_id='MPIS00036I'
