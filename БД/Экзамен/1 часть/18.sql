-- SQL script 18 
-- 18.	������������ ��������� ����, ��������������� ������������� � ��������� ���������� WHEN TO_MANY_ROWS � NO_DATA_FOUND.

DECLARE
    v_name VARCHAR2(100); 
BEGIN
    -- TOO_MANY_ROWS
    BEGIN
        SELECT name INTO v_name
        FROM salesreps
        WHERE title = 'Sales Rep';

        DBMS_OUTPUT.PUT_LINE('���: ' || v_name);
    EXCEPTION
        WHEN TOO_MANY_ROWS THEN
            DBMS_OUTPUT.PUT_LINE('������: ������ ������ ����� ����� ������ (TOO_MANY_ROWS).');
    END;

    -- NO_DATA_FOUND
    BEGIN
        SELECT name INTO v_name
        FROM salesreps
        WHERE title = 'dhfguhgoif'; 

        DBMS_OUTPUT.PUT_LINE('���: ' || v_name);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('������: ��� ������ ��� ������� ������� (NO_DATA_FOUND).');
    END;

END;
