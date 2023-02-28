﻿select 
	ROW_NUMBER() OVER ( 
						ORDER BY A.ID_TB_M_EMPLOYEE ASC) ROWNUM
	,A.ID_TB_M_EMPLOYEE AS ID
	,A.REG_NO
	,A.FIRST_NAME
	,A.LAST_NAME
	,A.USERNAME
	,A.EMAIL
	,A.IDENTITY_TYPE
	,A.IDENTITY_NO
	,A.ADDRESS
	,A.PHONE
	,A.SAFETY_INDUCTION_NO
	,A.SAFETY_INDUCTION_FROM
	,A.SAFETY_INDUCTION_TO
	--,convert(varchar(16), A.SAFETY_INDUCTION_FROM, 120) AS SAFETY_DATE_START
	--,convert(varchar(16), A.SAFETY_INDUCTION_TO, 120) AS SAFETY_DATE_END
	,A.IS_DELETED
	,A.CREATE_BY
	,A.CREATE_DT
	,A.UPDATE_BY
	,A.UPDATE_DT
from
	TB_M_EMPLOYEE A
where
	PIC_STATUS ='MEMBER' 
	AND A.REG_NO like '%'+ @RegNo +'%' 
	AND A.IDENTITY_TYPE like '%'+ @IdentityType +'%'
	AND A.IDENTITY_NO like '%'+ @IdentityNo +'%' 
	AND A.USERNAME like '%'+ @UserName +'%' 
	AND A.EMAIL like '%'+ @Email +'%' 