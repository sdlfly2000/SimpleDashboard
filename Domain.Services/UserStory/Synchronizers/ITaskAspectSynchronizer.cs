using Domain.UserStory;

namespace Domain.Services.UserStory.Synchronizers
{
    public interface ITaskAspectSynchronizer : ISynchronizer<TaskReference, ITaskAspect>
    {
    }
}
