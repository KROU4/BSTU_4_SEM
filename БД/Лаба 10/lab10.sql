-- Задание №1
BEGIN
    null;
END;


-- Задание №2
BEGIN
    DBMS_OUTPUT.PUT_LINE('Hello World!');
END;


-- Задание №3
-- (system)
SELECT KEYWORD
FROM v$reserved_words
WHERE LENGTH = 1
ORDER BY KEYWORD
;


-- Задание №4
-- (system)
SELECT KEYWORD
FROM v$reserved_words
WHERE LENGTH > 1
ORDER BY KEYWORD
;


-- Задание №5
DECLARE
    a NUMBER(10) := 10;
    b NUMBER(10) := 15;
    c NUMBER(10, 2) := 164.67865;
    d NUMBER(10, -2) := 16745.785;
    e NUMBER(10, 2) := 12.5E5;
    f DATE := '12.07.2022';
    g CHAR(7) := 'abc';
    h CHAR(7 CHAR) := 'abcde';
    i NCHAR(7) := 'абв';
    j NCHAR(7 CHAR) := 'абвгд';
    k VARCHAR(7) := 'abc';
    l VARCHAR2(7 CHAR) := 'abcde';
    m NVARCHAR2(7) := 'абв';
    n NVARCHAR2(7 CHAR) := 'абвгд';
    o BOOLEAN := FALSE;
BEGIN
    DBMS_OUTPUT.PUT_LINE('+a = ' || (+a));
    DBMS_OUTPUT.PUT_LINE('-b = ' || (-b));
    DBMS_OUTPUT.PUT_LINE('a + b = ' || (a + b));
    DBMS_OUTPUT.PUT_LINE('a - b = ' || (a - b));
    DBMS_OUTPUT.PUT_LINE('a * b = ' || (a * b));
    DBMS_OUTPUT.PUT_LINE('a / b = ' || (a / b));
    DBMS_OUTPUT.PUT_LINE('MOD(a, b) = ' || MOD(a, b));
    
    DBMS_OUTPUT.PUT_LINE('c = ' || (c));
    
    DBMS_OUTPUT.PUT_LINE('d = ' || (d));
    
    DBMS_OUTPUT.PUT_LINE('e = ' || (e));
    
    DBMS_OUTPUT.PUT_LINE('f = ' || (f));
    
    DBMS_OUTPUT.PUT_LINE('g = ' || (g) || ', length(g) = ' || length(g));
    DBMS_OUTPUT.PUT_LINE('h = ' || (h) || ', length(h) = ' || length(h));
    DBMS_OUTPUT.PUT_LINE('i = ' || (i) || ', length(i) = ' || length(i));
    DBMS_OUTPUT.PUT_LINE('j = ' || (j) || ', length(j) = ' || length(j));
    DBMS_OUTPUT.PUT_LINE('k = ' || (k) || ', length(k) = ' || length(k));
    DBMS_OUTPUT.PUT_LINE('l = ' || (l) || ', length(l) = ' || length(l));
    DBMS_OUTPUT.PUT_LINE('m = ' || (m) || ', length(m) = ' || length(m));
    DBMS_OUTPUT.PUT_LINE('n = ' || (n) || ', length(n) = ' || length(n));
    
    IF o THEN
        DBMS_OUTPUT.PUT_LINE('o = ' || 'true');
    END IF;
    
    IF NOT o THEN
        DBMS_OUTPUT.PUT_LINE('o = ' || 'false');
    END IF;
END;


-- Задание №6
DECLARE
    a CONSTANT VARCHAR2(10) := 'TestStr';
    b CONSTANT CHAR(5) := 'abc';
    c CONSTANT NUMBER(10) := 145;
BEGIN
    DBMS_OUTPUT.PUT_LINE('a = ' || (a));
    DBMS_OUTPUT.PUT_LINE('b = ' || (b));
    DBMS_OUTPUT.PUT_LINE('c = ' || (c));
    c := 1656; --выбьет ошибку
    DBMS_OUTPUT.PUT_LINE('c = ' || (c));
END;


-- Задание №7
DECLARE
    x VDI_T1.ID%TYPE; --тайп соответсвует типу данных таблицы
BEGIN
    x := 14563.78;
    DBMS_OUTPUT.PUT_LINE('x = ' || (x));
END;


-- Задание №8
DECLARE
    y VDI_T1%ROWTYPE; --позволяет работать с целыми строками таблиц
BEGIN
    y.ID := 5467;
    y.DATA := 'some data';
    DBMS_OUTPUT.PUT_LINE('y = ' || y.ID || ' ' || y.DATA);
END;


-- Задание №9
DECLARE
    x INTEGER := 34;
BEGIN
    IF x < 0 THEN
        DBMS_OUTPUT.PUT_LINE(x || ' < 0');
    ELSIF x = 0 THEN
        DBMS_OUTPUT.PUT_LINE(x || ' = 0');
    ELSE
        DBMS_OUTPUT.PUT_LINE(x || ' > 0');
    END IF;
END;


-- Задание №10
DECLARE
    x INTEGER := 0;
BEGIN
    CASE x
        WHEN 0 THEN DBMS_OUTPUT.PUT_LINE('x is 0');
        WHEN 1 THEN DBMS_OUTPUT.PUT_LINE('x is 1');
        WHEN 2 THEN DBMS_OUTPUT.PUT_LINE('x is 2');
        ELSE DBMS_OUTPUT.PUT_LINE('SOME OTHER: ' || x);
    END CASE;
END;


-- Задание №11
DECLARE
    x INTEGER := 0;
BEGIN
    LOOP
        DBMS_OUTPUT.PUT_LINE('[LOOP] x = ' || (x));
        x := x + 1;
        EXIT WHEN x > 10;
    END LOOP;
END;


-- Задание №12
DECLARE
    x INTEGER := 10;
BEGIN
    WHILE x > 0 LOOP
        DBMS_OUTPUT.PUT_LINE('[WHILE] x = ' || (x));
        x := x - 1;
    END LOOP;
END;


-- Задание №13
BEGIN
    FOR x IN 1..8 LOOP
        DBMS_OUTPUT.PUT_LINE('[FOR] x = ' || (x));
    END LOOP;
END;
