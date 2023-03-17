if exists (select * from TB_M_USER_PLANT where USERNAME = @Username)
begin 
	select 1
end
else 
begin
select 0
end