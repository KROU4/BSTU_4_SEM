set serveroutput on;

GRANT CREATE TRIGGER TO lab9user;

-- 1

CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    LastName VARCHAR(255),
    Age VARCHAR(5)
);

-- 2

INSERT INTO Students VALUES (1, '������', '20');
INSERT INTO Students VALUES (2, '������', '21');
INSERT INTO Students VALUES (3, '�������', '19');
INSERT INTO Students VALUES (4, '������', '22');
INSERT INTO Students VALUES (5, '��������', '20');
INSERT INTO Students VALUES (6, '�������', '23');
INSERT INTO Students VALUES (7, '��������', '18');
INSERT INTO Students VALUES (8, '��������', '21');
INSERT INTO Students VALUES (9, '�������', '19');
INSERT INTO Students VALUES (10, '��������', '22');
COMMIT;

SELECT * FROM Students;
DELETE FROM Students;
-- 8

CREATE TABLE Trigger_Audit(
    Operation_Date DATE,
    Operation_Type VARCHAR(10),
    Operation_Name VARCHAR(50),
    Data VARCHAR(500)
);

-- 3, 5 BEFORE 

CREATE OR REPLACE TRIGGER BEFORE_INS_UPD_DEL_OPERATOR
BEFORE INSERT OR UPDATE OR DELETE ON Students
DECLARE
    OPERATION NVARCHAR2(10);
    DATA NVARCHAR2(2000);
BEGIN
    IF INSERTING THEN BEGIN
        OPERATION := 'INSERT';
    END;
    ELSIF UPDATING THEN BEGIN
        OPERATION := 'UPDATE';
    END;
    ELSIF DELETING THEN BEGIN
        OPERATION := 'DELETE';
    END;
    ELSE BEGIN
        OPERATION := '-';
    END;
    END IF;
    DATA := '-';
    DBMS_OUTPUT.PUT_LINE('TRIGGER BEFORE_INS_UPD_DEL_OPERATOR (' || OPERATION || ')');
    INSERT INTO Trigger_Audit VALUES (SYSDATE, OPERATION, 'BEFORE_INS_UPD_DEL_OPERATOR', DATA);
END;

-- 4 BEFORE 

CREATE OR REPLACE TRIGGER BEFORE_INS_UPD_DEL_ROW
BEFORE INSERT OR UPDATE OR DELETE ON Students
FOR EACH ROW
DECLARE
    OPERATION NVARCHAR2(10);
    DATA NVARCHAR2(2000);
BEGIN
    IF INSERTING THEN BEGIN
        OPERATION := 'INSERT';
        DATA := 'NEW StudentID: ' || :NEW.StudentID || '; NEW LastName: ' || :NEW.LastName || '; NEW Age: ' || :NEW.Age || ';';
    END;
    ELSIF UPDATING THEN BEGIN
        OPERATION := 'UPDATE';
        DATA := 'NEW StudentID: ' || :NEW.StudentID || '; NEW LastName: ' || :NEW.LastName || '; NEW Age: ' || :NEW.Age || '; OLD StudentID: ' || :OLD.StudentID || '; OLD LastName: ' || :OLD.LastName || '; OLD Age: ' || :OLD.Age || ';';
    END;
    ELSIF DELETING THEN BEGIN
        OPERATION := 'DELETE';
        DATA := 'OLD StudentID: ' || :OLD.StudentID || '; OLD LastName: ' || :OLD.LastName || '; OLD Age: ' || :OLD.Age || ';';
    END;
    ELSE BEGIN
        OPERATION := 'UNKNOWN';
        DATA := 'UNKNOWN';
    END;
    END IF;
    DBMS_OUTPUT.PUT_LINE('TRIGGER BEFORE_INS_UPD_DEL_ROW (' || OPERATION || ')');
    INSERT INTO Trigger_Audit VALUES (SYSDATE, OPERATION, 'BEFORE_INS_UPD_DEL_ROW', DATA);
END;


-- 6 AFTER

CREATE OR REPLACE TRIGGER AFTER_INS_OPERATOR
AFTER INSERT ON Students
BEGIN
    DBMS_OUTPUT.PUT_LINE('TRIGGER AFTER_INS_OPERATOR (INSERT)');
    INSERT INTO Trigger_Audit VALUES (SYSDATE, 'INSERT', 'AFTER_INS_OPERATOR', '-');
END;



CREATE OR REPLACE TRIGGER AFTER_UPD_OPERATOR
AFTER UPDATE ON Students
BEGIN
    DBMS_OUTPUT.PUT_LINE('TRIGGER AFTER_UPD_OPERATOR (UPDATE)');
    INSERT INTO Trigger_Audit VALUES (SYSDATE, 'UPDATE', 'AFTER_UPD_OPERATOR', '-');
END;



CREATE OR REPLACE TRIGGER AFTER_DEL_OPERATOR
AFTER DELETE ON Students
BEGIN
    DBMS_OUTPUT.PUT_LINE('TRIGGER AFTER_DEL_OPERATOR (DELETE)');
    INSERT INTO Trigger_Audit VALUES (SYSDATE, 'DELETE', 'AFTER_DEL_OPERATOR', '-');
END;


-- 7 AFTER

CREATE OR REPLACE TRIGGER AFTER_INS_ROW
AFTER INSERT ON Students
FOR EACH ROW
BEGIN
    DBMS_OUTPUT.PUT_LINE('TRIGGER AFTER_INS_ROW (INSERT)');
    INSERT INTO Trigger_Audit VALUES (SYSDATE, 'INSERT', 'AFTER_INS_ROW', 'NEW StudentID: ' || :NEW.StudentID || '; NEW LastName: ' || :NEW.LastName || '; NEW Age: ' || :NEW.Age || ';');
END;



CREATE OR REPLACE TRIGGER AFTER_UPD_ROW
AFTER UPDATE ON Students
FOR EACH ROW
BEGIN
    DBMS_OUTPUT.PUT_LINE('TRIGGER AFTER_UPD_ROW (UPDATE)');
    INSERT INTO Trigger_Audit VALUES (SYSDATE, 'UPDATE', 'AFTER_UPD_ROW', 'NEW StudentID: ' || :NEW.StudentID || '; NEW LastName: ' || :NEW.LastName || '; NEW Age: ' || :NEW.Age || '; OLD StudentID: ' || :OLD.StudentID || '; OLD LastName: ' || :OLD.LastName || '; OLD Age: ' || :OLD.Age || ';');
END;



CREATE OR REPLACE TRIGGER AFTER_DEL_ROW
AFTER DELETE ON Students
FOR EACH ROW
BEGIN
    DBMS_OUTPUT.PUT_LINE('TRIGGER AFTER_DEL_ROW (DELETE)');
    INSERT INTO Trigger_Audit VALUES (SYSDATE, 'DELETE', 'AFTER_DEL_ROW', 'OLD StudentID: ' || :OLD.StudentID || '; OLD LastName: ' || :OLD.LastName || '; OLD Age: ' || :OLD.Age || ';');
END;


-- 10
INSERT INTO Students VALUES (1, '������', '22');
SELECT * FROM TRIGGER_AUDIT;
DELETE FROM TRIGGER_AUDIT;
COMMIT;

-- 11 
DROP TABLE Students;

CREATE OR REPLACE TRIGGER DROP_TABLE
BEFORE DROP ON SCHEMA
BEGIN
    IF ORA_DICT_OBJ_NAME = 'STUDENTS' THEN
        RAISE_APPLICATION_ERROR(-20001, 'Table ' || ORA_DICT_OBJ_NAME || ' cant be dropped');
    END IF;
END;

-- 12

DROP TABLE Trigger_Audit;
SELECT TRIGGER_NAME, STATUS FROM USER_TRIGGERS;

-- 13

CREATE OR REPLACE VIEW View_Students AS SELECT StudentID, LastName, Age  FROM Students;

CREATE OR REPLACE TRIGGER INSTEAD_UPD_ROW
INSTEAD OF UPDATE ON View_Students
FOR EACH ROW
DECLARE
    max_ID NUMBER;
BEGIN
    -- �������� ����� ID ��� ������� ����� ������
    SELECT MAX(StudentID) + 1 INTO max_ID FROM Students;
    
    -- ��������� ����� ������ � ������ ����������
    INSERT INTO Students (StudentID, LastName, Age) 
    VALUES (max_ID, :NEW.LastName, :NEW.Age);

    -- ��������� ������ ������, ������� � ��� "Invalid"
    UPDATE Students 
    SET 
        LastName = 'Invalid: ' || LastName, 
        Age = -1 -- ���������� �������� �������� ��� Age, ��������������� ��� ���� ������
    WHERE 
        StudentID = :OLD.StudentID;
END;
/



UPDATE View_Students SET LastName = '��������' WHERE StudentID = 1;


SELECT * FROM View_Students;
SELECT * FROM Students;

-- 15

CREATE TABLE TestTable (
    ID INT PRIMARY KEY,
    Name VARCHAR(255)
);

CREATE OR REPLACE TRIGGER TESTTABLE_AFTER_INS_1
AFTER INSERT ON TestTable
BEGIN
    DBMS_OUTPUT.PUT_LINE('TESTTABLE_AFTER_INS_1');
END;

CREATE OR REPLACE TRIGGER TESTTABLE_AFTER_INS_2
AFTER INSERT ON TestTable
BEGIN
    DBMS_OUTPUT.PUT_LINE('TESTTABLE_AFTER_INS_2');
END;

CREATE OR REPLACE TRIGGER TESTTABLE_AFTER_INS_3
AFTER INSERT ON TestTable
FOLLOWS TESTTABLE_AFTER_INS_1
BEGIN
    DBMS_OUTPUT.PUT_LINE('TESTTABLE_AFTER_INS_3');
END;

INSERT INTO TestTable VALUES (1, 'Test2');

DROP TABLE TestTable;