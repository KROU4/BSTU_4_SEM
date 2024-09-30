-- SQL script 6 
-- 6.	—оздайте функцию, котора€ подсчитывает количество заказанных товаров за определенный период. ѕараметры Ц дата начала периода, дата окончани€ периода.

CREATE OR REPLACE FUNCTION CountOrderedProducts(
    p_start_date DATE,
    p_end_date   DATE
)
RETURN NUMBER
IS
    v_total_qty NUMBER := 0;
BEGIN
    IF p_start_date > p_end_date THEN
        RAISE_APPLICATION_ERROR(-20001, 'Start date cannot be greater than end date.');
    END IF;

    SELECT SUM(QTY)
    INTO v_total_qty
    FROM ORDERS
    WHERE ORDER_DATE BETWEEN p_start_date AND p_end_date;

    IF v_total_qty IS NULL THEN
        v_total_qty := 0;
    END IF;

    RETURN v_total_qty;

EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An unexpected error occurred: ' || SQLERRM);
        RETURN -1; 
END CountOrderedProducts;
/



DECLARE
    v_total_ordered_products NUMBER;
BEGIN
    v_total_ordered_products := CountOrderedProducts(TO_DATE('2008-01-01'), TO_DATE('2008-12-31'));
    
    DBMS_OUTPUT.PUT_LINE('Total Ordered Products: ' || v_total_ordered_products);
END;
/
