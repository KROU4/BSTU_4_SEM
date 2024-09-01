--Задание 1
create table VDI_T (
    num_col NUMBER(3),
    string_col VARCHAR2(50),
    CONSTRAINT pk_vdi_t primary key (num_col)
);

--Задание 2
insert into VDI_T (num_col, string_col) VALUES (1, 'Первая строка');
insert into VDI_T (num_col, string_col) VALUES (2, 'Вторая строка');
insert into VDI_T (num_col, string_col) VALUES (3, 'Третья строка');
commit;

--Задание 3
update VDI_T set string_col = 'Изменённая строка 1' where num_col = 1;
update VDI_T set string_col = 'Изменённая строка 2' where num_col = 2;
commit;

--Задание 4
select * from VDI_T where num_col = 1;
select count(*) from VDI_T;

--Задание 5
delete from VDI_T where num_col = 3;
--Rollback
rollback;

--Задание 6
create table VDI_T_child (
    child_id NUMBER,
    num_col NUMBER(3),
    string_col VARCHAR2(50),
    CONSTRAINT fk_vdi_t_child foreign key (num_col) references VDI_T (num_col)
);
--Добавление данных
insert into VDI_T_child (child_id, num_col, string_col) VALUES (1, 1, 'Первая строка');
insert into VDI_T_child (child_id, num_col, string_col) VALUES (2, 2, 'Вторая строка');
commit;

--Задание 7
select * from VDI_T left join VDI_T_child VTc on VDI_T.num_col = VTc.num_col;
select * from VDI_T inner join VDI_T_child VTc on VDI_T.num_col = VTc.num_col;

--Задание 8
drop table VDI_T_child;
drop table VDI_T;