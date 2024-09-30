-- Задание №1-2
SHOW PARAMETER spfile;
-- C:\app\KROU4\product\21c\database\SPFILEORACLEDB.ORA
SELECT NAME, VALUE, DESCRIPTION FROM V$PARAMETER;


-- Задание №3-4
-- as sysdba
CREATE PFILE = 'C:\app\lab6\PFILEORACLEDB.ORA' from SPFILE;


-- Задание №5-6
-- as sysdba
CREATE SPFILE FROM PFILE = 'C:\app\lab6\PFILEORACLEDB.ORA';

SELECT NAME, VALUE, DESCRIPTION 
FROM V$PARAMETER
WHERE NAME = 'open_cursors'
;


-- Задание №7
ALTER SYSTEM SET open_cursors = 400 SCOPE = SPFILE;


-- Задание №8
SELECT * FROM V$CONTROLFILE;


-- Задание №9
-- C:\app\KROU4\product\21c\database\CONTROLFILE.TXT
ALTER DATABASE BACKUP CONTROLFILE TO TRACE AS 'CONTROLFILE.TXT';


-- Задание №10-11
-- C:\app\KROU4\product\21c\database\PWDXE.ora
SELECT * FROM V$PASSWORDFILE_INFO;


-- Задание №12
-- C:\app\KROU4\product\21c\diag\rdbms\xe\xe
SELECT * FROM V$DIAG_INFO;


-- Задание №13
-- C:\app\KROU4\product\21c\diag\rdbms\xe\xe\alert\log.xml
SELECT * FROM V$DIAG_INFO WHERE NAME = 'Diag Alert';


-- Задание №14
-- C:\app\KROU4\product\21c\diag\rdbms\xe\xe\trace УПРАВЛ ФАЙЛЫ
