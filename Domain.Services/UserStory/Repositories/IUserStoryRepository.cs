using Domain.UserStory;

namespace Domain.Services.UserStory.Repositories
{
    public interface IUserStoryRepository : IRepository<IUserStoryInformationAspect>
    {
        Task<IList<IUserStoryInformationAspect>> LoadByOwnerId(Guid id);
    }
}
