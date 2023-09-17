using Common.Core.DependencyInjection;
using Domain.UserStory;

namespace Domain.Services.UserStory.Loaders
{
    [ServiceLocate(typeof(IUserStoryInformationAspectLoader))]
    public class UserStoryInformationAspectLoader : IUserStoryInformationAspectLoader
    {

        public IUserStoryInformationAspect Load(UserStoryReference Id)
        {
            throw new NotImplementedException();
        }
    }
}
