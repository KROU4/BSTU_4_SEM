-- SQL script 5 
-- 5.	�������� ������� �� ���� ��������, ���� �� ������� ��������� ����. �������� �������� ���� ���������. �������� ������ � �������. ����������, ������� � �������� ������� ���������, �� ������ � ������ � ������. 
CREATE TABLE my_table (
    id NUMBER PRIMARY KEY,
    description VARCHAR2(100)
);

SELECT SEGMENT_NAME, SEGMENT_TYPE, TABLESPACE_NAME, BYTES, BLOCKS
FROM USER_SEGMENTS;
