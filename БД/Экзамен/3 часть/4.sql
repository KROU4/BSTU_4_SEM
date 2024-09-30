-- SQL script 4 
-- 4.	—оздайте функцию, котора€ подсчитывает количество заказов покупател€ за определенный год. ѕараметры Ц год, часть имени покупател€ или код.

CREATE OR REPLACE FUNCTION CountCustomerOrdersByYear(
    p_year         NUMBER,
    p_customer_part_name VARCHAR2 := NULL,  
    p_customer_code      NUMBER := NULL   
)
RETURN NUMBER
IS
    v_cust_num CUSTOMERS.CUST_NUM%TYPE;
    v_order_count NUMBER := 0;
BEGIN
    IF p_customer_part_name IS NULL AND p_customer_code IS NULL THEN
        RAISE_APPLICATION_ERROR(-20001, 'You must provide either part of the customer name or customer code.');
    END IF;

    IF p_customer_code IS NOT NULL THEN
        SELECT CUST_NUM INTO v_cust_num
        FROM CUSTOMERS
        WHERE CUST_NUM = p_customer_code;

    ELSIF p_customer_part_name IS NOT NULL THEN
        SELECT CUST_NUM INTO v_cust_num
        FROM CUSTOMERS
        WHERE COMPANY LIKE '%' || p_customer_part_name || '%'
        AND ROWNUM = 1; 

    END IF;

    SELECT COUNT(*)
    INTO v_order_count
    FROM ORDERS o
    WHERE o.CUST = v_cust_num
      AND EXTRACT(YEAR FROM o.ORDER_DATE) = p_year;

    RETURN v_order_count;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN 0; 
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
        RETURN -1;
END CountCustomerOrdersByYear;
/


DECLARE
    v_order_count NUMBER;
BEGIN
    v_order_count := CountCustomerOrdersByYear(2008, 'Inc', NULL);
    DBMS_OUTPUT.PUT_LINE('Number of orders for customers with "Inc" in the name in 2008: ' || v_order_count);

    v_order_count := CountCustomerOrdersByYear(2008, NULL, 2101);
    DBMS_OUTPUT.PUT_LINE('Number of orders for customer with code 2101 in 2008: ' || v_order_count);
END;
/
