using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;

namespace Domain.Services.UserStory.Loaders
{
    [ServiceLocate(typeof(IUserStoryInformationAspectLoader))]
    public class UserStoryInformationAspectLoader : IUserStoryInformationAspectLoader
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UserStoryInformationAspectLoader(IUserStoryRepository repository)
        {
            _userStoryRepository = repository; 
        }

        public IUserStoryInformationAspect Load(UserStoryReference Id)
        {
            return _userStoryRepository.LoadById(Guid.Parse(Id.Code));
        }
    }
}
