-- SQL script 2 
-- 2.	—оздайте функцию, котора€ подсчитывает количество заказов покупател€ за определенный период. ѕараметры Ц покупатель, дата начала периода, дата окончани€ периода.

CREATE OR REPLACE FUNCTION CountCustomerOrders(
    p_customer_name VARCHAR2,
    p_start_date    DATE,
    p_end_date      DATE
)
RETURN NUMBER
IS
    v_order_count NUMBER := 0;
BEGIN
    SELECT COUNT(*)
    INTO v_order_count
    FROM ORDERS o
    JOIN CUSTOMERS c ON o.CUST = c.CUST_NUM
    WHERE c.COMPANY = p_customer_name
      AND o.ORDER_DATE BETWEEN p_start_date AND p_end_date;

    RETURN v_order_count;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN 0;
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLERRM);
        RETURN -1;
END CountCustomerOrders;
/


SELECT CountCustomerOrders('JCP Inc.', TO_DATE('2008-01-01'), TO_DATE('2008-12-31')) AS order_count
FROM DUAL;
