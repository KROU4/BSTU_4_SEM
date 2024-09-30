-- ������� �1-2
SHOW PARAMETER spfile;
-- C:\app\KROU4\product\21c\database\SPFILEORACLEDB.ORA
SELECT NAME, VALUE, DESCRIPTION FROM V$PARAMETER;


-- ������� �3-4
-- as sysdba
CREATE PFILE = 'C:\app\lab6\PFILEORACLEDB.ORA' from SPFILE;


-- ������� �5-6
-- as sysdba
CREATE SPFILE FROM PFILE = 'C:\app\lab6\PFILEORACLEDB.ORA';

SELECT NAME, VALUE, DESCRIPTION 
FROM V$PARAMETER
WHERE NAME = 'open_cursors'
;


-- ������� �7
ALTER SYSTEM SET open_cursors = 400 SCOPE = SPFILE;


-- ������� �8
SELECT * FROM V$CONTROLFILE;


-- ������� �9
-- C:\app\KROU4\product\21c\database\CONTROLFILE.TXT
ALTER DATABASE BACKUP CONTROLFILE TO TRACE AS 'CONTROLFILE.TXT';


-- ������� �10-11
-- C:\app\KROU4\product\21c\database\PWDXE.ora
SELECT * FROM V$PASSWORDFILE_INFO;


-- ������� �12
-- C:\app\KROU4\product\21c\diag\rdbms\xe\xe
SELECT * FROM V$DIAG_INFO;


-- ������� �13
-- C:\app\KROU4\product\21c\diag\rdbms\xe\xe\alert\log.xml
SELECT * FROM V$DIAG_INFO WHERE NAME = 'Diag Alert';


-- ������� �14
-- C:\app\KROU4\product\21c\diag\rdbms\xe\xe\trace ������ �����
