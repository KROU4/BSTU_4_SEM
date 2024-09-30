-- SQL script 4 
-- 4.	Создайте функцию, которая добавляет покупателя в таблицу Customers, и возвращает код добавленного покупателя или -1 в случае ошибки. Параметры соответствуют столбцам таблицы, кроме кода покупателя, который задается при помощи последовательности.

CREATE SEQUENCE CUSTOMER_SEQ
START WITH 1000
INCREMENT BY 1  
NOCACHE;       

CREATE OR REPLACE FUNCTION AddCustomer(
    p_company      VARCHAR2,
    p_cust_rep     INTEGER,
    p_credit_limit DECIMAL
)
RETURN INTEGER
IS
    v_new_cust_num CUSTOMERS.CUST_NUM%TYPE;
BEGIN
    v_new_cust_num := CUSTOMER_SEQ.NEXTVAL;

    INSERT INTO CUSTOMERS (CUST_NUM, COMPANY, CUST_REP, CREDIT_LIMIT)
    VALUES (v_new_cust_num, p_company, p_cust_rep, p_credit_limit);

    RETURN v_new_cust_num;

EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error adding customer: ' || SQLERRM);
        RETURN -1;
END AddCustomer;
/


DECLARE
    v_new_customer_id INTEGER;
BEGIN
    v_new_customer_id := AddCustomer('NewCo Inc.', 101, 50000);
    
    DBMS_OUTPUT.PUT_LINE('New Customer ID: ' || v_new_customer_id);
END;
/
