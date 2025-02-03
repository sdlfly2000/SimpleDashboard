using Domain.User;
using Domain.UserRequirement;

namespace Domain.Services.UserStory.Loaders
{
    public interface IUserStoryInformationAspectLoader
    {
        Task<UserStoryInformationAspect> Load(UserStoryReference Id);

        Task<IList<UserStoryInformationAspect>> LoadByOwner(UserReference owner);
    }
}
