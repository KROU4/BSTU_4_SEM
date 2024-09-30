-- SQL script 16 
-- 16.	�������� ������������������ S1, �� ���������� ����������������: ��������� �������� 1000; ���������� 10; ����������� �������� 0; ������������ �������� 10000; �����������; ���������� 30 �������� � ������; ������������� ���������� ��������. �������� ������� T1 � ����� ��������� � ������� (INSERT) 10 �����, �� ���������� �� S1.

create sequence s1 
start with 1000
increment by 10
minvalue 0
maxvalue 10000
cycle 
cache 30
order;

create table sequencetable(
for_seq number,
for_seq2 number,
for_seq3 number);

insert INTO sequencetable values (s1.NEXTVAL,s1.NEXTVAL,s1.NEXTVAL);

select * from sequencetable;