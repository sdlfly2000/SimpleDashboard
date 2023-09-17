using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Loaders;
using Domain.User;
using Domain.UserStory;

namespace Domain.Services.UserStory
{
    [ServiceLocate(typeof(IUserStroyGateway))]
    public class UserStroyGateway : IUserStroyGateway
    {
        private readonly IUserStoryInformationAspectLoader _userStoryInformationAspectLoader;

        public UserStroyGateway(
            IUserStoryInformationAspectLoader userStoryInformationAspectLoader)
        {
            _userStoryInformationAspectLoader = userStoryInformationAspectLoader;
        }

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
