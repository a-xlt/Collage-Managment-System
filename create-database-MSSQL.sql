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
	Phone_Number nvarchar(max) not null
) 

Create table Teacher(
Id int not null primary key identity(1,1),
[Name] nvarchar(max) not null ,
Birthdate nvarchar(max) not null ,
	Deb INT FOREIGN KEY REFERENCES Department(Id),
Gender nvarchar(max) not null,
Phone_Number nvarchar(max) not null,
Metrial nvarchar(max) not null,
spec nvarchar(max) not null
)


CREATE table Material
(
Id int not null primary key identity(1,1),
[Name] nvarchar(max) not null , 
Unit_Numbers int not null ,
PrimaryOrSecondary bit not null , 
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

Create table Users(
Id int not null primary key identity(1,1),
[Name] nvarchar(max) not null,
[Password] nvarchar(max) not null , 
privilage int not null , 
Username nvarchar(max) not null
) 

create table Classroom(
Id int not null primary key identity(1,1),
[Code] nvarchar(max) not null,
DebID int FOREIGN KEY REFERENCES Department(Id),
StudentNumber int not null 
) 


create table Schedule(
Id int not null primary key identity(1,1),
[Time] nvarchar(max) not null,
Stage int not null ,
DebID int FOREIGN KEY REFERENCES Department(Id),
ClassID int FOREIGN KEY REFERENCES Classroom(Id),
MatID int FOREIGN KEY REFERENCES Material(Id),
TeacherID int FOREIGN KEY REFERENCES Teacher(Id),
) 

Create Table Absence(
Id int not null primary key identity(1,1),
[Date] datetime not null,
MatID int FOREIGN KEY REFERENCES Material(Id),
TeacherID int FOREIGN KEY REFERENCES Teacher(Id),
Students nvarchar(max) not null 
) 



