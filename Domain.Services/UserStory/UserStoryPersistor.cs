using Common.Core.DependencyInjection;
using Domain.UserStory;

namespace Domain.Services.UserStory
{
    [ServiceLocate(typeof(IUserStoryPersistor))]
    public class UserStoryPersistor : IUserStoryPersistor
    {
        public UserStoryReference Add(IUserStory userStory)
        {
            throw new NotImplementedException();
        }

        public void Persist(IUserStory userStory)
        {
            throw new NotImplementedException();
        }
    }
}
