-- SQL script 17 
-- 17.	�������� ������� � ��������� ������� ��� ����� �� ������ � ����������������� ��� ������� ���������. ������� ��������� �������� � �������������� ������� Oracle.

create synonym privat_sinon for sequencetable;
create public synonym sinon for sequencetable;

select * from privat_sinon; 
select * from sinon;

select * from dba_synonyms where synonym_name = 'privat_sinon';
select * from dba_synonyms where synonym_name = 'sinon';