/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : [AI070] Vehicle Inspection and Traceability System
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : PIS0001
 * Function Name    : Log Monitoring Header Screen
 * Function Group   : Common Master
 * Program Id       : GetLogH
 * Program Name     : Get Log Monitoring Header Data
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
 SELECT * from
(
	SELECT ROW_NUMBER() OVER (ORDER BY  START_DT DESC) NUMBER
	  ,A.PROCESS_ID      
	  ,A.START_DT
      ,A.END_DT
      ,A.MODULE_ID
      ,A.FUNCTION_ID
      ,A.PROCESS_STATUS
      ,A.USER_ID
      ,A.READ_FLAG
      ,A.REMARK
  FROM TB_R_LOG_H A
  LEFT JOIN TB_M_FUNCTION B
  ON A.FUNCTION_ID = B.FUNCTION_ID AND A.MODULE_ID = b.MODULE_ID
  WHERE
	(CAST(A.START_DT AS DATE) BETWEEN ISNULL(CAST(@ProcessDtFrom AS DATE), CAST(A.START_DT AS DATE)) AND ISNULL(CAST(@ProcessDtTo AS DATE), CAST(A.START_DT AS DATE)))
  AND 
  A.PROCESS_STATUS LIKE '%' + ISNULL(@Status, '%') + '%' 
  AND
  A.PROCESS_ID LIKE '%' + ISNULL(@ProcessID, '%') + '%' 
  AND
  A.FUNCTION_ID LIKE '%' + ISNULL(@FunctionID, '%') + '%' 
  --AND
  --A.[USER_ID] = @UserName
  )
   as TB
    WHERE Number BETWEEN @FromNumber AND @ToNumber
ORDER BY Number
  --END