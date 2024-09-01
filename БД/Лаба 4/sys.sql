--1 получение списка всех табличных пространств
-- contents, tablespace_name 
select * from dba_tablespaces;

select tablespace_name, contents from dba_tablespaces;

-- 2 список всех файлов таблиных пространств
select file_name, tablespace_name, status from dba_data_files;

--3 получение всех групп журнала повтора, определение текущей группы журналов
select group#, status from v$log; 
select * from v$log;
--4 получение файлов всех журналов  
select * from v$logfile; 

--5 переключение журналов, последовательность SCN 

alter system switch logfile;
select * from v$log;

--- 6 создание доп группы журналов с тремя файлами 
alter system switch logfile;
select * from v$log;

alter database add logfile group 4 'C:\app\KROU4\product\21c\lab4logs\log04.log'
size 50m
blocksize 512; 

alter database add logfile member 'C:\app\KROU4\product\21c\lab4logs\log041.log' to group 4;

alter database add logfile member 'C:\app\KROU4\product\21c\lab4logs\log042.log'  to group 4;

--- 7 удаление

alter database drop logfile group 4;

--- 8-9 проверрить выполняется или нет, архивирование журнала повторов + номер последнего архива

select name, log_mode from v$database;
select instance_name, archiver, active_state from v$instance;
select * from v$archived_log;

--- 10
shutdown immediate;
startup mount;
alter database archivelog;
alter database open;

--- 11 
alter system switch logfile;
select * from v$archived_log;

--- 12 отключение архивирования

-- shutdown immediate;
-- startup mount;
alter database noarchivelog;
alter database open;
select name, log_mode from v$database;
select instance_name, archiver, active_state from v$instance;

--- 13 получение списка управляющих файлов
select * from v$controlfile;
select * from V$PARAMETER;

alter database backup controlfile to trace as 'C:\app\KROU4\product\21c\lab4logs\back.txt' reuse;


--номер последнего архива
select * from v$archived_log;
--показать параметры управляющего файла
--sqlplus
select * from v$controlfile;


