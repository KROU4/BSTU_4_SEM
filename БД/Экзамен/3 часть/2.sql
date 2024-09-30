-- SQL script 2 
-- 2.	—оздайте функцию, котора€ возвращает количество заказов покупател€ помес€чно за определенный период. ѕараметры Ц покупатель, дата начала периода, дата окончани€ периода. ќбработайте возможные ошибки.

CREATE OR REPLACE FUNCTION CountCustomerOrdersMonthly(
    p_customer_name VARCHAR2,
    p_start_date    DATE,
    p_end_date      DATE
)
RETURN SYS_REFCURSOR
IS
    v_cust_num CUSTOMERS.CUST_NUM%TYPE;
    v_result_cursor SYS_REFCURSOR;
BEGIN
    IF p_start_date > p_end_date THEN
        RAISE_APPLICATION_ERROR(-20001, 'Start date cannot be greater than end date.');
    END IF;

    SELECT CUST_NUM INTO v_cust_num
    FROM CUSTOMERS
    WHERE COMPANY = p_customer_name;

    OPEN v_result_cursor FOR
        SELECT TO_CHAR(o.ORDER_DATE, 'YYYY-MM') AS order_month,
               COUNT(*) AS order_count
        FROM ORDERS o
        WHERE o.CUST = v_cust_num
          AND o.ORDER_DATE BETWEEN p_start_date AND p_end_date
        GROUP BY TO_CHAR(o.ORDER_DATE, 'YYYY-MM')
        ORDER BY order_month;

    RETURN v_result_cursor;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-20002, 'Customer "' || p_customer_name || '" not found.');
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
        RETURN NULL;
END CountCustomerOrdersMonthly;
/




DECLARE
    v_order_cursor SYS_REFCURSOR;
    v_order_month  VARCHAR2(7);
    v_order_count  NUMBER;
BEGIN
    v_order_cursor := CountCustomerOrdersMonthly('JCP Inc.', TO_DATE('2007-01-01', 'YYYY-MM-DD'), TO_DATE('2007-12-31', 'YYYY-MM-DD'));

    LOOP
        FETCH v_order_cursor INTO v_order_month, v_order_count;
        EXIT WHEN v_order_cursor%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('Month: ' || v_order_month || ', Orders: ' || v_order_count);
    END LOOP;

    CLOSE v_order_cursor;
END;
/
