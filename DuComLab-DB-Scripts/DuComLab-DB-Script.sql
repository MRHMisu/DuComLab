/*First create a database in MSSQL Server named DuComLabDB*/
/*Then select the database and run the following commands in the database to create all production tables*/

/*Card*/
CREATE TABLE Cards
(
CardsId int IDENTITY(1,1) PRIMARY KEY,
CardNumber varchar(15) Unique NOT NULL,
PinNumber varchar(15) NOT NULL,
SellingDate date,
StudentId int FOREIGN KEY REFERENCES Student(StudentId)  
)

/*Student */
CREATE TABLE Student
(
StudentId int IDENTITY(1,1) PRIMARY KEY,
Name varchar(30) NOT NULL,
DepartmentName varchar(30) NOT NULL,
DepartmentRoll varchar(20) NOT NULL,
AcademicYear varchar(20) NOT NULL,
AttachedHallName varchar(30) NOT NULL 
)


/*CardUsage*/

CREATE TABLE CardUsage
(
CardUsageId int IDENTITY(1,1) PRIMARY KEY,
CardNumber varchar(15) FOREIGN KEY REFERENCES Cards(CardNumber) NOT NULL,
PcName varchar(50) NOT NULL,
StartingTime datetime NOT NULL,
FinishingTime datetime, 
UsingTime int DEFAULT 0
)

/*Admin*/

CREATE TABLE Admin
(
AdminId int IDENTITY(1,1) PRIMARY KEY,
Name varchar(30) NOT NULL,
Email varchar(30) NOT NULL
)

/*ActiveSession*/
Create Table ActiveSession(
ActiveSessionId int IDENTITY(1,1) PRIMARY KEY,
CardNumber varchar(15)  NOT NULL,
PcName varchar(50) NOT NULL
)

/*After creating the tables, now add role*/
/*inserting the role*/
insert into webpages_Roles values ('System Admin');
insert into webpages_Roles values ('Regular Admin');
select * from webpages_Roles;



/* Create Tigger to auto update the CardUsage Table*/
CREATE TRIGGER TiggerAfterUpdateFinishingTime ON [dbo].[CardUsage] 
FOR UPDATE
AS
	declare @CardUsageId int;
	select @CardUsageId=i.CardUsageId from inserted i;			
	UPDATE CardUsage SET UsingTime=DATEDIFF(ss,StartingTime,FinishingTime) WHERE CardUsageId=@CardUsageId;
GO