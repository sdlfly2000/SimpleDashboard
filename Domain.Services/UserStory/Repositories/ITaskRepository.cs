using Domain.UserRequirement;

namespace Domain.Services.UserStory.Repositories
{
    public interface ITaskRepository : IRepository<long, TaskEntity>
    {
        Task<List<TaskEntity>> LoadByUserStoryId(UserStoryReference userStoryId);
    }
}
