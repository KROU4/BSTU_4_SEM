-- SQL script 6 
-- 6.	Получите перечень всех процессов СУБД Oracle. Для серверных процессов укажите режим подключения. Для фоновых укажите работающие в настоящий момент.

select * from v$process;

select * from v$process where background = 1;

select * from v$session;
