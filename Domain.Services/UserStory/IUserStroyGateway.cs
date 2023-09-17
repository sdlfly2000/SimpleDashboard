using Domain.User;
using Domain.UserStory;

namespace Domain.Services.UserStory
{
    internal interface IUserStroyGateway
    {
        IUserStory GetUserStoryById(UserStoryReference Id);

        IList<IUserStory> GetUserStroyByOwner(UserReference owner);
    }
}
