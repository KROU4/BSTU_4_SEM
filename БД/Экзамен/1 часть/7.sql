-- SQL script 7 
-- 7.	�������� �������� ���� ��������� ����������� � �� ������

select * from dba_tablespaces;

SELECT tablespace_name, file_id, file_name, bytes, status 
FROM dba_data_files;