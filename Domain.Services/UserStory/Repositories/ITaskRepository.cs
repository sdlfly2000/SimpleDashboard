using Domain.UserStory;

namespace Domain.Services.UserStory.Repositories
{
    public interface ITaskRepository : IRepository<long, ITaskAspect>
    {
        Task<List<ITaskAspect>> LoadByUserStoryId(UserStoryReference userStoryId);
    }
}
