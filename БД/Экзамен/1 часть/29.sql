-- SQL script 29 
-- 29.	Создайте database link с определенными параметрами.

create database link dblink
connect to system
identified by 12345
USING 'lab8';

select * from v$PARAMETER@dblink;