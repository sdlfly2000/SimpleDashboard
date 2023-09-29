using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;

namespace Domain.Services.UserStory
{
    [ServiceLocate(typeof(IUserStoryPersistor))]
    public class UserStoryPersistor : IUserStoryPersistor
    {
        private readonly IUserStoryRepository _repository;

        public UserStoryPersistor(IUserStoryRepository repository)
        {
            _repository = repository;
        }

        public UserStoryReference Add(IUserStory userStory)
        {
            var userStoryGUID = _repository.Add(userStory);
            return new UserStoryReference(userStoryGUID.ToString());
        }

        public void Persist(IUserStory userStory)
        {
            _repository.Update(userStory);
        }
    }
}
