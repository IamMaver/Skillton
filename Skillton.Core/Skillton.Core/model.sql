CREATE DATABASE EmployeeDB;
CREATE TABLE Employees
(
    EmployeeID  int NOT NULL PRIMARY KEY,
    FirstName   nvarchar(50),
    LastName    nvarchar(50),
    Email       nvarchar(100),
    DateOfBirth date,
    Salary      decimal
);