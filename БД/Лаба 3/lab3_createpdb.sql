select PDB_NAME, STATUS from DBA_PDBS;
select name, V$PDBS.OPEN_MODE from V$PDBS;

create pluggable database vdi_pdb admin user vdi_pdb_admin identified by '12345'
    storage (maxsize 2 g)
    default tablespace ts_vdi_pdb
        datafile '/vdi_pdb/ts_vdi_pdb.dbf' size 250 m autoextend on
    path_prefix = 'vdi_pdb'
    file_name_convert = ('/pdbseed/','/vdi_pdb/');