using Domain.UserStory;

namespace Domain.Services.UserStory.Repositories
{
    public interface IUserStoryRepository 
    {
        IUserStoryInformationAspect LoadById(Guid Id);
    }
}
