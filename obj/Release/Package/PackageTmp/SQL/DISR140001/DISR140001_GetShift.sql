DECLARE @@time_now varchar(max);
SET @@time_now = (SELECT FORMAT(GETDATE(),'HHmmss') as time_now);

select 
	shift
	--convert(int, @@time_now) time_now,
	--convert(int,STIME) start_time, 
	--convert(int,ETIME) end_time
from 
	Z_RT_master_shift_date
where	
	(@@time_now >= STIME AND @@time_now < ETIME) 