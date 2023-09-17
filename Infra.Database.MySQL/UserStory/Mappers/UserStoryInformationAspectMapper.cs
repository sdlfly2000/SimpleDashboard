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
                Owner = new UserReference(entity.Owner.Id.ToString()),
                StartedOn = entity.StartedOn,
                Period = entity.Period,
                Status = new UserStroyStatus(entity.Status),
                ModifiedOn = entity.ModifiedOn,
                ModifiedBy = new UserReference(entity.ModifiedBy.Id.ToString()),
                CreatedOn = entity.CreatedOn,
                CreatedBy = new UserReference(entity.CreatedBy.Id.ToString())
            };
        }
    }
}
