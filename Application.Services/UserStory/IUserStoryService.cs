using Application.UserStory;

namespace Application.Services.UserStory
{
    public interface IUserStoryService
    {
        CreateUserStoryResponse Create(CreateUserStoryRequest request);
    }
}
