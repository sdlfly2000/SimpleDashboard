using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;

namespace Domain.Services.UserStory.Synchronizers
{
    [ServiceLocate(typeof(IUserStoryInformationAspectSynchronizer))]
    public class UserStoryInformationAspectSynchronizer : IUserStoryInformationAspectSynchronizer
    {
        private readonly IUserStoryRepository _repository;

        public UserStoryInformationAspectSynchronizer(IUserStoryRepository repository)
        {
            _repository = repository;
        }

        public UserStoryReference Add(IUserStoryInformationAspect aspect)
        {
            return (UserStoryReference)_repository.Add(aspect);
        }

        public void Synchronize(IUserStoryInformationAspect aspect)
        {
            _repository.Update(aspect);
        }
    }
}
