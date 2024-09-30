-- SQL script 9 
-- 9.	Создайте процедуру, которая увеличивает на 10% стоимость определенного товара. Параметр – наименование товара. Обработайте возможные ошибки

CREATE OR REPLACE PROCEDURE IncreaseProductPrice(
    p_product_name VARCHAR2
)
IS
    v_current_price PRODUCTS.PRICE%TYPE;
BEGIN
    SELECT PRICE
    INTO v_current_price
    FROM PRODUCTS
    WHERE DESCRIPTION = p_product_name;

    UPDATE PRODUCTS
    SET PRICE = v_current_price * 1.10
    WHERE DESCRIPTION = p_product_name;

    COMMIT;

    DBMS_OUTPUT.PUT_LINE('Price for ' || p_product_name || ' increased by 10%. New price: ' || (v_current_price * 1.10));

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('Product "' || p_product_name || '" not found.');
    
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
END IncreaseProductPrice;
/


EXEC IncreaseProductPrice('Widget Remover');
