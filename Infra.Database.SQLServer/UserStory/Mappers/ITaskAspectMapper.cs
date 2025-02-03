using Domain.UserRequirement;
using Task = Infra.Database.SQLServer.UserStory.Entities.Task;

namespace Infra.Database.SQLServer.UserStory.Mappers
{
    public interface ITaskAspectMapper : IMapper<Task, TaskEntity>
    {
    }
}
