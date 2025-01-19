using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Synchronizers;
using Domain.UserStory;

namespace Infra.Database.SQLServer.UserStory.Synchronizers;

[ServiceLocate(typeof(IUserStoryInformationAspectSynchronizer))]
public class UserStoryInformationAspectSynchronizer : IUserStoryInformationAspectSynchronizer
{
    public IEntity Synchronize(IUserStoryInformationAspect aspect)
    {
        throw new NotImplementedException();
    }
}
