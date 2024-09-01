-- 4 

ALTER DATABASE OPEN;
select OPEN_MODE from V$PDBS
create tablespace ts_VDI_PDB
datafile 'TS_VDI_PDB.dbf'
size 10M
autoextend on next 5M
maxsize 100M
extent management local;

select tablespace_name from dba_tablespaces;

-- создание роли
create role RL_VDI_PDB;

grant
CREATE SESSION,
CREATE TABLE,
CREATE VIEW,
CREATE PROCEDURE,
TO RL_VDI_PDB;

-- вывод роли 
select * from dba_roles where role like 'RL%';

-- вывод привелегий 
select * from dba_sys_privs where grantee = 'RL_VDI_PDB';

--создание профиля безопасности
create profile PF_VDI_PDB limit
password_life_time 180 
sessions_per_user 3
failed_login_attempts 7
password_lock_time 1
password_reuse_time 10
password_grace_time default 
connect_time 180
idle_time 30;

select * from dba_profiles

select * from dba_profiles where profile = 'PF_VDI_PDB'

create user U1_VDI_PDB identified by "12345"
default tablespace ts_VDI_PDB
profile PF_VDI_PDB
account unlock
password expire 

grant RL_VDI_PDB to U1_VDI_PDB;

alter user U1_VDI_PDB
quota 10m on ts_VDI_PDB

SELECT username FROM all_users 

--5 создание таблицы от юзера pdb U1__VDI_PDB

create table VDI_TABLE_PDB (id int);
insert into VDI_TABLE_PDB(id) values (1);
insert into VDI_TABLE_PDB(id) values (2);

select * from VDI_TABLE_PDB

--6 вывод всех данных PDB admin

select tablespace_name, status, file_name from DBA_DATA_FILES
union
select tablespace_name, status, file_name from DBA_TEMP_FILES;

select grantee, privilege from dba_roles 
inner join dba_sys_privs on dba_roles.role = dba_sys_privs.grantee;

select distinct profile from dba_profiles

 SELECT * FROM DBA_ROLE_PRIVS ORDER BY GRANTEE;
 
 select username from all_users 

-- 7 CDB - sys 
create user C##VDI identified by "1234";
grant create session to C##VDI;
-- pdb 
grant create session to C##VDI;

-- 8 выдать привелегию на создание таблицы C##VDI

grant create table to C##VDI;
alter user C##VDI quota unlimited on users

--10 создание таблицы от пользователя C##VDI

create table C##VDI_TABLE (id int);
insert into C##VDI_TABLE(id) values (1);
insert into C##VDI_TABLE(id) values (2);
select * from C##VDI_TABLE

--11 pdb USER C##XXX и U1_XXX_PD.
select distinct object_name from user_objects;

--12 
--cdb
create user C##VDI identified by "12345";
grant create session to C##VDI;

--pdb
grant create session to C##VDI;

--13 получение списка всех текущих подключений VDI_PDB

select * from v$session where username = 'C##VDI'

