-- SQL script 22 
-- 22.	Создайте таблицу и вставьте в нее 100 записей. Найдите таблицу и ее свойства в представлениях словаря.

CREATE TABLE test_table (
    id NUMBER PRIMARY KEY,
    description VARCHAR2(100)
);

BEGIN
    FOR i IN 1..100 LOOP
        INSERT INTO test_table (id, description)
        VALUES (i, 'Description for record ' || i);
    END LOOP;
    
    COMMIT;
END;

SELECT *
FROM USER_TABLES
WHERE TABLE_NAME = 'TEST_TABLE';

SELECT *
FROM USER_SEGMENTS
WHERE SEGMENT_NAME = 'TEST_TABLE';

SELECT *
FROM USER_EXTENTS
WHERE SEGMENT_NAME = 'TEST_TABLE';
