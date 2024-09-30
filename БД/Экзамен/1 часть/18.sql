-- SQL script 18 
-- 18.	Разработайте анонимный блок, демонстрирующий возникновение и обработку исключений WHEN TO_MANY_ROWS и NO_DATA_FOUND.

DECLARE
    v_name VARCHAR2(100); 
BEGIN
    -- TOO_MANY_ROWS
    BEGIN
        SELECT name INTO v_name
        FROM salesreps
        WHERE title = 'Sales Rep';

        DBMS_OUTPUT.PUT_LINE('Имя: ' || v_name);
    EXCEPTION
        WHEN TOO_MANY_ROWS THEN
            DBMS_OUTPUT.PUT_LINE('Ошибка: Запрос вернул более одной строки (TOO_MANY_ROWS).');
    END;

    -- NO_DATA_FOUND
    BEGIN
        SELECT name INTO v_name
        FROM salesreps
        WHERE title = 'dhfguhgoif'; 

        DBMS_OUTPUT.PUT_LINE('Имя: ' || v_name);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Ошибка: Нет данных для данного запроса (NO_DATA_FOUND).');
    END;

END;
