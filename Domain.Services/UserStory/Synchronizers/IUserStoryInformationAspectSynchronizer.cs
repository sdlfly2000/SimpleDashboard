using Domain.UserStory;

namespace Domain.Services.UserStory.Synchronizers
{
    public interface IUserStoryInformationAspectSynchronizer : ISynchronizer<UserStoryReference, IUserStoryInformationAspect>
    {
    }
}
