using Domain.User;
using Domain.UserRequirement;

namespace Domain.Services.UserStory.Loaders
{
    public interface IUserStoryInformationAspectLoader
    {
        Task<IUserStoryInformationAspect> Load(UserStoryReference Id);

        Task<IList<IUserStoryInformationAspect>> LoadByOwner(UserReference owner);
    }
}
