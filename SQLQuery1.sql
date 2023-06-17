create database seckmark;
use seckmark;

create table Department
(
dep_code char(3) primary key,
dep_name char(30) unique
);

drop table Department;

select * from Department;
select * from Employee;

create table Employee
(
emp_Srno numeric  primary key identity(1,1),
emp_code char(4) unique,
emp_Name char(30) unique,
emp_Dept char(3) unique,
);
truncate table Employee;
drop table Employee;
Select * from Employee;