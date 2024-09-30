-- SQL script 1 
-- 1.	Создайте процедуру, которая добавляет заказ. Обработайте возможные ошибки. Создайте триггер, который контролирует целостность данных при добавлении заказа.

CREATE OR REPLACE PROCEDURE AddOrder(
    p_order_num   NUMBER,
    p_order_date  DATE,
    p_cust_num    NUMBER,
    p_rep_num     NUMBER,
    p_mfr_id      CHAR,
    p_product_id  CHAR,
    p_qty         NUMBER,
    p_amount      NUMBER
)
IS
BEGIN
    INSERT INTO ORDERS (ORDER_NUM, ORDER_DATE, CUST, REP, MFR, PRODUCT, QTY, AMOUNT)
    VALUES (p_order_num, p_order_date, p_cust_num, p_rep_num, p_mfr_id, p_product_id, p_qty, p_amount);

    COMMIT;

    DBMS_OUTPUT.PUT_LINE('Order added successfully with Order Number: ' || p_order_num);

EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
        DBMS_OUTPUT.PUT_LINE('Error: Duplicate order number. Order already exists.');
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
END AddOrder;
/


CREATE OR REPLACE TRIGGER CheckOrderIntegrity
BEFORE INSERT ON ORDERS
FOR EACH ROW
DECLARE
    v_cust_exists NUMBER;
    v_rep_exists  NUMBER;
    v_prod_exists NUMBER;
BEGIN
    SELECT COUNT(*) INTO v_cust_exists
    FROM CUSTOMERS
    WHERE CUST_NUM = :NEW.CUST;
    
    IF v_cust_exists = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Customer does not exist.');
    END IF;

    IF :NEW.REP IS NOT NULL THEN
        SELECT COUNT(*) INTO v_rep_exists
        FROM SALESREPS
        WHERE EMPL_NUM = :NEW.REP;
        
        IF v_rep_exists = 0 THEN
            RAISE_APPLICATION_ERROR(-20002, 'Sales representative does not exist.');
        END IF;
    END IF;

    SELECT COUNT(*) INTO v_prod_exists
    FROM PRODUCTS
    WHERE MFR_ID = :NEW.MFR AND PRODUCT_ID = :NEW.PRODUCT;
    
    IF v_prod_exists = 0 THEN
        RAISE_APPLICATION_ERROR(-20003, 'Product does not exist.');
    END IF;
END;
/


EXEC AddOrder(113075, TO_DATE('2024-09-14', 'YYYY-MM-DD'), 2101, 106, 'ACI', '41003', 10, 5000);
