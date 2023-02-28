--created by : Septareosagita at gmail.com
--created date : 2015-01-23

 
  SELECT count(1) 
  FROM TB_M_APPLICATION
  WHERE NAME LIKE '%'+ ISNULL(@AppName,'') +'%' 
  AND [DESCRIPTION] LIKE '%'+ ISNULL(@AppDesc,'') +'%' 
  AND [TYPE] LIKE '%'+ ISNULL(@AppType,'') +'%'  