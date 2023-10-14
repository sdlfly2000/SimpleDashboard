create table Tasks (
	Id uniqueidentifier,
    Title nvarchar(max),
    Description nvarchar(max),
    OwnerId uniqueidentifier,
    StartedOn datetime2,
    Period time,
    Status nvarchar(20),
    ModifiedOn datetime2,
    ModifiedById uniqueidentifier,
	CreatedOn datetime,
    CreatedById uniqueidentifier,
    UserStoryId uniqueidentifier

    primary key (Id),
    foreign key (OwnerId) references UserEntities(Id),
    foreign key (ModifiedById) references UserEntities(Id),
    foreign key (CreatedById) references UserEntities(Id),    
    foreign key (UserStoryId) references UserStoryInformation(Id)    
);