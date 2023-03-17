--Join berdasarkan Work Center Master
select 
distinct(xhead.MAINBUMO) as MAINBUMO
from xhead JOIN XSECT ON XHEAD.MAINBUMO = XSECT.BUMO

--Join berdasarkan transasksi
--select 
--distinct(xhead.MAINBUMO) as MAINBUMO
--from xhead JOIN XZAIK ON XHEAD.code = XZAIK.code	