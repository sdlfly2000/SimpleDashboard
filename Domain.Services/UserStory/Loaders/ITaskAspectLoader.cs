using Domain.UserRequirement;

namespace Domain.Services.UserStory.Loaders
{
    public interface ITaskAspectLoader
    {
        Task<TaskAspect> LoadById(TaskReference id);

        Task<List<TaskAspect>> LoadByUserStroyId(UserStoryReference id);
    }
}
