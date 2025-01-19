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

        public async Task<IUserStory> GetUserStoryById(UserStoryReference Id)
        {
            var userStoryInformationAspect = await _userStoryInformationAspectLoader.Load(Id).ConfigureAwait(false);
            var userStory = new UserStoryDomain(userStoryInformationAspect);
            var taskAspects = await _taskAspectLoader.LoadByUserStroyId(Id).ConfigureAwait(false);

            userStory.Tasks.AddRange(taskAspects);

            return userStory;
        }

        public async Task<IList<IUserStory>> GetUserStroyByOwner(UserReference owner)
        {
            var userStories = new List<UserStoryDomain>();
            var userStoryInformationAspects = await _userStoryInformationAspectLoader.LoadByOwner(owner).ConfigureAwait(false);

            foreach(var aspect in userStoryInformationAspects)
            {
                var userStory = new UserStoryDomain(aspect);
                var tasks = await _taskAspectLoader.LoadByUserStroyId((aspect.Reference as UserStoryReference)!).ConfigureAwait(false);
                userStory.Tasks.AddRange(tasks);
                userStories.Add(userStory);
            }

            return (IList<IUserStory>)userStories;
        }
    }
}
