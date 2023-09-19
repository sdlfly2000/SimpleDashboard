using Domain.Services;
using Domain.UserStory;

namespace Infra.Database.MySQL.UserStory.Synchronizers
{
    public interface ITaskAspectSynchronizer : ISynchronizer<TaskReference, ITaskAspect>
    {
    }
}
