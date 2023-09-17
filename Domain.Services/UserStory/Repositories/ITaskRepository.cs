using Domain.UserStory;

namespace Domain.Services.UserStory.Repositories
{
    public interface ITaskRepository
    {
        ITaskAspect LoadById(TaskReference id);

        IList<ITaskAspect> LoadByUserStoryId(UserStoryReference userStoryId);
    }
}
