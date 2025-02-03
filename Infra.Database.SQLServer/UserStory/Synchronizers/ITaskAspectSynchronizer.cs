using Domain.UserRequirement;
using Task = Infra.Database.SQLServer.UserStory.Entities.Task;

namespace Infra.Database.SQLServer.UserStory.Synchronizers
{
    public interface ITaskAspectSynchronizer : ISynchronize<TaskAspect, Task>
    {
    }
}
