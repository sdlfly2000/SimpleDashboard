create table Tasks (
	Id nvarchar(36),
    Title nvarchar(max),
    Description nvarchar(max),
    OwnerId nvarchar(36),
    StartedOn datetime2,
    Period time,
    Status nvarchar(20),
    ModifiedOn datetime2,
    ModifiedById nvarchar(36),
	CreatedOn datetime,
    CreatedById nvarchar(36),
    UserStoryId nvarchar(36)

    primary key (Id),
    foreign key (OwnerId) references UserEntities(Id),
    foreign key (ModifiedById) references UserEntities(Id),
    foreign key (CreatedById) references UserEntities(Id),    
    foreign key (UserStoryId) references UserStoryInformation(Id)    
);