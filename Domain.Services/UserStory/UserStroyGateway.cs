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
        private readonly ITaskAspectLoader _taskAspectLoader;

        public UserStroyGateway(
            IUserStoryInformationAspectLoader userStoryInformationAspectLoader,
            ITaskAspectLoader taskAspectLoader)
        {
            _userStoryInformationAspectLoader = userStoryInformationAspectLoader;
            _taskAspectLoader = taskAspectLoader;
        }

        public IUserStory GetUserStoryById(UserStoryReference Id)
        {
            var userStoryInformationAspect = _userStoryInformationAspectLoader.Load(Id);
            var userStory = new UserStoryDomain(userStoryInformationAspect);
            var taskAspects = _taskAspectLoader.LoadByUserStroyId(Id);

            userStory.Tasks.AddRange(taskAspects);

            return userStory;
        }

        public IList<IUserStory> GetUserStroyByOwner(UserReference owner)
        {
            throw new NotImplementedException();
        }
    }
}
