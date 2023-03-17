--Join berdasarkan Transaksi
select 
distinct(XZAIK.HOKAN) as HOKAN
from xhead JOIN XZAIK ON XHEAD.code = XZAIK.code	
where xzaik.HOKAN <> ''