using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserStory;
using Infra.Database.MySQL.UserStory.Entities;

namespace Infra.Database.MySQL.UserStory.Mappers
{
    [ServiceLocate(typeof(IUserStoryInformationAspectMapper))]
    public class UserStoryInformationAspectMapper : IUserStoryInformationAspectMapper
    {
        public IUserStoryInformationAspect Map(UserStoryInformationEntity entity)
        {
            return new UserStoryInformationAspect(new UserStoryReference(entity.Id.ToString()))
            {
                Title = entity.Title,
                Description = entity.Description,
                Owner = new UserReference(entity.OwnerId.ToString()),
                StartedOn = entity.StartedOn ?? default(DateTime),
                Period = entity.Period ?? default(TimeSpan),
                Status = new UserStroyStatus(entity.Status),
                ModifiedOn = entity.ModifiedOn ?? default(DateTime),
                ModifiedBy = new UserReference(entity.ModifiedById.ToString()),
                CreatedOn = entity.CreatedOn ?? default(DateTime),
                CreatedBy = new UserReference(entity.CreatedById.ToString())
            };
        }
    }
}
