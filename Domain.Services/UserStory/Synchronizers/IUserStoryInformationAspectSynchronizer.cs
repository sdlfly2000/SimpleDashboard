using Domain.UserStory;

namespace Domain.Services.UserStory.Synchronizers
{
    public interface IUserStoryInformationAspectSynchronizer
    {
        void Synchronize(IUserStoryInformationAspect aspect);

        UserStoryReference Add(IUserStoryInformationAspect aspect);
    }
}
