-- SQL script 7 
-- 7.	—оздайте процедуру, котора€ выводит список покупателей, у которых есть заказы в этом временном периоде. ѕараметры Ц дата начала периода, дата окончани€ периода. ќбработайте возможные ошибки

CREATE OR REPLACE PROCEDURE GetCustomersWithOrders(
    p_start_date DATE,
    p_end_date   DATE
)
IS
    CURSOR c_customers IS
        SELECT DISTINCT c.COMPANY
        FROM CUSTOMERS c
        JOIN ORDERS o ON c.CUST_NUM = o.CUST
        WHERE o.ORDER_DATE BETWEEN p_start_date AND p_end_date
        ORDER BY c.COMPANY;

BEGIN
    IF p_start_date > p_end_date THEN
        RAISE_APPLICATION_ERROR(-20001, 'Start date cannot be greater than end date.');
    END IF;

    FOR customer_record IN c_customers LOOP
        DBMS_OUTPUT.PUT_LINE('Customer: ' || customer_record.COMPANY);
    END LOOP;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('No customers found with orders in the specified period.');
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
END GetCustomersWithOrders;
/


SET SERVEROUTPUT ON;
EXEC GetCustomersWithOrders(TO_DATE('2008-01-01'), TO_DATE('2008-12-31'));
