create tablespace vdi_pdb_sys_ts
    datafile 'vdi_pdb_sys_ts.dbf'
    size 10m
    autoextend on next 5m
    maxsize 50m;

create role vdi_pdb_sys_rl;
grant CONNECT, create session, create any table, drop any table, create any view, drop any view, create any procedure, drop any procedure to vdi_pdb_sys_rl;

create profile vdi_pdb_sys_profile limit
    password_life_time 365
    sessions_per_user 10
    failed_login_attempts 5
    password_lock_time 0
    password_reuse_max 10
    password_grace_time default;

create user u1_vdi_pdb identified by '12345'
    default tablespace ts_pdb_vdi
    quota unlimited on ts_pdb_vdi
    temporary tablespace ts_temp_pdb_vdi
    profile vdi_pdb_sys_profile
    ACCOUNT UNLOCK;