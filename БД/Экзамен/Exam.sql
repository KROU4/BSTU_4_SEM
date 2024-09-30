---Task 1

--Получите перечень роей
select * from dba_roles;

select * from dba_role_privs;

--Перечень пользователей
select * from dba_users;

--Создать роль
create role C##ExamRole;

grant DBA TO C##ExamRole;


---Task 2
---Создайте процедуру которая добавляет товар в таблицу Products и выводит количество товаров этого же производителя
--- Параметры соответствуют столбцам таблицы. Обработайте возможные ошибки

CREATE OR REPLACE PROCEDURE addProducts (
    p_MFR_ID CHAR,
    p_PRODUCT_ID CHAR,
    p_DESCRIPTION VARCHAR2,
    p_PRICE NUMBER,
    p_QTY_ON_HAND NUMBER 
)
IS 
v_product_count NUMBER := 0;

BEGIN
    INSERT INTO PRODUCTS (MFR_ID, PRODUCT_ID, DESCRIPTION, PRICE, QTY_ON_HAND)
    VALUES (p_MFR_ID, p_PRODUCT_ID, p_DESCRIPTION, p_PRICE, p_QTY_ON_HAND);

    SELECT COUNT(*) INTO v_product_count
    FROM PRODUCTS
    WHERE MFR_ID = p_MFR_ID;
    
    DBMS_OUTPUT.PUT_LINE('Monufacturer products: ' || v_product_count);
    
    EXCEPTION 
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('No such monufacturer');
        WHEN OTHERS THEN 
            DBMS_OUTPUT.PUT_LINE('Error: ' || sqlcode || ' with message : ' || sqlerrm);
    
END;

SELECT * FROM PRODUCTS;

SET SERVEROUTPUT ON;


EXEC addProducts('REI', 1113, 'Thats new product', 123, 123)


