ALTER SESSION SET "_oracle_script" = TRUE

CREATE TABLESPACE TS_VDI
    DATAFILE 'TS_VDI.dbf' SIZE 7M
    AUTOEXTEND ON NEXT 5M MAXSIZE 30M;
    
CREATE TEMPORARY TABLESPACE TS_VDI_TEMP
    TEMPFILE 'TS_VDI_TEMP.dbf' SIZE 5M
    AUTOEXTEND ON NEXT 3M MAXSIZE 20M
    EXTENT MANAGEMENT LOCAL --UNIFORM SIZE 3M;
    
SELECT tablespace_name --3
FROM dba_tablespaces;

SELECT tablespace_name, file_name FROM dba_data_files;

-- Создание роли
CREATE ROLE RL_VDICORE;  --5

-- Назначение привилегии на соединение
GRANT CREATE SESSION TO RL_VDICORE;

-- Назначение привилегии на создание, изменение и удаление объектов
GRANT CREATE TABLE TO RL_VDICORE;
GRANT CREATE VIEW TO RL_VDICORE;
GRANT CREATE PROCEDURE TO RL_VDICORE;


--6
SELECT role  
FROM dba_roles
where role = 'RL_VDICORE'

--7
SELECT * 
FROM dba_tab_privs
where GRANTEE = 'RL_VDICORE' -- не работает

 
SELECT *
FROM dba_sys_privs
WHERE grantee = 'RL_VDICORE'; -- работает

--8
CREATE PROFILE SECPROFILE LIMIT 
    PASSWORD_LIFE_TIME 180 -- количество дней жизни пароля
    SESSIONS_PER_USER 3 -- количество сессий для пользователя
    FAILED_LOGIN_ATTEMPTS 7 -- количество попыток входа
    PASSWORD_LOCK_TIME 1 -- количество дней блокирования после ошибок
    PASSWORD_REUSE_TIME 10 -- через сколько дней можно повторить пароль
    PASSWORD_GRACE_TIME DEFAULT -- количество дней предупреждений о смене пароля
    CONNECT_TIME 180 --время соединения, минут
    IDLE_TIME 30 --количество минут простоя

--10
SELECT * 
FROM dba_profiles
WHERE PROFILE = 'SECPROFILE'

--11
SELECT * 
FROM dba_profiles
WHERE PROFILE = 'DEFAULT';

--12
drop user VDICORE;
CREATE USER VDI_CORE1 IDENTIFIED BY "12345"
DEFAULT TABLESPACE TS_VDI
TEMPORARY TABLESPACE TS_VDI_TEMP
PROFILE SECPROFILE
ACCOUNT UNLOCK;
PASSWORD EXPIRE;

GRANT RL_VDICORE TO VDICORE1;
GRANT CREATE SESSION TO VDICORE;
GRANT CONNECT TO VDICORE;
ALTER USER VDICORE IDENTIFIED BY '1111'


SELECT username, password_versions
FROM dba_users
WHERE username = 'VDICORE';

SELECT username, password
FROM dba_users
WHERE username = 'VDICORE';


SELECT account_status
FROM dba_users
WHERE username = 'VDICORE';

SELECT *
FROM dba_users
WHERE username = 'VDICORE';

DROP USER VDICORE;


CREATE TABLE VDI_T (
ID Number(3) PRIMARY KEY,
Name VARCHAR2(50),
Value number
)

Insert Into VDI_T (ID, Name, Value) VALUES (1, 'string', 100);
INSERT INTO VDI_T (ID, Name, Value) VALUES (2, 'string', 120);
INSERT INTO VDI_T (ID, Name, Value) VALUES (3, 'string', 90);

SELECT * 
FROM VDI_T

ALTER USER VDICORE QUOTA 2M ON TS_VDI

ALTER TABLESPACE TS_VDI OFFLINE;
ALTER TABLESPACE TS_VDI ONLINE;

select PDB_NAME, STATUS from DBA_PDBS;