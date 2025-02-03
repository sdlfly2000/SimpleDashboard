using Domain.UserRequirement;

namespace Domain.Services.UserStory.Loaders
{
    public interface ITaskAspectLoader
    {
        Task<TaskEntity> LoadById(TaskReference id);

        Task<List<TaskEntity>> LoadByUserStroyId(UserStoryReference id);
    }
}
