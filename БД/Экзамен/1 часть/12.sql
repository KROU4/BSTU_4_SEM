-- SQL script 12 
-- 12.	Создайте пользователя.

create user KROU4 identified by 12345
default tablespace USERS quota unlimited on USERS
TEMPORARY tablespace TEMP 
account unlock;