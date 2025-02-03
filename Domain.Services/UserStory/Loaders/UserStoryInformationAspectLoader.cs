using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.User;
using Domain.UserRequirement;

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

        public async Task<UserStoryInformationAspect> Load(UserStoryReference Id)
        {
            return await _userStoryRepository.LoadById(long.Parse(Id.Code)).ConfigureAwait(false);
        }

        public async Task<IList<UserStoryInformationAspect>> LoadByOwner(UserReference owner)
        {
            return await _userStoryRepository.LoadByOwnerId(Guid.Parse(owner.Code)).ConfigureAwait(false);
        }
    }
}
