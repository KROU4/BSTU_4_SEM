-- Задание №1
DECLARE
    teacher_rec TEACHER%ROWTYPE;
BEGIN
    SELECT *
    INTO teacher_rec 
    FROM TEACHER 
    WHERE TEACHER = 'SMLV'
    ;
    DBMS_OUTPUT.PUT_LINE(
        'Result: ' 
        || teacher_rec.TEACHER || ' ' 
        || teacher_rec.TEACHER_NAME || ' ' 
        || teacher_rec.PULPIT || ' '
    );
END;


-- Задание №2
DECLARE
    subject_rec SUBJECT%ROWTYPE;
BEGIN
    SELECT *
    INTO subject_rec
    FROM SUBJECT
    WHERE SUBJECT = 'XZ'
    ;
    DBMS_OUTPUT.PUT_LINE(
        'Result: '
        || subject_rec.SUBJECT || ' '
        || subject_rec.SUBJECT_NAME || ' '
        || subject_rec.PULPIT || ' '
    );
EXCEPTION
    WHEN OTHERS THEN BEGIN
       DBMS_OUTPUT.PUT_LINE('Code: ' || SQLCODE);
       DBMS_OUTPUT.PUT_LINE('Error Message: ' || SQLERRM);
    END;
END;


-- Задание №3
DECLARE
    pulpit_rec PULPIT%ROWTYPE;
BEGIN
    SELECT *
    INTO pulpit_rec
    FROM PULPIT
    ;
    DBMS_OUTPUT.PUT_LINE(
        'Result: '
        || pulpit_rec.PULPIT || ' '
        || pulpit_rec.PULPIT_NAME || ' '
        || pulpit_rec.FACULTY || ' '
    );
EXCEPTION
    WHEN TOO_MANY_ROWS THEN BEGIN
        DBMS_OUTPUT.PUT_LINE('TOO MANY ROWS');
        DBMS_OUTPUT.PUT_LINE('Code: ' || SQLCODE);
        DBMS_OUTPUT.PUT_LINE('Error Message: ' || SQLERRM);
    END;
END;


-- Задание №4a
DECLARE
    faculty_rec FACULTY%ROWTYPE;
BEGIN
    SELECT *
    INTO FACULTY_rec
    FROM FACULTY
    WHERE FACULTY = 'TTG'
    ;
    DBMS_OUTPUT.PUT_LINE(
        'Result: '
        || faculty_rec.FACULTY || ' '
        || faculty_rec.FACULTY_NAME || ' '
    );
EXCEPTION
    WHEN NO_DATA_FOUND THEN BEGIN
        DBMS_OUTPUT.PUT_LINE('NO DATA FOUND');
        DBMS_OUTPUT.PUT_LINE('Code: ' || SQLCODE);
        DBMS_OUTPUT.PUT_LINE('Error Message: ' || SQLERRM);
    END;
END;


-- Задание №4b
DECLARE
    auditorium_rec AUDITORIUM%ROWTYPE;
BEGIN
    SELECT *
    INTO auditorium_rec
    FROM AUDITORIUM
    WHERE AUDITORIUM = '301-1'
    ;
    
    IF sql%ISOPEN THEN
        DBMS_OUTPUT.PUT_LINE('ISOPEN: true');
    ELSE
        DBMS_OUTPUT.PUT_LINE('ISOPEN: false');
    END IF;
    
    IF sql%FOUND THEN
        DBMS_OUTPUT.PUT_LINE('FOUND: true');
    ELSE
        DBMS_OUTPUT.PUT_LINE('FOUND: false');
    END IF;
    
    IF sql%NOTFOUND THEN
        DBMS_OUTPUT.PUT_LINE('NOTFOUND: true');
    ELSE
        DBMS_OUTPUT.PUT_LINE('NOTFOUND: false');
    END IF;
    
    DBMS_OUTPUT.PUT_LINE('ROWCOUNT: ' || sql%ROWCOUNT);
END;


-- Задание №5
-- INSERT
DECLARE
    subj SUBJECT.SUBJECT%TYPE;
    subj_name SUBJECT.SUBJECT_NAME%TYPE;
    subj_pulpit SUBJECT.PULPIT%TYPE;
BEGIN
    INSERT INTO SUBJECT(SUBJECT, SUBJECT_NAME, PULPIT)
    VALUES ('TSBJ', 'Test Subject', 'PTS')
    RETURNING SUBJECT, SUBJECT_NAME, PULPIT
    INTO subj, subj_name, subj_pulpit
    ;
    DBMS_OUTPUT.PUT_LINE(
        'Result: '
        || subj || ' '
        || subj_name || ' '
        || subj_pulpit || ' '
    );
    ROLLBACK;
EXCEPTION
    WHEN OTHERS THEN BEGIN
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
    END;
END;

-- UPDATE
DECLARE
    tchr TEACHER.TEACHER%TYPE;
    tchr_name TEACHER.TEACHER_NAME%TYPE;
    tchr_pulpit TEACHER.PULPIT%TYPE;
BEGIN
    UPDATE TEACHER
    SET PULPIT = 'PTS'
    WHERE TEACHER = 'DDK'
    RETURNING TEACHER, TEACHER_NAME, PULPIT
    INTO tchr, tchr_name, tchr_pulpit
    ;
    DBMS_OUTPUT.PUT_LINE(
        'Result: '
        || tchr || ' '
        || tchr_name || ' '
        || tchr_pulpit || ' '
    );
    ROLLBACK;
EXCEPTION
    WHEN OTHERS THEN BEGIN
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
    END;
END;

-- DELETE
DECLARE
    aud_type AUDITORIUM_TYPE.AUDITORIUM_TYPE%TYPE;
    aud_typename AUDITORIUM_TYPE.AUDITORIUM_TYPENAME%TYPE;
BEGIN
    DELETE FROM AUDITORIUM_TYPE
    WHERE AUDITORIUM_TYPE = 'LB-K'
    RETURNING AUDITORIUM_TYPE, AUDITORIUM_TYPENAME
    INTO aud_type, aud_typename
    ;
    DBMS_OUTPUT.PUT_LINE(
        'Result: '
        || aud_type || ' '
        || aud_typename || ' '
    );
    ROLLBACK;
EXCEPTION
    WHEN OTHERS THEN BEGIN
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
    END;
END;


-- Задание №6
DECLARE
    CURSOR curs_tchr IS
        SELECT TEACHER, TEACHER_NAME, PULPIT
        FROM TEACHER
    ;
    tchr TEACHER.TEACHER%TYPE;
    tchr_name TEACHER.TEACHER_NAME%TYPE;
    tchr_pulpit TEACHER.PULPIT%TYPE;
BEGIN
    OPEN curs_tchr;
    LOOP
        FETCH curs_tchr INTO tchr, tchr_name, tchr_pulpit;
        EXIT WHEN curs_tchr%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE(
            curs_tchr%ROWCOUNT || '. '
            || tchr || ' '
            || tchr_name || ' '
            || tchr_pulpit || ' '
        );
    END LOOP;
END;


-- Задание №7
DECLARE
    CURSOR curs_sbj IS
        SELECT SUBJECT, SUBJECT_NAME, PULPIT
        FROM SUBJECT
    ;
    sbj_rec SUBJECT%ROWTYPE;
BEGIN
    OPEN curs_sbj;
    FETCH curs_sbj INTO sbj_rec;
    WHILE curs_sbj%FOUND LOOP
        DBMS_OUTPUT.PUT_LINE(
            curs_sbj%ROWCOUNT || '. '
            || sbj_rec.SUBJECT || ' '
            || sbj_rec.SUBJECT_NAME || ' '
            || sbj_rec.PULPIT || ' '
        );
        FETCH curs_sbj INTO sbj_rec;
    END LOOP;
END;


-- Задание №8
DECLARE
    CURSOR aud_cap_curs(
        min_capacity AUDITORIUM.AUDITORIUM_CAPACITY%TYPE,
        max_capacity AUDITORIUM.AUDITORIUM_CAPACITY%TYPE
    ) IS
        SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE
        FROM AUDITORIUM
        WHERE AUDITORIUM_CAPACITY BETWEEN min_capacity AND max_capacity
        ORDER BY AUDITORIUM_CAPACITY
    ;
    aud_rec AUDITORIUM%ROWTYPE;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Capacity <= 20:');
    OPEN aud_cap_curs(0, 20);
    LOOP
        FETCH aud_cap_curs INTO aud_rec;
        EXIT WHEN aud_cap_curs%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE(
            '   ' || aud_cap_curs%ROWCOUNT || '. '
            || aud_rec.AUDITORIUM || ' '
            || aud_rec.AUDITORIUM_NAME || ' '
            || aud_rec.AUDITORIUM_CAPACITY || ' '
            || aud_rec.AUDITORIUM_TYPE || ' '            
        );
    END LOOP;
    CLOSE aud_cap_curs;
    
    DBMS_OUTPUT.PUT_LINE('Capacity from 21 to 30:');
    OPEN aud_cap_curs(21, 30);
    FETCH aud_cap_curs INTO aud_rec;
    WHILE aud_cap_curs%FOUND LOOP
        DBMS_OUTPUT.PUT_LINE(
            '   ' || aud_cap_curs%ROWCOUNT || '. '
            || aud_rec.AUDITORIUM || ' '
            || aud_rec.AUDITORIUM_NAME || ' '
            || aud_rec.AUDITORIUM_CAPACITY || ' '
            || aud_rec.AUDITORIUM_TYPE || ' '            
        );
        FETCH aud_cap_curs INTO aud_rec;
    END LOOP;
    CLOSE aud_cap_curs;
    
    DBMS_OUTPUT.PUT_LINE('Capacity from 31 to 60:');
    FOR aud_rec IN aud_cap_curs(31, 60) LOOP
        DBMS_OUTPUT.PUT_LINE(
            '   ' || aud_cap_curs%ROWCOUNT || '. '
            || aud_rec.AUDITORIUM || ' '
            || aud_rec.AUDITORIUM_NAME || ' '
            || aud_rec.AUDITORIUM_CAPACITY || ' '
            || aud_rec.AUDITORIUM_TYPE || ' '            
        );
    END LOOP;
    
    DBMS_OUTPUT.PUT_LINE('Capacity from 61 to 80:');
    FOR aud_rec IN aud_cap_curs(61, 80) LOOP
        DBMS_OUTPUT.PUT_LINE(
            '   ' || aud_cap_curs%ROWCOUNT || '. '
            || aud_rec.AUDITORIUM || ' '
            || aud_rec.AUDITORIUM_NAME || ' '
            || aud_rec.AUDITORIUM_CAPACITY || ' '
            || aud_rec.AUDITORIUM_TYPE || ' '            
        );
    END LOOP;
    
    DBMS_OUTPUT.PUT_LINE('Capacity >= 81:');
    FOR aud_rec IN aud_cap_curs(81, binary_double_infinity) LOOP
        DBMS_OUTPUT.PUT_LINE(
            '   ' || aud_cap_curs%ROWCOUNT || '. '
            || aud_rec.AUDITORIUM || ' '
            || aud_rec.AUDITORIUM_NAME || ' '
            || aud_rec.AUDITORIUM_CAPACITY || ' '
            || aud_rec.AUDITORIUM_TYPE || ' '            
        );
    END LOOP;
END;


-- Задание №9
DECLARE
    aud_ref_curs SYS_REFCURSOR;
    aud_rec AUDITORIUM_TYPE%ROWTYPE;
BEGIN
    OPEN aud_ref_curs FOR 
        SELECT *
        FROM AUDITORIUM_TYPE
    ;
    LOOP
        FETCH aud_ref_curs INTO aud_rec;
        EXIT WHEN aud_ref_curs%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE(
            aud_ref_curs%ROWCOUNT || '. '
            || aud_rec.AUDITORIUM_TYPE || ' '            
            || aud_rec.AUDITORIUM_TYPENAME || ' ' 
        );
    END LOOP;
END;


-- Задание №10
DECLARE
    CURSOR aud_cap_upd_curs(
        min_capacity AUDITORIUM.AUDITORIUM_CAPACITY%TYPE,
        max_capacity AUDITORIUM.AUDITORIUM_CAPACITY%TYPE
    ) IS
        SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE
        FROM AUDITORIUM
        WHERE AUDITORIUM_CAPACITY BETWEEN min_capacity AND max_capacity
        ORDER BY AUDITORIUM_CAPACITY
        FOR UPDATE
    ;
    aud1_rec AUDITORIUM%ROWTYPE;
    aud2_rec AUDITORIUM%ROWTYPE;
    new_cap AUDITORIUM.AUDITORIUM_CAPACITY%TYPE;
BEGIN
    FOR aud1_rec IN aud_cap_upd_curs(40, 80) LOOP
        new_cap := aud1_rec.AUDITORIUM_CAPACITY - (aud1_rec.AUDITORIUM_CAPACITY / 10);
        UPDATE AUDITORIUM
        SET AUDITORIUM_CAPACITY = new_cap
        WHERE CURRENT OF aud_cap_upd_curs
        ;
        SELECT * INTO aud2_rec FROM AUDITORIUM WHERE AUDITORIUM = aud1_rec.AUDITORIUM;
        DBMS_OUTPUT.PUT_LINE(
            aud_cap_upd_curs%ROWCOUNT || '. '
            || aud2_rec.AUDITORIUM || ' '
            || aud2_rec.AUDITORIUM_NAME || ' '
            || aud2_rec.AUDITORIUM_CAPACITY || ''
            || '(' || aud1_rec.AUDITORIUM_CAPACITY || ') '
            || aud2_rec.AUDITORIUM_TYPE || ' '            
        );
    END LOOP;
    ROLLBACK;
END;
