-- SQL script 1 
-- 1.	—оздайте процедуру, котора€ выводит список заказов и их итоговую стоимость дл€ определенного покупател€. ѕараметр Ц наименование покупател€. ќбработайте возможные ошибки.

CREATE OR REPLACE PROCEDURE GetCustomerOrders(
    p_customer_name VARCHAR2
)
IS

    v_cust_num CUSTOMERS.CUST_NUM%TYPE;
    v_total_amount NUMBER := 0;
    
    customer_not_found EXCEPTION;

    CURSOR c_orders IS
        SELECT o.ORDER_NUM, o.AMOUNT
        FROM ORDERS o
        JOIN CUSTOMERS c ON o.CUST = c.CUST_NUM
        WHERE c.COMPANY = p_customer_name;

BEGIN
    SELECT CUST_NUM INTO v_cust_num
    FROM CUSTOMERS
    WHERE COMPANY = p_customer_name;

    IF v_cust_num IS NULL THEN
        RAISE customer_not_found;
    END IF;

    FOR order_record IN c_orders LOOP
        DBMS_OUTPUT.PUT_LINE('Order Number: ' || order_record.ORDER_NUM || ', Amount: ' || order_record.AMOUNT);
        v_total_amount := v_total_amount + order_record.AMOUNT;
    END LOOP;

    DBMS_OUTPUT.PUT_LINE('Total Amount for Customer ' || p_customer_name || ': ' || v_total_amount);

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('Customer ' || p_customer_name || ' not found.');
    WHEN customer_not_found THEN
        DBMS_OUTPUT.PUT_LINE('Customer ' || p_customer_name || ' not found.');
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
END GetCustomerOrders;
/


EXEC GetCustomerOrders('JCP Inc.');