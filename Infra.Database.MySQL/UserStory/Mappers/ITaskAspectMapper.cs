using Domain.UserStory;
using Infra.Database.MySQL.UserStory.Entities;

namespace Infra.Database.MySQL.UserStory.Mappers
{
    public interface ITaskAspectMapper
    {
        ITaskAspect Map(TaskEntity entity);
    }
}
