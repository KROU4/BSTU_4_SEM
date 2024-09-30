-- SQL script 17 
-- 17.	Создайте частный и публичный синоним для одной из таблиц и продемонстрируйте его область видимости. Найдите созданные синонимы в представлениях словаря Oracle.

create synonym privat_sinon for sequencetable;
create public synonym sinon for sequencetable;

select * from privat_sinon; 
select * from sinon;

select * from dba_synonyms where synonym_name = 'privat_sinon';
select * from dba_synonyms where synonym_name = 'sinon';