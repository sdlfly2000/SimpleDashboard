using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserStory;
using Infra.Database.MySQL.UserStory.Entities;
using TaskStatus = Domain.UserStory.TaskStatus;

namespace Infra.Database.MySQL.UserStory.Mappers
{
    [ServiceLocate(typeof(ITaskAspectMapper))]
    public class TaskAspectMapper : ITaskAspectMapper
    {
        public ITaskAspect Map(TaskEntity entity)
        {
            return new TaskAspect
            {
                Reference = new TaskReference(entity.Id.ToString()),
                Title = entity.Title ?? string.Empty,
                Description = entity.Description ?? string.Empty,
                Owner = new UserReference(entity.OwnerId?.ToString()),
                StartedOn = entity.StartedOn ?? default(DateTime),
                Period  = entity.Period ?? default(TimeSpan),
                Status = TaskStatus.Parse(entity.Status),
                ModifiedOn = entity.ModifiedOn ?? default(DateTime),
                ModifiedBy = new UserReference(entity.ModifiedById?.ToString()),
                CreatedOn = entity.CreatedOn ?? default(DateTime),
                CreatedBy = new UserReference(entity.CreatedById?.ToString())
            };
        }
    }
}
