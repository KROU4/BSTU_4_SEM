-- SQL script 30 
-- 30.	Продемонстрируйте эскалацию исключения.

DECLARE
    v_value NUMBER;
BEGIN
    BEGIN
        RAISE_APPLICATION_ERROR(-20001, 'Ошибка в вложенном блоке');
    EXCEPTION
        WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('Исключение перехвачено в вложенном блоке.');
            
            -- Эскалация исключения
            RAISE;
    END;

EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Исключение перехвачено в основном блоке.');
END;
