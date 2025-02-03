using Domain.UserRequirement;

namespace Domain.Services.UserStory.Repositories
{
    public interface ITaskRepository : IRepository<long, TaskAspect>
    {
        Task<List<TaskAspect>> LoadByUserStoryId(UserStoryReference userStoryId);
    }
}
