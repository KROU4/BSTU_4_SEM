-- SQL script 9 
-- 9.	Получите перечень привилегий для определенной роли. 
select * from dba_role_privs where grantee = 'username';
