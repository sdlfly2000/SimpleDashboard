using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserStory;
using Infra.Database.SQLServer.UserStory.Entities;

namespace Infra.Database.SQLServer.UserStory.Mappers
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
                StartedOn = entity.StartedOn ?? default,
                Period = entity.Period ?? default,
                Status = new UserStroyStatus(entity.Status),
                ModifiedOn = entity.ModifiedOn ?? default,
                ModifiedBy = new UserReference(entity.ModifiedById.ToString()),
                CreatedOn = entity.CreatedOn ?? default,
                CreatedBy = new UserReference(entity.CreatedById.ToString())
            };
        }
    }
}
