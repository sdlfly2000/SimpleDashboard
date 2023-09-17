using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;

namespace Domain.Services.UserStory.Loaders
{
    [ServiceLocate(typeof(IUserStoryInformationAspectLoader))]
    public class UserStoryInformationAspectLoader : IUserStoryInformationAspectLoader
    {
        public UserStoryInformationAspectLoader(IUserStoryRepository repository)
        {
            
        }

        public IUserStoryInformationAspect Load(UserStoryReference Id)
        {
            throw new NotImplementedException();
        }
    }
}
