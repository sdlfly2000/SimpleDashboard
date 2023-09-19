using Domain.UserStory;

namespace Domain.Services.UserStory.Synchronizers
{
    public interface ITaskAspectSynchronizer
    {
        void Synchronize(ITaskAspect aspect);

        TaskReference Add(ITaskAspect aspect);
    }
}
