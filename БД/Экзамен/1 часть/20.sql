-- SQL script 20 
-- 20.	Определите текущую группу журналов повтора. 

select * from v$log where status = 'CURRENT';