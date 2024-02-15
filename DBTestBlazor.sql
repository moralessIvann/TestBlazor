create database DBTestBlazor
use DBTestBlazor

create table deparment(
idDepartment int primary key identity (1,1),
departmentName varchar(50) not null
)

create table employee(
idEmployee int primary key identity (1,1),
fullName varchar(50) not null,
income int not null,
contractDate date not null
)

insert into deparment(departmentName) values
('Marketing')
('IT')

insert into employee (fullName, income, contractDate) values 
('Jhonn Connor', 5500, GETDATE())

select * from employee