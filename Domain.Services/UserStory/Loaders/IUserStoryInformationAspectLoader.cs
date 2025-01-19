using Domain.User;
using Domain.UserStory;

namespace Domain.Services.UserStory.Loaders
{
    public interface IUserStoryInformationAspectLoader
    {
        Task<IUserStoryInformationAspect> Load(UserStoryReference Id);

        Task<IList<IUserStoryInformationAspect>> LoadByOwner(UserReference owner);
    }
}
