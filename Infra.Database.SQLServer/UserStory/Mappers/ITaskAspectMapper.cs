using Domain.UserStory;
using Infra.Database.SQLServer.UserStory.Entities;

namespace Infra.Database.SQLServer.UserStory.Mappers
{
    public interface ITaskAspectMapper
    {
        ITaskAspect Map(TaskEntity entity);
    }
}
