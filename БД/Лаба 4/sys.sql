--1 ��������� ������ ���� ��������� �����������
-- contents, tablespace_name 
select * from dba_tablespaces;

select tablespace_name, contents from dba_tablespaces;

-- 2 ������ ���� ������ �������� �����������
select file_name, tablespace_name, status from dba_data_files;

--3 ��������� ���� ����� ������� �������, ����������� ������� ������ ��������
select group#, status from v$log; 
select * from v$log;
--4 ��������� ������ ���� ��������  
select * from v$logfile; 

--5 ������������ ��������, ������������������ SCN 

alter system switch logfile;
select * from v$log;

--- 6 �������� ��� ������ �������� � ����� ������� 
alter system switch logfile;
select * from v$log;

alter database add logfile group 4 'C:\app\KROU4\product\21c\lab4logs\log04.log'
size 50m
blocksize 512; 

alter database add logfile member 'C:\app\KROU4\product\21c\lab4logs\log041.log' to group 4;

alter database add logfile member 'C:\app\KROU4\product\21c\lab4logs\log042.log'  to group 4;

--- 7 ��������

alter database drop logfile group 4;

--- 8-9 ���������� ����������� ��� ���, ������������� ������� �������� + ����� ���������� ������

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

--- 12 ���������� �������������

-- shutdown immediate;
-- startup mount;
alter database noarchivelog;
alter database open;
select name, log_mode from v$database;
select instance_name, archiver, active_state from v$instance;

--- 13 ��������� ������ ����������� ������
select * from v$controlfile;
select * from V$PARAMETER;

alter database backup controlfile to trace as 'C:\app\KROU4\product\21c\lab4logs\back.txt' reuse;


--����� ���������� ������
select * from v$archived_log;
--�������� ��������� ������������ �����
--sqlplus
select * from v$controlfile;


