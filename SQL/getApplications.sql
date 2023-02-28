--created by : Septareosagita at gmail.com
--created date : 2015-01-26


SELECT * FROM (
	SELECT ROW_NUMBER() OVER (ORDER BY ID ASC) AS NUMBER
	  ,ID AS Id
      ,NAME as Name
      ,RUNTIME as Runtime
	  ,[Type] as _Type
      ,[DESCRIPTION] as Description 
	  ,[CREATED_BY] CreatedBy 
      ,[CHANGED_BY] ChangedBy 
      ,[CREATED_DATE] CreatedDate 
      ,[CHANGED_DATE] ChangedDate 
	  ,ISNULL(fa_icon,'fa-desktop') as FaIcon
  FROM TB_M_APPLICATION
  WHERE NAME LIKE '%'+ ISNULL(@AppName,'') +'%' 
  AND [DESCRIPTION] LIKE '%'+ ISNULL(@AppDesc,'') +'%' 
  AND [TYPE] LIKE '%'+ ISNULL(@AppType,'') +'%' 
) AS T_USER
WHERE NUMBER BETWEEN @FromNumber AND @ToNumber
ORDER BY NAME
