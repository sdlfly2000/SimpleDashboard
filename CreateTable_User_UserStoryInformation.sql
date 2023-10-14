use SimpleDashboard;

create table UserEntities (
	Id nvarchar(50),
    Name nvarchar(255),
    primary key (Id)
);

create table UserStoryInformation (
	Id nvarchar(50),
    Title nvarchar(255),
    Description nvarchar(255),
    OwnerId nvarchar(50),
    StartedOn datetime,
    Period time,
    Status nvarchar(20),
    ModifiedOn datetime,
    ModifiedById nvarchar(50),
	CreatedOn datetime,
    CreatedById nvarchar(50),
    primary key (Id),
    foreign key (OwnerId) references UserEntities(Id),
    foreign key (ModifiedById) references UserEntities(Id),
    foreign key (CreatedById) references UserEntities(Id)    
);