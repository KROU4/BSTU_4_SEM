-- SQL script 8 
-- 8.	—оздайте функцию, котора€ подсчитывает количество покупателей определенного товара. ѕараметры Ц наименование товара.

CREATE OR REPLACE FUNCTION CountCustomersForProduct(
    p_product_name VARCHAR2
)
RETURN NUMBER
IS
    v_customer_count NUMBER := 0;
BEGIN
    SELECT COUNT(DISTINCT o.CUST)
    INTO v_customer_count
    FROM ORDERS o
    JOIN PRODUCTS p ON o.MFR = p.MFR_ID AND o.PRODUCT = p.PRODUCT_ID
    WHERE p.DESCRIPTION = p_product_name;

    IF v_customer_count IS NULL THEN
        v_customer_count := 0;
    END IF;

    RETURN v_customer_count;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN 0;
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
        RETURN -1; 
END CountCustomersForProduct;
/



DECLARE
    v_customer_count NUMBER;
BEGIN
    v_customer_count := CountCustomersForProduct('Widget Remover');
    
    DBMS_OUTPUT.PUT_LINE('Number of customers for Widget Remover: ' || v_customer_count);
END;
/
