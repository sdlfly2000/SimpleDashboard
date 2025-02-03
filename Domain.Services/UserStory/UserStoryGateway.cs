using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Loaders;
using Domain.User;
using Domain.UserRequirement;

namespace Domain.Services.UserStory
{
    [ServiceLocate(typeof(IUserStoryGateway))]
    public class UserStoryGateway : IUserStoryGateway
    {
        private readonly IUserStoryInformationAspectLoader _userStoryInformationAspectLoader;
        private readonly ITaskAspectLoader _taskAspectLoader;

        public UserStoryGateway(
            IUserStoryInformationAspectLoader userStoryInformationAspectLoader,
            ITaskAspectLoader taskAspectLoader)
        {
            _userStoryInformationAspectLoader = userStoryInformationAspectLoader;
            _taskAspectLoader = taskAspectLoader;
        }

        public async Task<UserStoryEntity> GetUserStoryById(UserStoryReference Id)
        {
            var userStory = await _userStoryInformationAspectLoader.Load(Id).ConfigureAwait(false);
            var taskAspects = await _taskAspectLoader.LoadByUserStroyId(Id).ConfigureAwait(false);

            userStory.Tasks.AddRange(taskAspects);

            return userStory;
        }

        public async Task<IList<UserStoryEntity>> GetUserStoryByOwner(UserReference owner)
        {
            var userStories = new List<UserStoryEntity>();
            var userStoryInformationAspects = await _userStoryInformationAspectLoader.LoadByOwner(owner).ConfigureAwait(false);

            foreach(var aspect in userStoryInformationAspects)
            {
                var tasks = await _taskAspectLoader.LoadByUserStroyId((aspect.Reference as UserStoryReference)!).ConfigureAwait(false);
                aspect.Tasks.AddRange(tasks);
                userStories.Add(aspect);
            }

            return (IList<UserStoryEntity>)userStories;
        }
    }
}
