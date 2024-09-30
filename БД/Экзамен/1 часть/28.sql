-- SQL script 28 
-- 28.	Создайте представление с определенными параметрами.

create view my_view as
select * from sequencetable
where for_seq > 1010;

select * from my_view;