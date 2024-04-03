Create database [Collage-Managment-System];
ALTER DATABASE [Collage-Managment-System] COLLATE Arabic_100_CI_AI
Go

use [Collage-Managment-System];
Go


Create table Department(
Id int primary key not null identity(1,1),
[Name] nvarchar(max) not null  
)

Create table Groups(
Id INT PRIMARY KEY NOT NULL identity(1,1),
groupLatter nvarchar(1) not null,
groupMax int not null ,
DebId INT FOREIGN KEY REFERENCES Department(Id),
Stage int not null
)

Create table Student (
	Id int not null primary key identity(1,1),
	[Name] nvarchar(max) not null ,
	Birthdate nvarchar(max) not null ,
	Deb INT FOREIGN KEY REFERENCES Department(Id),
	GroupId INT FOREIGN KEY REFERENCES Groups(Id),
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
g1 float null default 0,
g2 float null default 0,
g3 float null default 0,
absence float null default 0,
pluses float null default 0,
FinalGrade float null default 0,
StuID int not null FOREIGN KEY REFERENCES Student(Id),
MetID int not null FOREIGN KEY REFERENCES Material(Id),
) 

create table Schedule(
Id int not null primary key identity(1,1),
Stage int not null ,
DebID Int FOREIGN KEY REFERENCES Department(Id),
[DayOrNight] nvarchar(max) not null,
[Day] int not null , 

[FourOrThree] nvarchar(max) not null,

t1From nvarchar(max) null ,
t1To nvarchar(max) null,
m1 nvarchar(max) null,
i1 nvarchar(max) null,

t2From nvarchar(max) null ,
t2To nvarchar(max) null,
m2 nvarchar(max) null,
i2 nvarchar(max) null,

t3From nvarchar(max) null ,
t3To nvarchar(max) null,
m3 nvarchar(max) null,
i3 nvarchar(max) null,

t4From nvarchar(max) null ,
t4To nvarchar(max) null,
m4 nvarchar(max) null,
i4 nvarchar(max) null
) 





