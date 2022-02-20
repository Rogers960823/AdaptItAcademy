use AdaptItAcademyDB;

Create table DTA_UpcomingTrainings
(
 Id int primary key not null identity(1,1),
 UserId bigint not null,
 TrainingDate datetime not null,
 TrainingVenue varchar(200) not null,
 AvailableSeats int not null,
 RegistrationClosingDate datetime not null,
 CourseTrainingCost float not null,
 TrainingPaymentStatus varchar(200) not null,
 CreatedAt datetime not null,
 UpdatedAt datetime null,
 DeletedAt datetime null,
);

ALTER TABLE [dbo].[DTA_UpcomingTrainings] ADD  DEFAULT ((0)) FOR [UserId]
GO


Create table USR_UserDetails
(
Id bigint primary key identity(1,1),
FirstName varchar(150) not null,
LastName  varchar(150) not null,
PhoneNumber varchar(50) not null,
EmailAddress varchar(150) not null,
LUT_DietaryRequirementId int not null,
CompanyName varchar(200) not null,
PhysicalAddress varchar(300),
PostalAddress varchar(200) not null,
CourseId int not null,
TrainingId int not null,
CreatedAt datetime not null,
UpdatedAt datetime null,
DeletedAt datetime null
);

--ALTER TABLE [dbo].[AbpUserDetails]  WITH CHECK ADD  CONSTRAINT [FK_AbpUserDetails_AbpUserDetails_[LUT_DietaryRequirementsId]] FOREIGN KEY([LUT_DietaryRequirementsId])
--REFERENCES [dbo].[AbpUserDetails] ([Id])
--GO

Create table DTA_Courses
(
Id bigint primary key identity(1,1),
CourseCode bigint not null,
CourseName  varchar(150) not null,
CourseDescription varchar(250) not null,
CreatedAt datetime not null,
UpdatedAt datetime null,
DeletedAt datetime null
);

Create table LUT_DietaryRequirements
(
Id int primary key identity(1,1) not null,
Name varchar(150) not null,
CreatedAt datetime NOT NULL,
UpdatedAt datetime NULL,
DeletedAt datetime NULL
);


ALTER TABLE [dbo].[USR_UserDetails] ADD  DEFAULT ((0)) FOR [LUT_DietaryRequirementId]
GO

ALTER TABLE [dbo].[USR_UserDetails] ADD  DEFAULT ((0)) FOR [TrainingId]
GO


--Dietary Requirements

delete from LUT_DietaryRequirements

dbcc checkident ('LUT_DietaryRequirements', reseed, 0)
insert into LUT_DietaryRequirements
select 'Halal', getdate(), null,null
union
select 'Vegetarian', getdate(), null, null
union
select 'Vegan', getdate(), null, null
union
select 'Other', getdate(), null, null


--Courses
delete from DTA_Courses

dbcc checkident ('DTA_Courses', reseed, 0)
insert into DTA_Courses
select 123 SYSM, 'Systems Analysis and Design', 'Develop Entity Relationship Diagram (ERD), EFD', getdate(), null, null
union
select 163 DFTL, 'Data Structures', 'Buble sort, Linux commands', getdate(), null, null
union
select 178 XMKL, 'Introduction to Programming', 'Object Orientated Programming, Python, AI', getdate(), null, null


--Upcoming Trainings
delete from DTA_UpcomingTrainings

dbcc checkident ('DTA_UpcomingTrainings', reseed, 0)
insert into DTA_UpcomingTrainings
select 0, getdate(), 'Sandton Calibre', 66, getdate(), 456.00, 'Fee', getdate(), null, null
union
select 1, getdate(), 'Boston City Campus', 188, getdate(), 303.32, 'Paid', getdate(), null, null
union
select 2, getdate(), 'Kimberly Estate', 35, getdate(), 1200.00, 'Paid', getdate(), null, null


--User Details USR_UserDetails
delete from USR_UserDetails

dbcc checkident ('USR_UserDetails', reseed, 0)
insert into USR_UserDetails
select 'Phindile', 'Buthelezi', '076 234 4456', 'phindile78@gmail.com', 2, 'Northen Inspiration', 'Johannesburg 234 Assembly Estate', 'Johannesburg 234 Assembly Estate', 3, 2, getdate(), null, null
union
select 'Robert', 'Masango', '062 534 9958', 'rmasango46@gmail.com', 1, 'Tech Masters', '7832 Kempton park Estate', 'Johannesburg 7832 Kempton park Estate', 2, 1, getdate(), null, null
union
select 'John', 'McFlurry', '082 454 6798', 'johnMc@gmail.com', 3, 'We are Technology', '234 Collet Avenue Estate', 'Cape Town 234 Collet Avenue Estate', 1, 3, getdate(), null, null


  sp_configure 'show advanced options', 0;
go
reconfigure;
go