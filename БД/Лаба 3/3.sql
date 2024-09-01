create tablespace c##vdi
    datafile 'vdi_global.dbf'
    size 50m;

drop tablespace c##vdi;

create user C##VDI identified by "p1234"
    account unlock;

drop user C##VDI;

grant create session to C##VDI;
create role c##vdi_role;
grant create session, create any table, drop any table to c##vdi_role;
grant c##vdi_role to C##VDI;

select * from DBA_ROLE_PRIVS

show con_name