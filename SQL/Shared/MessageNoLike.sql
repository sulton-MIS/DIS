select MSGNO
from TB_M_MSGNO
where MSGNO like '%' + @msgno + '%'
