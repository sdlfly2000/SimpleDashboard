using Common.Core.Data.Sql;
using Domain.UserStory;

namespace Domain.Services.UserStory.Synchronizers
{
    public interface IUserStoryInformationAspectSynchronizer : ISynchronizer<IUserStoryInformationAspect, IEntity>
    {
    }
}
