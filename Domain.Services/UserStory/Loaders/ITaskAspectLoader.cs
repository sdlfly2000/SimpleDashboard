using Domain.UserStory;

namespace Domain.Services.UserStory.Loaders
{
    public interface ITaskAspectLoader
    {
        Task<ITaskAspect> LoadById(TaskReference id);

        Task<List<ITaskAspect>> LoadByUserStroyId(UserStoryReference id);
    }
}
