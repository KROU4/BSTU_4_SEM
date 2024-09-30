-- SQL script 7 
-- 7.	Получите перечень всех табличных пространств и их файлов

select * from dba_tablespaces;

SELECT tablespace_name, file_id, file_name, bytes, status 
FROM dba_data_files;