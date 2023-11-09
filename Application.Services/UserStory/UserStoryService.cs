using Application.UserStory;
using Common.Core.DependencyInjection;
using Domain.Services.UserStory;

namespace Application.Services.UserStory
{
    [ServiceLocate(typeof(IUserStoryService))]
    public class UserStoryService : IUserStoryService
    {
        private readonly IUserStoryPersistor _persistor;

        public UserStoryService(IUserStoryPersistor persistor)
        {
            _persistor = persistor;
        }

        public CreateUserStoryResponse Create(CreateUserStoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
