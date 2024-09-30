-- SQL script 3 
-- 3.	—оздайте процедуру, котора€ выводит список всех товаров, приобретенных покупателем, с указанием суммы продаж по возрастанию. ѕараметр Ц наименование покупател€. ќбработайте возможные ошибки.

CREATE OR REPLACE PROCEDURE GetCustomerProducts(
    p_customer_name VARCHAR2
)
IS
    v_cust_num CUSTOMERS.CUST_NUM%TYPE;

    customer_not_found EXCEPTION;

    CURSOR c_products IS
        SELECT p.DESCRIPTION, o.AMOUNT
        FROM ORDERS o
        JOIN CUSTOMERS c ON o.CUST = c.CUST_NUM
        JOIN PRODUCTS p ON o.MFR = p.MFR_ID AND o.PRODUCT = p.PRODUCT_ID
        WHERE c.COMPANY = p_customer_name
        ORDER BY o.AMOUNT ASC;

BEGIN
    SELECT CUST_NUM INTO v_cust_num
    FROM CUSTOMERS
    WHERE COMPANY = p_customer_name;    

    IF v_cust_num IS NULL THEN
        RAISE customer_not_found;
    END IF;

    FOR product_record IN c_products LOOP
        DBMS_OUTPUT.PUT_LINE('Product: ' || product_record.DESCRIPTION || ', Amount: ' || product_record.AMOUNT);
    END LOOP;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('Customer ' || p_customer_name || ' not found.');
    WHEN customer_not_found THEN
        DBMS_OUTPUT.PUT_LINE('Customer ' || p_customer_name || ' not found.');
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
END GetCustomerProducts;
/


EXEC GetCustomerProducts('JCP Inc.');
