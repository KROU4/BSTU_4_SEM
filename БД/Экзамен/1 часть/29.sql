-- SQL script 29 
-- 29.	�������� database link � ������������� �����������.

create database link dblink
connect to system
identified by 12345
USING 'lab8';

select * from v$PARAMETER@dblink;