using Common.Core.Data.Sql;
using Domain.UserStory;

namespace Domain.Services.UserStory.Repositories
{
    public interface IUserStoryRepository : IRepository<IUserStoryInformationAspect, IEntity>
    {
    }
}
