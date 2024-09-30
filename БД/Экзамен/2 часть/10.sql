-- SQL script 10 
-- 10.	—оздайте функцию, котора€ вычисл€ет количество заказов, выполненных в определенном году дл€ определенного покупател€. ѕараметры Ц покупатель, год. товара.


CREATE OR REPLACE FUNCTION CountCustomerOrdersInYear(
    p_customer_name VARCHAR2,
    p_year          NUMBER
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
      AND EXTRACT(YEAR FROM o.ORDER_DATE) = p_year;

    RETURN v_order_count;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN 0; 
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
        RETURN -1; 
END CountCustomerOrdersInYear;
/



DECLARE
    v_order_count NUMBER;
BEGIN
    v_order_count := CountCustomerOrdersInYear('JCP Inc.', 2008);
    
    DBMS_OUTPUT.PUT_LINE('Number of orders for JCP Inc. in 2008: ' || v_order_count);
END;
/
