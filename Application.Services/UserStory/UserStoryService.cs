using Application.UserStory;
using Common.Core.DependencyInjection;
using Domain.Services.UserStory;
using Domain.User;
using Domain.UserRequirement;

namespace Application.Services.UserStory
{
    [ServiceLocate(typeof(IUserStoryService))]
    public class UserStoryService : IUserStoryService
    {
        private readonly IUserStoryGateway _userStoryGateway;

        public UserStoryService(IUserStoryGateway persistor)
        {
            _userStoryGateway = persistor;
        }

        public CreateUserStoryResponse Create(CreateUserStoryRequest request)
        {
            var userStory = new UserStoryDomain(new UserStoryInformationAspect()
            {
                Title = request.Title,
                Description = request.Description,
                Owner = UserReference.Parse(request.Owner),
                StartedOn = request.StartedOn,
                Period = request.Period,
                Status =UserStroyStatus.Parse(request.Status),
                ModifiedOn = request.ModifiedOn,
                ModifiedBy = UserReference.Parse(request.ModifiedBy),
                CreatedOn = request.CreatedOn,
                CreatedBy = UserReference.Parse(request.CreatedBy)
            });

            return new CreateUserStoryResponse { };
        }

        public RetrieveUserStoriesByOnwerResponse Retrieve(RetrieveUserStoriesByOnwerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
