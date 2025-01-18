use SimpleDashboard;

create table UserEntities (
	Id nvarchar(36),
    Name nvarchar(255),
    primary key (Id)
);

create table UserStoryInformation (
	Id BIGINT IDENTITY(1,1),
    Title nvarchar(255),
    Description nvarchar(max),
    OwnerId nvarchar(36),
    StartedOn datetime,
    Period BIGINT,
    Status nvarchar(20),
    ModifiedOn datetime,
    ModifiedById nvarchar(36),
	CreatedOn datetime,
    CreatedById nvarchar(36),
    primary key (Id),
    foreign key (OwnerId) references UserEntities(Id),
    foreign key (ModifiedById) references UserEntities(Id),
    foreign key (CreatedById) references UserEntities(Id)    
);