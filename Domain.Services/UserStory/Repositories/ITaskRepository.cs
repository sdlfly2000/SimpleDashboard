using Domain.UserStory;

namespace Domain.Services.UserStory.Repositories
{
    public interface ITaskRepository
    {
        Task<ITaskAspect?> LoadById(TaskReference id);

        Task<List<ITaskAspect>> LoadByUserStoryId(UserStoryReference userStoryId);
    }
}
