using Domain.UserStory;

namespace Domain.Services.UserStory.Repositories
{
    public interface ITaskRepository
    {
        ITaskAspect LoadById(TaskReference id);

        List<ITaskAspect> LoadByUserStoryId(UserStoryReference userStoryId);
    }
}
