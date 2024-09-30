-- SQL script 25 
-- 25.	¬ычислите количество блоков, зан€тых таблицей.

SELECT blocks
FROM user_tables
WHERE table_name = 'tablename';