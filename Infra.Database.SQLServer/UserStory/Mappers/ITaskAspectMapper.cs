using Domain.UserStory;
using Task = Infra.Database.SQLServer.UserStory.Entities.Task;

namespace Infra.Database.SQLServer.UserStory.Mappers
{
    public interface ITaskAspectMapper
    {
        ITaskAspect Map(Task entity);
    }
}
