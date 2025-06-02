create database EventDb 
go

create table UserInfo (
EmailId varchar(50) primary key,
UserName varchar(50) not null check(len(UserName) between 1 and 50),
Role varchar(20) not null check( Role in ('Admin', 'Participant')),
Password varchar(30) not null check(len(Password) between 6 and 20)
)
go

create table EventDetails(
EventId int primary key,
EventName varchar(50) not null check(len(EventName) between 1 and 50),
EventCategory varchar(50) not null check(len(EventCategory) between 1 and 50),
EventDate datetime not null,
Description varchar(50),
Status varchar(10) check(Status in ('Active','In-Active')),
)
go

create table SpeakersDetails(
SpeakerId int primary key,
SpeakerName varchar(50) not null check(len(SpeakerName) between 1 and 50)
)
go

create table SessionInfo(
SessionId int primary key,
EventId int not null,
SessionTitle varchar(50) not null check(len(SessionTitle) between 1 and 50),
SpeakerId int not null,
Description varchar(max),
SessionStart datetime not null,
SessionEnd datetime not null,
SessionUrl varchar(100),
CONSTRAINT FK_Session_Event FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
CONSTRAINT FK_Session_Speaker FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)

)
go

select * from SessionInfo

select * from SpeakersDetails

select * from EventDetails

select * from UserInfo