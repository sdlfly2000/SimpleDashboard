using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Synchronizers;
using Domain.UserStory;
using Infra.Database.SQLServer.UserStory.Entities;

namespace Infra.Database.SQLServer.UserStory.Synchronizers;

[ServiceLocate(typeof(IUserStoryInformationAspectSynchronizer))]
public class UserStoryInformationAspectSynchronizer : IUserStoryInformationAspectSynchronizer
{
    public IEntity Synchronize(IUserStoryInformationAspect aspect)
    {
        return new UserStoryInformationEntity
        {
            Id = aspect.Reference != null
                ? Guid.Parse(aspect.Reference.Code)
                : Guid.NewGuid(),
            Title = aspect.Title,
            Description = aspect.Description,
            OwnerId = Guid.Parse(aspect.Owner.Code),
            StartedOn = aspect.StartedOn,
            Period = aspect.Period,
            Status = aspect.Status.Status,
            ModifiedOn = aspect.ModifiedOn,
            ModifiedById = Guid.Parse(aspect.ModifiedBy.Code),
            CreatedOn = aspect.CreatedOn,
            CreatedById = Guid.Parse(aspect.CreatedBy.Code)
        };
    }
}
