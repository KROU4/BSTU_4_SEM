-- SQL script 16 
-- 16.	Создайте последовательность S1, со следующими характеристиками: начальное значение 1000; приращение 10; минимальное значение 0; максимальное значение 10000; циклическую; кэширующую 30 значений в памяти; гарантирующую хронологию значений. Создайте таблицу T1 с тремя столбцами и введите (INSERT) 10 строк, со значениями из S1.

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