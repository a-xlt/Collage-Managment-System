Create database [Collage-Managment-System];
ALTER DATABASE [Collage-Managment-System] COLLATE Arabic_100_CI_AI
Go

use [Collage-Managment-System];
Go


Create table Department(
Id int primary key not null identity(1,1),
[Name] nvarchar(max) not null  
)

Create table Student (
	Id int not null primary key identity(1,1),
	[Name] nvarchar(max) not null ,
	Birthdate nvarchar(max) not null ,
	Deb INT FOREIGN KEY REFERENCES Department(Id),
	Stage int not null,
	Gender nvarchar(max) not null,
	Phone_Number nvarchar(max) not null,
	Id_str nvarchar(max) not null
) 


CREATE table Material
(
Id int not null primary key identity(1,1),
[Name] nvarchar(max) not null , 
Unit_Numbers int not null ,
Th_hours int not null,
Lab_hours int not null,
Stage int not null ,
DebId int FOREIGN KEY REFERENCES Department(Id)
) 

Create table Grade
(
Id int not null primary key identity(1,1),
Grade float not null,
StuID int not null FOREIGN KEY REFERENCES Student(Id),
MetID int not null FOREIGN KEY REFERENCES Material(Id),
) 

create table Schedule(
Id int not null primary key identity(1,1),
[From] nvarchar(max) not null,
[To] nvarchar(max) not null,
Stage int not null ,
DebID Int FOREIGN KEY REFERENCES Department(Id),
MatID int FOREIGN KEY REFERENCES Material(Id),
Teacher_Name nvarchar(max) not null,
Notes nvarchar(max) not null
) 

Create Table Absence(
Id int not null primary key identity(1,1),
[Date] datetime not null,
MatID int FOREIGN KEY REFERENCES Material(Id),
Teacher_name nvarchar(max) not null,
number_Of_absence int not null,
[group] nvarchar(max) not null,
DebID Int FOREIGN KEY REFERENCES Department(Id),
[stage] nvarchar(max) not null,
Notes nvarchar(max) not null,
Students_Names nvarchar(max) not null 
) 



