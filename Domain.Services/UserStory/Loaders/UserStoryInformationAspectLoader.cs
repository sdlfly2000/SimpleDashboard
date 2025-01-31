using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.User;
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

        public async Task<IUserStoryInformationAspect> Load(UserStoryReference Id)
        {
            return await _userStoryRepository.LoadById(long.Parse(Id.Code)).ConfigureAwait(false);
        }

        public async Task<IList<IUserStoryInformationAspect>> LoadByOwner(UserReference owner)
        {
            return await _userStoryRepository.LoadByOwnerId(Guid.Parse(owner.Code)).ConfigureAwait(false);
        }
    }
}
