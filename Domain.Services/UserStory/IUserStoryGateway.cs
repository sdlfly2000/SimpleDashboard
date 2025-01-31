using Domain.User;
using Domain.UserStory;

namespace Domain.Services.UserStory
{
    public interface IUserStoryGateway
    {
        Task<IUserStory> GetUserStoryById(UserStoryReference Id);

        Task<IList<IUserStory>> GetUserStoryByOwner(UserReference owner);
    }
}
