-- SQL script 6 
-- 6.	�������� �������� ���� ��������� ���� Oracle. ��� ��������� ��������� ������� ����� �����������. ��� ������� ������� ���������� � ��������� ������.

select * from v$process;

select * from v$process where background = 1;

select * from v$session;
