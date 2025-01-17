-- 1

CREATE TABLE Range_Table(
    ID NUMBER,
    DESCRIPTION NVARCHAR2(30)
)
PARTITION BY RANGE (ID) (
    PARTITION RANGE_0 VALUES LESS THAN (100),
    PARTITION RANGE_1 VALUES LESS THAN (200),
    PARTITION RANGE_OTHER VALUES LESS THAN (maxvalue)
);

-- 2

CREATE TABLE Interval_Table(
    ID NUMBER,
    EventTime DATE
)
PARTITION BY RANGE (EventTime)
INTERVAL (NUMTOYMINTERVAL(1, 'MONTH')) (
    PARTITION INTERVAL_LOWER VALUES LESS THAN ('01-01-2024')
);


-- 3

CREATE TABLE Hash_Table(
    ID NUMBER,
    DESCRIPTION VARCHAR2(30)
)
PARTITION BY HASH (DESCRIPTION)
PARTITIONS 3;

-- 4

CREATE TABLE List_Table(
    ID CHAR(1),
    DESCRIPTION NVARCHAR2(30)
)
PARTITION BY LIST (ID) (
    PARTITION LIST_ABCD VALUES ('A', 'B', 'C', 'D'),
    PARTITION LIST_EFGH VALUES ('E', 'F', 'G', 'H'),
    PARTITION LIST_OTHER VALUES (DEFAULT)
);


-- 5

INSERT INTO Range_Table VALUES(54, 'first');
INSERT INTO Range_Table VALUES(156, 'second');
INSERT INTO Range_Table VALUES(347, 'third');
COMMIT;

INSERT INTO Interval_Table VALUES(1, TO_DATE('02-12-2023', 'DD-MM-YYYY'));
INSERT INTO Interval_Table VALUES(2, TO_DATE('02-01-2024', 'DD-MM-YYYY'));
INSERT INTO Interval_Table VALUES(3, TO_DATE('02-02-2024', 'DD-MM-YYYY'));
COMMIT;

INSERT INTO Hash_Table VALUES(1, 'EUIGXF');
INSERT INTO Hash_Table VALUES(2, 'GCYICR');
INSERT INTO Hash_Table VALUES(3, 'ERASDP');
COMMIT;

INSERT INTO List_Table VALUES('A', 'first');
INSERT INTO List_Table VALUES('G', 'second');
INSERT INTO List_Table VALUES('Y', 'third');
COMMIT;

SELECT * FROM USER_TAB_PARTITIONS;
SELECT * FROM USER_TAB_PARTITIONS WHERE TABLE_NAME = 'HASH_TABLE';

SELECT * FROM Range_Table PARTITION(RANGE_0);
SELECT * FROM Range_Table PARTITION(RANGE_1);
SELECT * FROM Range_Table PARTITION(RANGE_OTHER);

SELECT * FROM Interval_Table PARTITION(INTERVAL_LOWER);
SELECT * FROM Interval_Table PARTITION(SYS_P1300);
SELECT * FROM Interval_Table PARTITION(SYS_P1301);

SELECT * FROM Hash_Table PARTITION(SYS_P1297);
SELECT * FROM Hash_Table PARTITION(SYS_P1298);
SELECT * FROM Hash_Table PARTITION(SYS_P1299);

SELECT * FROM List_Table PARTITION(LIST_ABCD);
SELECT * FROM List_Table PARTITION(LIST_EFGH);
SELECT * FROM List_Table PARTITION(LIST_OTHER);

-- 6

ALTER TABLE Range_Table ENABLE ROW MOVEMENT;

ALTER TABLE Interval_Table ENABLE ROW MOVEMENT;

ALTER TABLE Hash_Table ENABLE ROW MOVEMENT;

ALTER TABLE List_Table ENABLE ROW MOVEMENT;


UPDATE Range_Table SET ID = 154 WHERE ID = 54;

SELECT * FROM Range_Table PARTITION(RANGE_0);
SELECT * FROM Range_Table PARTITION(RANGE_1);

UPDATE Range_Table SET ID = 54 WHERE ID = 154;


UPDATE Interval_Table SET EventTime = TO_DATE('03-01-2024', 'DD-MM-YYYY') WHERE EventTime = TO_DATE('02-12-2023', 'DD-MM-YYYY');

SELECT * FROM Interval_Table PARTITION(INTERVAL_LOWER);
SELECT * FROM Interval_Table PARTITION(SYS_P1300);

UPDATE Interval_Table SET EventTime = TO_DATE('02-12-2023', 'DD-MM-YYYY') WHERE EventTime = TO_DATE('03-01-2024', 'DD-MM-YYYY');


UPDATE Hash_Table SET DESCRIPTION = 'SJKLHV' WHERE DESCRIPTION = 'EUIGXF';

SELECT * FROM Hash_Table PARTITION(SYS_P1299);
SELECT * FROM Hash_Table PARTITION(SYS_P1298);

UPDATE Hash_Table SET DESCRIPTION = 'EUIGXF' WHERE DESCRIPTION = 'SJKLHV';


UPDATE List_Table SET ID = 'E' WHERE ID = 'A';

SELECT * FROM List_Table PARTITION(LIST_ABCD);
SELECT * FROM List_Table PARTITION(LIST_EFGH);

UPDATE List_Table SET ID = 'A' WHERE ID = 'E';


-- 7

ALTER TABLE List_Table MERGE PARTITIONS LIST_ABCD, LIST_EFGH INTO PARTITION LIST_ABCDEFGH;

SELECT * FROM List_Table PARTITION(LIST_ABCD);
SELECT * FROM List_Table PARTITION(LIST_EFGH);

SELECT * FROM List_Table PARTITION(LIST_ABCDEFGH);

-- 8

ALTER TABLE Range_Table SPLIT PARTITION RANGE_OTHER AT (300) INTO (
    PARTITION RANGE_2,
    PARTITION RANGE_OTHER
);

SELECT * FROM USER_TAB_PARTITIONS WHERE TABLE_NAME = 'RANGE_TABLE';

-- 9

CREATE TABLE Range_Table_Exchanged (
    ID NUMBER,
    DESCRIPTION NVARCHAR2(30)
);

ALTER TABLE Range_Table EXCHANGE PARTITION RANGE_OTHER WITH TABLE Range_Table_Exchanged;

SELECT * FROM Range_Table_Exchanged;

-- 10

SELECT * FROM USER_PART_TABLES;

SELECT * FROM USER_TAB_PARTITIONS WHERE TABLE_NAME = 'RANGE_TABLE';

SELECT * FROM Range_Table PARTITION(RANGE_0);

SELECT * FROM Range_Table PARTITION FOR(156);

-- 11

DROP TABLE Range_Table;
DROP TABLE Interval_Table;
DROP TABLE Hash_Table;
DROP TABLE List_Table;