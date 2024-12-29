using Common.Core.DependencyInjection;
using Domain.User;
using Domain.UserStory;
using Infra.Database.SQLServer.UserStory.Entities;
using TaskStatus = Domain.UserStory.TaskStatus;

namespace Infra.Database.SQLServer.UserStory.Mappers
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
                StartedOn = entity.StartedOn ?? default,
                Period = entity.Period ?? default,
                Status = TaskStatus.Parse(entity.Status),
                ModifiedOn = entity.ModifiedOn ?? default,
                ModifiedBy = new UserReference(entity.ModifiedById?.ToString()),
                CreatedOn = entity.CreatedOn ?? default,
                CreatedBy = new UserReference(entity.CreatedById?.ToString())
            };
        }
    }
}
