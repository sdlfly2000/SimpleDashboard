using Domain.UserStory;

namespace Domain.Services.UserStory.Loaders
{
    public interface ITaskAspectLoader
    {
        ITaskAspect LoadById(TaskReference id);

        IList<ITaskAspect> LoadByUserStroyId(UserStoryReference id);
    }
}
