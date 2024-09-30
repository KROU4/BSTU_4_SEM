-- Задание №1
SELECT SUM(VALUE) FROM V$SGA;


-- Задание №2
SELECT COMPONENT, CURRENT_SIZE 
FROM v$sga_dynamic_components
WHERE CURRENT_SIZE > 0
;


-- Задание №3
SELECT COMPONENT, GRANULE_SIZE
FROM v$sga_dynamic_components
WHERE CURRENT_SIZE > 0
;


-- Задание №4
SELECT * FROM v$sga_dynamic_free_memory;


-- Задание №5
SHOW PARAMETER SGA;


-- Задание №6
SELECT * 
FROM v$sga_dynamic_components
WHERE COMPONENT in ('DEFAULT buffer cache', 'KEEP buffer cache', 'RECYCLE buffer cache')
;


-- Задание №7
CREATE TABLE VDI_T_KEEP (
    ID INT
)
STORAGE (buffer_pool keep)
;

SELECT SEGMENT_NAME, SEGMENT_TYPE, TABLESPACE_NAME, BUFFER_POOL
FROM USER_SEGMENTS
WHERE SEGMENT_NAME = 'VDI_T_KEEP'
;


-- Задание №8
CREATE TABLE VDI_T_DEFAULT (
    ID INT
)
STORAGE (buffer_pool default)
;

SELECT SEGMENT_NAME, SEGMENT_TYPE, TABLESPACE_NAME, BUFFER_POOL
FROM USER_SEGMENTS
WHERE SEGMENT_NAME = 'VDI_T_DEFAULT'
;


-- Задание №9
SHOW PARAMETER log_buffer;


-- Задание №10
SHOW PARAMETER large_pool_size;


-- Задание №11
SELECT USERNAME, SERVICE_NAME, SERVER
FROM v$session
WHERE USERNAME IS NOT NULL
;


-- Задание №12
SELECT *
FROM v$bgprocess
WHERE PADDR != HEXTORAW('00')
ORDER BY NAME
;


-- Задание №13
SELECT * FROM v$process;


-- Задание №14
SELECT * FROM v$process WHERE PNAME LIKE 'DBW%';


-- Задание №15
SELECT * FROM v$services;


-- Задание №16
SHOW PARAMETER dispatcher;
SHOW PARAMETER shared_server;


-- Задание №17
-- Диспетчер задач -> службы


-- Задание №18
-- %ORACLE_HOME%\NETWORK\ADMIN\LISTENER.ORA


-- Задание №19
-- lsnrctl


-- Задание №20
-- lsnrctl services 888****************


-- Удаление таблиц
DROP TABLE VDI_T_KEEP;
DROP TABLE VDI_T_DEFAULT;
