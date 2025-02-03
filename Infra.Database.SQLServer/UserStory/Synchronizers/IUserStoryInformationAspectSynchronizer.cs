using Domain.UserRequirement;
using Infra.Database.SQLServer.UserStory.Entities;

namespace Infra.Database.SQLServer.UserStory.Synchronizers
{
    public interface IUserStoryInformationAspectSynchronizer : ISynchronize<UserStoryEntity, UserStoryInformation>
    {
    }
}
