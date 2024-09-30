-- SQL script 5 
-- 5.	Создайте таблицу из двух столбцов, один из которых первичный ключ. Получите перечень всех сегментов. Вставьте данные в таблицу. Определите, сколько в сегменте таблицы экстентов, их размер в блоках и байтах. 
CREATE TABLE my_table (
    id NUMBER PRIMARY KEY,
    description VARCHAR2(100)
);

SELECT SEGMENT_NAME, SEGMENT_TYPE, TABLESPACE_NAME, BYTES, BLOCKS
FROM USER_SEGMENTS;
