-- SQL script 23 
-- 23.	Получите список сегментов табличного пространства. 

select * from dba_segments where tablespace_name = 'USERS';