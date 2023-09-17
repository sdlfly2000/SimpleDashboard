using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserStory;

namespace Domain.Services.UserStory
{
    [ServiceLocate(typeof(IUserStroyGateway))]
    public class UserStroyGateway : IUserStroyGateway
    {
        public IUserStory GetUserStoryById(UserStoryReference Id)
        {
            throw new NotImplementedException();
        }

        public IList<IUserStory> GetUserStroyByOwner(UserReference owner)
        {
            throw new NotImplementedException();
        }
    }
}
