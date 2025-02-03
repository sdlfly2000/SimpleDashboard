using Domain.UserRequirement;

namespace Domain.Services.UserStory.Repositories
{
    public interface IUserStoryRepository : IRepository<long, UserStoryEntity>
    {
        Task<IList<UserStoryEntity>> LoadByOwnerId(Guid id);
    }
}
