using Domain.User;
using Domain.UserStory;

namespace Domain.Services.UserStory
{
    internal interface IUserStroyGateway
    {
        Task<IUserStory> GetUserStoryById(UserStoryReference Id);

        Task<IList<IUserStory>> GetUserStroyByOwner(UserReference owner);
    }
}
