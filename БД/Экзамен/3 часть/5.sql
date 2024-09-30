-- SQL script 5 
-- 5.	—оздайте процедуру, котора€ сортирует таблицу по определенному столбцу. ѕараметры Ц название столбца, пор€док сортировки (ASC, DESC). ќбработайте возможные ошибки.

CREATE OR REPLACE PROCEDURE SortTable(
    p_column_name  VARCHAR2,
    p_sort_order   VARCHAR2
)
IS
    v_sql_query VARCHAR2(4000);
    v_cursor SYS_REFCURSOR;
    v_order_num ORDERS.ORDER_NUM%TYPE;
    v_order_date ORDERS.ORDER_DATE%TYPE;
    v_cust ORDERS.CUST%TYPE;
BEGIN
    IF UPPER(p_sort_order) NOT IN ('ASC', 'DESC') THEN
        RAISE_APPLICATION_ERROR(-20001, 'Invalid sort order. Use "ASC" or "DESC".');
    END IF;

    v_sql_query := 'SELECT ORDER_NUM, ORDER_DATE, CUST FROM ORDERS ORDER BY ' || p_column_name || ' ' || UPPER(p_sort_order);

    OPEN v_cursor FOR v_sql_query;

    LOOP
        FETCH v_cursor INTO v_order_num, v_order_date, v_cust;
        EXIT WHEN v_cursor%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('Order Num: ' || v_order_num || ', Order Date: ' || v_order_date || ', Customer: ' || v_cust);
    END LOOP;

    CLOSE v_cursor;

EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLERRM);
END SortTable;
/



EXEC SortTable('ORDER_DATE', 'ASC');

EXEC SortTable('AMOUNT', 'DESC');
