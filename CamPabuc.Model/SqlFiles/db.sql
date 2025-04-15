CREATE ROLE campabuc_user NOSUPERUSER CREATEDB NOCREATEROLE INHERIT LOGIN REPLICATION NOBYPASSRLS PASSWORD 'Cp123!';
create database campabuc;
ALTER DATABASE campabuc OWNER TO campabuc_user;
\connect campabuc;
CREATE SCHEMA public;
ALTER SCHEMA public OWNER TO pg_database_owner 
