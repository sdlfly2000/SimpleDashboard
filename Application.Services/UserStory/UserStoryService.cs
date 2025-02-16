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
            var userStory = new UserStoryEntity
            {
                Title = request.Title,
                Description = request.Description,
                Owner = UserReference.Parse(Guid.Parse(request.Owner)),
                StartedOn = request.StartedOn,
                Period = request.Period,
                Status = Enum.Parse<EnumRecordStatus>(request.Status),
                ModifiedOn = request.ModifiedOn,
                ModifiedBy = UserReference.Parse(Guid.Parse(request.ModifiedBy)),
                CreatedOn = request.CreatedOn,
                CreatedBy = UserReference.Parse(Guid.Parse(request.CreatedBy))
            };

            return new CreateUserStoryResponse { };
        }

        public RetrieveUserStoriesByOnwerResponse Retrieve(RetrieveUserStoriesByOnwerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
