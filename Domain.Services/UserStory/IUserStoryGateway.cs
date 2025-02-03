using Domain.User;
using Domain.UserRequirement;

namespace Domain.Services.UserStory
{
    public interface IUserStoryGateway
    {
        Task<UserStoryEntity> GetUserStoryById(UserStoryReference Id);

        Task<IList<UserStoryEntity>> GetUserStoryByOwner(UserReference owner);
    }
}
