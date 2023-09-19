using Common.Core.Data.Sql;
using Domain.Services;
using Domain.UserStory;

namespace Infra.Database.MySQL.UserStory.Synchronizers
{
    public interface ITaskAspectSynchronizer : ISynchronizer<ITaskAspect, IEntity>
    {
    }
}
