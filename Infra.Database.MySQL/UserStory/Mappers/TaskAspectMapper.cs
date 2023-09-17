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
                Id = new TaskReference(entity.Id.ToString()),
                Title = entity.Title,
                Description = entity.Description,
                Owner = new UserReference(entity.OwnerId.ToString()),
                StartedOn = entity.StartedOn,
                Period  = entity.Period,
                Status = TaskStatus.Parse(entity.Status),
                ModifiedOn = entity.ModifiedOn,
                ModifiedBy = new UserReference(entity.ModifiedById.ToString()),
                CreatedOn = entity.CreatedOn,
                CreatedBy = new UserReference(entity.CreatedById.ToString())
            };
        }
    }
}
