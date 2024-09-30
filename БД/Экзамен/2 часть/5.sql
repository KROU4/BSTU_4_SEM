-- SQL script 5 
-- 5.	—оздайте процедуру, котора€ выводит список покупателей, в пор€дке убывани€ общей стоимости заказов. ѕараметры Ц дата начала периода, дата окончани€ периода. ќбработайте возможные ошибки.

CREATE OR REPLACE PROCEDURE GetCustomersByTotalOrderAmount(
    p_start_date DATE,
    p_end_date   DATE
)
IS
    CURSOR c_customers IS
        SELECT c.COMPANY, SUM(o.AMOUNT) AS total_order_amount
        FROM CUSTOMERS c
        JOIN ORDERS o ON c.CUST_NUM = o.CUST
        WHERE o.ORDER_DATE BETWEEN p_start_date AND p_end_date
        GROUP BY c.COMPANY
        ORDER BY total_order_amount DESC;

BEGIN
    IF p_start_date > p_end_date THEN
        RAISE_APPLICATION_ERROR(-20001, 'Start date cannot be greater than end date.');
    END IF;

    FOR customer_record IN c_customers LOOP
        DBMS_OUTPUT.PUT_LINE('Customer: ' || customer_record.COMPANY || ', Total Order Amount: ' || customer_record.total_order_amount);
    END LOOP;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE('No orders found for the specified period.');
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
END GetCustomersByTotalOrderAmount;
/


EXEC GetCustomersByTotalOrderAmount(TO_DATE('2008-01-01'), TO_DATE('2008-12-31'));
