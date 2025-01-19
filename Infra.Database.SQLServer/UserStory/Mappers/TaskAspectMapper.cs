using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserStory;
using Task = Infra.Database.SQLServer.UserStory.Entities.Task;
using TaskStatus = Domain.UserStory.TaskStatus;

namespace Infra.Database.SQLServer.UserStory.Mappers
{
    [ServiceLocate(typeof(ITaskAspectMapper))]
    public class TaskAspectMapper : ITaskAspectMapper
    {
        public ITaskAspect? Map(Task? entity)
        {
            if (entity == null) {
                return default;
            }

            return new TaskAspect
            {
                Reference = new TaskReference(entity.Id),
                Title = entity.Title ?? string.Empty,
                Description = entity.Description ?? string.Empty,
                Owner = new UserReference(entity.OwnerId?.ToString()),
                StartedOn = entity.StartedOn ?? default,
                Period = entity.Period.HasValue ? TimeSpan.FromTicks(entity.Period.Value) : default,
                Status = TaskStatus.Parse(entity.Status),
                ModifiedOn = entity.ModifiedOn ?? default,
                ModifiedBy = new UserReference(entity.ModifiedById?.ToString()),
                CreatedOn = entity.CreatedOn ?? default,
                CreatedBy = new UserReference(entity.CreatedById?.ToString())
            };
        }
    }
}
