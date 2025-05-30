USE [SimpleDashboard]
GO

create table UserRequirements (
	Id BIGINT IDENTITY(1, 1),
    Title nvarchar(255),
    Description nvarchar(255),
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
GO