CREATE USER V##VDI IDENTIFIED BY "12345";

Grant create session, create any table, drop any table, alter any table to V##VDI;

ALTER USER V##VDI QUOTA UNLIMITED ON USERS;
