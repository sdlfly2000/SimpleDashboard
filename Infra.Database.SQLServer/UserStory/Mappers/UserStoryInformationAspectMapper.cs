using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserRequirement;
using Infra.Database.SQLServer.UserStory.Entities;

namespace Infra.Database.SQLServer.UserStory.Mappers
{
    [ServiceLocate(typeof(IUserStoryInformationAspectMapper))]
    public class UserStoryInformationAspectMapper : IUserStoryInformationAspectMapper
    {
        public UserStoryEntity Map(UserStoryInformation entity)
        {
            return new UserStoryEntity(new UserStoryReference(entity.Id))
            {
                Title = entity.Title ?? string.Empty,
                Description = entity.Description ?? string.Empty,
                Owner = new UserReference(Guid.Parse(entity.OwnerId)),
                StartedOn = entity.StartedOn ?? default,
                Status = entity.Status != null ? Enum.Parse<EnumRecordStatus>(entity.Status) : default,
                ModifiedOn = entity.ModifiedOn ?? default,
                ModifiedBy = new UserReference(Guid.Parse(entity.ModifiedById)),
                CreatedOn = entity.CreatedOn ?? default,
                CreatedBy = new UserReference(Guid.Parse(entity.CreatedById))
            };
        }
    }
}
