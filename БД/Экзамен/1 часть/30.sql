-- SQL script 30 
-- 30.	����������������� ��������� ����������.

DECLARE
    v_value NUMBER;
BEGIN
    BEGIN
        RAISE_APPLICATION_ERROR(-20001, '������ � ��������� �����');
    EXCEPTION
        WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('���������� ����������� � ��������� �����.');
            
            -- ��������� ����������
            RAISE;
    END;

EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('���������� ����������� � �������� �����.');
END;
