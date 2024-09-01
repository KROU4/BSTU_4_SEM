CREATE TABLE example_table3 (
                               id NUMBER,
                               name VARCHAR2(50),
                               description CLOB,
                               created_date DATE,
                               CONSTRAINT pk_example_table1 PRIMARY KEY (id)
);


select * from example_table3;