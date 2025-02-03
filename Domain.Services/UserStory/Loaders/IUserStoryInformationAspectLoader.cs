using Domain.User;
using Domain.UserRequirement;

namespace Domain.Services.UserStory.Loaders
{
    public interface IUserStoryInformationAspectLoader
    {
        Task<UserStoryEntity> Load(UserStoryReference Id);

        Task<IList<UserStoryEntity>> LoadByOwner(UserReference owner);
    }
}
