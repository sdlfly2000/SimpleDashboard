using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserRequirement;
using Infra.Database.SQLServer.UserStory.Entities;

namespace Infra.Database.SQLServer.UserStory.Mappers
{
    [ServiceLocate(typeof(IUserStoryInformationAspectMapper))]
    public class UserStoryInformationAspectMapper : IUserStoryInformationAspectMapper
    {
        public UserStoryInformationAspect Map(UserStoryInformation entity)
        {
            return new UserStoryInformationAspect(new UserStoryReference(entity.Id))
            {
                Title = entity.Title ?? string.Empty,
                Description = entity.Description ?? string.Empty,
                Owner = new UserReference(entity.OwnerId ?? string.Empty.ToString()),
                StartedOn = entity.StartedOn ?? default,
                Status = entity.Status != null ? (UserStroyStatus)entity.Status : default,
                ModifiedOn = entity.ModifiedOn ?? default,
                ModifiedBy = new UserReference(entity.ModifiedById ?? string.Empty.ToString()),
                CreatedOn = entity.CreatedOn ?? default,
                CreatedBy = new UserReference(entity.CreatedById ?? string.Empty.ToString())
            };
        }
    }
}
