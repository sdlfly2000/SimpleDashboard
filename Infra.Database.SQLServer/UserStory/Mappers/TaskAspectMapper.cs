using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserRequirement;
using SimpleDashboard.Common;
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
                Owner = new UserReference(Guid.Parse(entity.OwnerId)),
                StartedOn = entity.StartedOn ?? default,
                Period = entity.Period.HasValue ? TimeSpan.FromTicks(entity.Period.Value) : default,
                Status = Enum.Parse<EnumRecordStatus>(entity.Status),
                ModifiedOn = entity.ModifiedOn ?? default,
                ModifiedBy = new UserReference(Guid.Parse(entity.ModifiedById)),
                CreatedOn = entity.CreatedOn ?? default,
                CreatedBy = new UserReference(Guid.Parse(entity.CreatedById))
            };
        }
    }
}
