using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.UserStory;
using Infra.Database.MySQL.UserStory.Entities;

namespace Infra.Database.MySQL.UserStory.Synchronizers;

[ServiceLocate(typeof(IUserStoryInformationAspectSynchronizer))]
public class UserStoryInformationAspectSynchronizer : IUserStoryInformationAspectSynchronizer
{
    public IEntity Synchronize(IUserStoryInformationAspect aspect)
    {
        return new UserStoryInformationEntity
        {
            Id = aspect.Reference != null 
                ? Guid.Parse(aspect.Reference.Code)
                : Guid.Empty,
            Title = aspect.Title,
            Description = aspect.Description,
        };
    }
}
