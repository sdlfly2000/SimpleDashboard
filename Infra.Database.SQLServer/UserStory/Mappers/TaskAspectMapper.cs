using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserRequirement;
using Task = Infra.Database.SQLServer.UserStory.Entities.Task;

namespace Infra.Database.SQLServer.UserStory.Mappers
{
    [ServiceLocate(typeof(ITaskAspectMapper))]
    public class TaskAspectMapper : ITaskAspectMapper
    {
        public TaskEntity Map(Task entity)
        {
            return new TaskEntity
            {
                Reference = new TaskReference(entity.Id),
                Title = entity.Title ?? string.Empty,
                Description = entity.Description ?? string.Empty,
                Owner = new UserReference(entity.OwnerId?.ToString()),
                StartedOn = entity.StartedOn ?? default,
                Period = entity.Period.HasValue ? TimeSpan.FromTicks(entity.Period.Value) : default,
                Status = Enum.Parse<EnumRecordStatus>(entity.Status),
                ModifiedOn = entity.ModifiedOn ?? default,
                ModifiedBy = new UserReference(entity.ModifiedById?.ToString()),
                CreatedOn = entity.CreatedOn ?? default,
                CreatedBy = new UserReference(entity.CreatedById?.ToString())
            };
        }
    }
}
